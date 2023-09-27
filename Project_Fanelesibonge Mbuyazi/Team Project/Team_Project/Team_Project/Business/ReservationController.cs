using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Project.Business;
using Team_Project.Data;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace Team_Project.Business
{
    public class ReservationController
    {
        #region Data Members
        ReservationsDB reservationDB;
        Collection<Reservation> reservations;
        #endregion

        #region Properties

        public Collection<Reservation> ALLreservation
        {
            get
            {
                return reservations;

            }
        }

        #endregion

        #region Constructor
        public ReservationController()
        {
            reservationDB = new ReservationsDB();
            reservations = reservationDB.ALLreservation;

        }
        #endregion

        #region Database Comm
        public void Data_Maintenance(Reservation cRes, rDB.Database_Operations opp)
        {
            //perform a given database operation to the dataset in memory

            int index = 0;
            reservationDB.DataSetChange(cRes, opp);

            switch (opp)
            {
                case rDB.Database_Operations.add:
                    reservations.Add(cRes);
                    break;
                case rDB.Database_Operations.edit:
                    index = FindIndex(cRes);
                    reservations[index] = cRes;
                    break;
                case rDB.Database_Operations.delete:
                    index = FindIndex(cRes);
                    reservations.RemoveAt(index);
                    break;
            }
        }


        public bool FinalizeChanges()
        {
            
            return reservationDB.Update_DataSource();
        }
        #endregion

        #region  Searching Methods


        public Reservation Find(string ID)
        {
            int index = 0;
            bool found = (reservations[index].ResID.ToString() == ID);
            int count = reservations.Count;
            while (!(found) && (index < reservations.Count - 1))
            {
                index++;
                found = (reservations[index].ResID.ToString() == ID);
            }
            return reservations[index];
        }

        public int FindIndex(Reservation cRes)              // method that returns index of certain object in collection
        {
            int counter = 0;
            bool found = false;
            found = (cRes.ResID == reservations[counter].ResID);

            while (!(found) && (counter < reservations.Count - 1))
            {
                counter++;
                found = (cRes.ResID == reservations[counter].ResID);
            }

            if (found)
            {
                return counter;
            }
            else
            {
                return -1;
            }
        }
        #endregion


        #region deposit methods 

        public string dep_CustID(string custID)
        {
            Reservation curr_res = new Reservation();
            int counter = 0;    
            bool found = false;
            string result = "";

            while (counter < reservations.Count && found != true)
            {
                curr_res = reservations[counter];
                
                if (curr_res.FKCustomerID.ToString() == custID)     // determines whether customer is found or not
                { found = true; }
                else { counter++; }

            }

            if (found)
            {
                result = curr_res.ResID.ToString() + " || " + curr_res.FKCustomerID.ToString() + " || " + curr_res.Paid.ToString();
            }

            return result;
        }


        public string dep_ResID(string resID)
        {
            Reservation curr_res = new Reservation();
            int counter = 0;
            bool found = false;
            string result = "";

            while (counter < reservations.Count && found != true)
            {
                curr_res = reservations[counter];       // sets the reservation object to each instance in the collection

                if (curr_res.ResID.ToString() == resID)     
                { found = true; }
                else { counter++; }

            }

            if (found == true)
            {
                result = curr_res.ResID.ToString() + " || " + curr_res.FKCustomerID.ToString() + " || " + curr_res.Paid.ToString();
            }

            return result;
        }

        #endregion
    }


}
