using System;


namespace Version_1_C
{
    [Serializable()] 
    public class clsSculpture : clsWork
    {
        private float _Weight;
        private string _Material;

        public float Weight
        {
            get
            {
                return _Weight;
            }

            set
            {
                _Weight = value;
            }
        }

        public string Material
        {
            get
            {
                return _Material;
            }

            set
            {
                _Material = value;
            }
        }

        public override void EditDetails()
        {
 
        }
    }
}
