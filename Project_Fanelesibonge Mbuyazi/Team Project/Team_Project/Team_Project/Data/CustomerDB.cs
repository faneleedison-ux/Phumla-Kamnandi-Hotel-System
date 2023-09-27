using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Team_Project.Business;
using System.Data;
using System.Data.SqlClient;

namespace Team_Project.Data
{
    class CustomerDB : rDB
    {
        #region Data Members
        private string tbl_name = "Customers";
        private string sql_local = "SELECT * FROM Customers";
        //public Collection<Customer> customers = new Collection<Customer>();     // collection to store the customers from the customers table
        public Collection<Customer> customers;

        #endregion

        #region Property Method: Collection
        public Collection<Customer> ALLcustomers
        {
            get
            {
                return customers;
            }
        }
        #endregion

        #region Constructors
        public CustomerDB() : base()
        {
            customers = new Collection<Customer>();
            FillDataSet(sql_local, tbl_name);
            Add_To_Collection(tbl_name);
        }

        #endregion

        #region Utility Methods
        public DataSet Get_DataSet()
        {
            return dsMain;
        }

        private void Add_To_Collection(string tbl_val)
        {
            DataRow myRow = null;
            Customer myCustomer;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[tbl_val].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    myCustomer = new Customer();
                    myCustomer.CustID = Convert.ToInt32(myRow["CustomerID"]);
                    myCustomer.CustName = Convert.ToString(myRow["CustomerName"]).TrimEnd();
                    myCustomer.CustAddress = Convert.ToString(myRow["CustomerAddress"]).TrimEnd();
                    myCustomer.Suburb = Convert.ToString(myRow["Suburb"]).TrimEnd();
                    myCustomer.PostalCode = Convert.ToString(myRow["PostalCode"]).TrimEnd();
                    myCustomer.ResNotes = Convert.ToString(myRow["ReservationNotes"]).TrimEnd();

                    customers.Add(myCustomer);
                }
            }
        }

        private void Fill_Row(DataRow aRow, Customer aCust, rDB.Database_Operations opp)
        {
            if (opp == rDB.Database_Operations.add)
            {
                aRow["CustomerID"] = aCust.CustID;
            }

            aRow["CustomerName"] = aCust.CustName;
            aRow["CustomerAddress"] = aCust.CustAddress;
            aRow["Suburb"] = aCust.Suburb;
            aRow["PostalCode"] = aCust.PostalCode;
            aRow["ReservationNotes"] = aCust.ResNotes;

        }

        private int FindRow(Customer aCust, string tbl_val)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[tbl_val].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    if (aCust.CustID.ToString() == Convert.ToString(dsMain.Tables[tbl_val].Rows[rowIndex]["CustomerID"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex++;
            }
            return returnValue;
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Customer aCust, rDB.Database_Operations opp)
            {
            DataRow aRow = null;
            string dataTable = tbl_name;

            switch (opp)
            {
                case rDB.Database_Operations.add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    Fill_Row(aRow, aCust, opp);
                    dsMain.Tables[dataTable].Rows.Add(aRow);            //Add customer record to the dataset
                    break;

                case rDB.Database_Operations.edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aCust, dataTable)];
                    Fill_Row(aRow, aCust, opp);
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database

        private void Build_INSERT_Parameters()
        {
            // inserting relevant attributes of aCust to the sqlAdapter 

            SqlParameter sql_param = default(SqlParameter);

            sql_param = new SqlParameter("@CustomerID", SqlDbType.Int, 5, "CustomerID");
            daMain.InsertCommand.Parameters.Add(sql_param);             //Add the parameter to the Parameters collection.

            sql_param = new SqlParameter("@CustomerName", SqlDbType.NVarChar, 30, "CustomerName");
            daMain.InsertCommand.Parameters.Add(sql_param);

            sql_param = new SqlParameter("@CustomerAddress", SqlDbType.NVarChar, 50, "CustomerAddress");
            daMain.InsertCommand.Parameters.Add(sql_param);

            sql_param = new SqlParameter("@Suburb", SqlDbType.NVarChar, 20, "Suburb");
            daMain.InsertCommand.Parameters.Add(sql_param);

            sql_param = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 4, "PostalCode");
            daMain.InsertCommand.Parameters.Add(sql_param);

            sql_param = new SqlParameter("@ReservationNotes", SqlDbType.NVarChar, 250, "ReservationNotes");
            daMain.InsertCommand.Parameters.Add(sql_param);
        }

        private void Build_UPDATE_Parameters()
        {
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@CustomerName", SqlDbType.NVarChar, 30, "CustomerName");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CustomerAddress", SqlDbType.NVarChar, 50, "CustomerAddress");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Suburb", SqlDbType.NVarChar, 20, "Suburb");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 4, "PostalCode");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ReservationNotes", SqlDbType.NVarChar, 250, "ReservationNotes");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "CustomerID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Create_INSERT_Command()
        {
            //Create the command that must be used to insert values into the Books table..
            daMain.InsertCommand = new SqlCommand("INSERT into Customers (CustomerID, CustomerName, CustomerAddress, Suburb, PostalCode, ReservationNotes) VALUES (@CustomerID, @CustomerName, @CustomerAddress, @Suburb, @PostalCode, @ReservationNotes)", cnMain);
            Build_INSERT_Parameters();
        }

        private void Create_UPDATE_Command()
        {
            daMain.UpdateCommand = new SqlCommand("UPDATE Customers SET CustomerName =@CustomerName, CustomerAddress =@CustomerAddress, Suburb =@Suburb, PostalCode =@PostalCode, ReservationNotes =@ReservationNotes " + "WHERE CustomerID = @Original_ID", cnMain);
            Build_UPDATE_Parameters();
        }

        public bool Update_DataSource()
        {
            Create_INSERT_Command();
            Create_UPDATE_Command();
            bool is_success = UpdateDataSource(sql_local, tbl_name);
            return is_success;
        }

        #endregion
    }
}
        
