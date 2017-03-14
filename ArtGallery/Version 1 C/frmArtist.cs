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

        //public void SetDetails(string prName, string prSpeciality, string prPhone,
        //                       clsWorksList prWorksList, clsArtistList prArtistList)
        //{
        //    txtName.Text = prName;
        //    txtSpeciality.Text = prSpeciality;
        //    txtPhone.Text = prPhone;
        //    _ArtistList = prArtistList;
        //    _WorksList = prWorksList;
        //    _SortOrder = _WorksList.SortOrder;
        //    UpdateDisplay();
        //}  step 8e
        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            updateForm();
            UpdateDisplay();
            ShowDialog();
        }
        //public void GetDetails(ref string prName, ref string prSpeciality, ref string prPhone)
        //{
        //    prName = txtName.Text;
        //    prSpeciality = txtSpeciality.Text;
        //    prPhone = txtPhone.Text;
        //    _WorksList.SortOrder = _SortOrder;
        //} step 8f
        

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
                if (_ArtistList.Contains(txtName.Text))
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
            txtName.Text = Artist.Name;
            txtPhone.Text = Artist.Phone;
            txtSpeciality.Text = Artist.Speciality;
            
            lblTotal.Text = Convert.ToString(Artist.TotalValue);
            lstWorks.Text = Convert.ToString(Artist.WorksList);
        }

        private void pushData()
        {
            Artist.Name = txtName.Text;
            Artist.Phone = txtPhone.Text;
            Artist.Speciality = txtSpeciality.Text;
            
            Artist.TotalValue = Convert.ToDecimal(lblTotal.Text);
        }
    }
}