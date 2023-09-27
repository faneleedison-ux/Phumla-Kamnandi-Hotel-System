using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project.Business
{
    public class Reservation
    {
        #region Data Members
        private int ReservationID;
        private string BookingNumber;
        private DateTime Entry_Date;        // private attributes of the reservation object
        private DateTime Exit_Date;
        private int FK_CustomerID;
        private bool is_Paid;


        #endregion

        #region Methods
        public int ResID
        {
            get { return ReservationID; }
            set {  ReservationID = value; }
        }
        public String bNumber
        {
            get { return BookingNumber; }
            set { BookingNumber = value; }
        }
        public DateTime Entry
        {
            get { return Entry_Date; }
            set { Entry_Date = value; }
        }
        public DateTime Exit
        {
            get { return Exit_Date; }
            set { Exit_Date = value; }
        }

        public bool Paid
        {
            get { return is_Paid; }
            set { is_Paid = value; }
        }
        
        public int FKCustomerID

        {
            get { return FK_CustomerID; }
            set { FK_CustomerID = value; }
        }

        public string ShowEntry(Reservation cRes)
        {
            return string.Format("{0} : {1} : {2} ",cRes.ReservationID.ToString(), cRes.FKCustomerID.ToString(), cRes.is_Paid.ToString()); 
        }
        #endregion

        #region Constructor
        public Reservation()
        {

        }

        public Reservation(int resID, string bNum, DateTime entry, DateTime exit,int fkCust, Boolean paid)
        {
            ReservationID = resID;
            BookingNumber = bNum;
            Entry_Date = entry;
            Exit_Date = exit;
            FK_CustomerID = fkCust;
            is_Paid = paid;
        }
        #endregion
    }
}
