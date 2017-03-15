using System;
//using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        private clsArtistList _ArtistList;
        private clsWorksList _WorksList;
        private byte _SortOrder; // 0 = Name, 1 = Date

        private clsArtist _Artist; //step 8c

        public clsArtist Artist
        {
            get
            {
                return _Artist;
            }

            set
            {
                _Artist = value;
            }
        }

        private void UpdateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (_SortOrder == 0)
            {
                _WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _WorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
        }
              
        //  step 8e
        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            updateForm();
            UpdateDisplay();
            ShowDialog();
        }
                

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _WorksList.DeleteWork(lstWorks.SelectedIndex);
            UpdateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _WorksList.AddWork();
            UpdateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();//step 8g
                DialogResult = DialogResult.OK;
            }           
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Artist.IsDuplicate(txtName.Text))//9b
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
                _WorksList.EditWork(lcIndex);
                UpdateDisplay();
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

        //step 8d 
        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtPhone.Text = _Artist.Phone;
            txtSpeciality.Text = _Artist.Speciality;
            
            lblTotal.Text = _Artist.TotalValue.ToString();
            lstWorks.Text = _Artist.WorksList.ToString();            
        }

        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Phone = txtPhone.Text;
            _Artist.Speciality = txtSpeciality.Text;

            _Artist.TotalValue = DateTime.Parse(lblTotal.Text);
        }
    }
}