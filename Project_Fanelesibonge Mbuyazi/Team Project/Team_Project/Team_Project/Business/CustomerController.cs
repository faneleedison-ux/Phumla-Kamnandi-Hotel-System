using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Project.Data;
using Team_Project.Business;
using System.Collections.ObjectModel;

namespace Team_Project.Business
{
    public class CustomerController
    {
        #region Data Members
        CustomerDB customerDB;
        Collection<Customer> customers;
        #endregion

        #region Properties
        public Collection<Customer> ALLcustomers
        {
            get { return customers; }
        }
        #endregion

        #region Constructor
        public CustomerController()
        {
            customerDB = new CustomerDB();
            customers = customerDB.ALLcustomers;

        }
        #endregion

        #region Database Comm
        public void Data_Maintenance(Customer aCust, rDB.Database_Operations opp)
        {
            //perform a given database operation to the dataset in memory

            int index = 0;
            customerDB.DataSetChange(aCust, opp);

            switch (opp)
            {
                case rDB.Database_Operations.add:
                    customers.Add(aCust);
                    break;
                case rDB.Database_Operations.edit:
                    index = FindIndex(aCust);
                    customers[index]= aCust;
                    break;

            }
        }


        public bool FinalizeChanges()
        {
           
            return customerDB.Update_DataSource();
        }
        #endregion

        #region searching Methods 

        public Customer FindBy_ID(string id)
        {
            int index = 0;
            bool found = (customers[index].CustID.ToString()== id);
            Customer aCust = new Customer();

            while (index < customers.Count && found == false)
            {
                aCust = customers[index];

                if (aCust.CustID.ToString() == id)
                {
                    found = true;
                }
                else
                { index++; }
            }

            return aCust;

            
        }

        public int FindByName(string name)
        {
            int counter = 0;
            bool found = false;
            int id = 0;
            Customer aCust = new Customer();

            found = false ;

            while (found != true && counter < customers.Count - 1)
            {
                aCust = customers[counter];

                found = (aCust.CustID == customers[counter].CustID);


                if (found == true)
                {
                    id = aCust.CustID ;
                }
                else { counter++;   }
            }

            return id;


        }

        public Customer Find(string ID)
        {
            int index = 0;
            bool found = (customers[index].CustID.ToString() == ID);  //checks if entry is first customer
            int count = customers.Count;
            while (!(found) && (index < customers.Count - 1))  
            {
                index++;
                found = (customers[index].CustID.ToString() == ID);   
            }
            return customers[index];  // correct Customer from collection
        }

        public int FindIndex(Customer aCust)              // method that returns index of certain object in collection
        {
            int counter = 0;
            bool found = false;
            found = (aCust.CustID == customers[counter].CustID);

            while (!(found) && (counter < customers.Count - 1))
            {
                counter++;
                found = (aCust.CustID == customers[counter].CustID);
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

    }
}
