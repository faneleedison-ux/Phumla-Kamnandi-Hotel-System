using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project.Business
{
    public class Customer
    {
        #region data members
        private int ID_Customer;
        private string Name_Customer;
        private string Address_Customer;        // private attributes of a Customer
        private string Suburb_Customer;
        private string PostalCode_Customer;
        private string Reservation_Notes;

        #endregion

        #region Accessor and Mutator method
        public int CustID
        {
            get { return ID_Customer; }
            set { ID_Customer = value; }
        }
        public string CustName
        {
            get { return Name_Customer; }
            set { Name_Customer = value; }
        }
        public string CustAddress
        {
            get { return Address_Customer; }
            set { Address_Customer = value; }
        }
        public string Suburb
        {
            get { return Suburb_Customer; }
            set { Suburb_Customer = value; }
        }
        public string PostalCode
        {
            get { return  PostalCode_Customer; }
            set { PostalCode_Customer = value; }
        }
        public string ResNotes
        {
            get { return Reservation_Notes; }
            set { Reservation_Notes = value; }
        }

        #endregion

        #region Constructor
        public Customer()
        {

        }

        public Customer(int id, string name, string address, string suburb, string postalcode)
        {
            ID_Customer = id;
            Name_Customer = name;
            Address_Customer = address;
            Suburb_Customer = suburb;
            PostalCode_Customer = postalcode;
        }

        public Customer(int id, string name, string address, string suburb, string postalcode, string resnotes)
        {
            ID_Customer = id;
            Name_Customer = name;
            Address_Customer = address;
            Suburb_Customer = suburb;
            PostalCode_Customer = postalcode;
            Reservation_Notes= resnotes;
        }
        #endregion


    }
}
