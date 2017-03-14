using System;

namespace Version_1_C
{
    [Serializable()]
    public class clsArtist
    {
        private string _Name;
        private string _Speciality;
        private string _Phone;

        private decimal _TotalValue;
       
        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;

        private static frmArtist artistDialog = new frmArtist();

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        public string Speciality
        {
            get
            {
                return _Speciality;
            }

            set
            {
                _Speciality = value;
            }
        }

        public string Phone
        {
            get
            {
                return _Phone;
            }

            set
            {
                _Phone = value;
            }
        }               

        public clsWorksList WorksList
        {
            get
            {
                return _WorksList;
            }

            //set
            //{
            //    _WorksList = value;
            //}
        }

        public clsArtistList ArtistList
        {
            get
            {
                return _ArtistList;
            }

            //set
            //{
            //    _ArtistList = value;
            //}
        }

        public decimal TotalValue
        {
            get
            {
                return _TotalValue;
            }

            //set
            //{
            //    _TotalValue = value;
            //}
        }

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            EditDetails();
        }

        public void EditDetails()
        {
            artistDialog.SetDetails(this);
            TotalValue = WorksList.GetTotalValue(); //step 8h
            
            //artistDialog.SetDetails(Name, Speciality, Phone, WorksList, ArtistList);// _SortOrder,
            //if (artistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    artistDialog.GetDetails(ref Name, ref Speciality, ref Phone);//, ref _SortOrder
            //    TotalValue = WorksList.GetTotalValue();
            //}
        }

        //public string GetKey()  step 8b
        //{
        //    return Name;
        //}

        //public decimal GetWorksValue()
        //{
        //    return TotalValue;
        //}
    }
}
