using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Team_Project.Business;
using System.Data;          // imported necessary namespaces
using System.Data.SqlClient;

namespace Team_Project.Data
{
    class ReservationsDB : rDB      // inhertis from rDB class
    {
        #region data members 
        private string rtbl_name = "Reservations";
        private string rsql_local = "SELECT * FROM Reservations";
        //public Collection<Reservation> reservations  = new Collection<Reservation>();
        public Collection<Reservation> reservations;
        #endregion

        #region Property Method: Collection
        public Collection<Reservation> ALLreservation
        {
            get
            {
                return reservations;
            }
        }
        #endregion

        #region Constructors
        public ReservationsDB() : base()
        {
            reservations = new Collection<Reservation>();
            FillDataSet(rsql_local, rtbl_name);
            Add_To_Collection(rtbl_name);
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
            Reservation cReservation;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[tbl_val].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    cReservation = new Reservation();
                    cReservation.ResID = Convert.ToInt32(myRow["ReservationID"]);
                    cReservation.bNumber = Convert.ToString(myRow["BookingNumber"]).TrimEnd();
                    cReservation.Entry = Convert.ToDateTime(myRow["EntryDate"]);
                    cReservation.Exit = Convert.ToDateTime(myRow["ExitDate"]);
                    cReservation.Paid = Convert.ToBoolean(myRow["DepositPaid"]);
                    cReservation.FKCustomerID = Convert.ToInt32(myRow["CustomerID"]);
                    
                    reservations.Add(cReservation);
                }
            }
        }

        private void Fill_Row(DataRow aRow, Reservation cRes, rDB.Database_Operations opp)
        {
            if (opp == rDB.Database_Operations.add)
            {
                aRow["ReservationID"] = cRes.ResID.ToString();
                aRow["CustomerID"] = cRes.FKCustomerID.ToString();
            }

            aRow["BookingNumber"] = cRes.bNumber.ToString();
            aRow["EntryDate"] = cRes.Entry.ToString("g");
            aRow["ExitDate"] = cRes.Exit.ToString("g");
            aRow["DepositPaid"] = cRes.Paid.ToString();

        }

        private int FindRow(Reservation cRes, string tbl)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[tbl].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    if ( cRes.ResID.ToString() == Convert.ToString(dsMain.Tables[tbl].Rows[rowIndex]["ReservationID"]))
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
        public void DataSetChange(Reservation cRes, rDB.Database_Operations opp)
        {
            DataRow aRow = null;
            string dataTable = rtbl_name;
            switch(opp)
            {
                case rDB.Database_Operations.add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    Fill_Row(aRow, cRes, opp);
                    dsMain.Tables[dataTable].Rows.Add(aRow); //Add to the dataset
                    break;
                case rDB.Database_Operations.edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(cRes, dataTable)];
                    Fill_Row(aRow, cRes, opp);
                    break;
                case rDB.Database_Operations.delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(cRes, dataTable)]; // Issue with canceling reservation. Gives index error that it cant be found
                    aRow.Delete();
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database

        private void Build_INSERTParameters()
        {

            SqlParameter sql_param = default(SqlParameter);

            sql_param = new SqlParameter("@ReservationID", SqlDbType.Int, 5, "ReservationID");
            daMain.InsertCommand.Parameters.Add(sql_param);             //Add the parameter to the Parameters collection.

            sql_param = new SqlParameter("@BookingNumber", SqlDbType.NVarChar, 5, "BookingNumber");
            daMain.InsertCommand.Parameters.Add(sql_param);

            sql_param = new SqlParameter("@EntryDate", SqlDbType.DateTime, 10, "EntryDate");
            daMain.InsertCommand.Parameters.Add(sql_param);

            sql_param = new SqlParameter("@ExitDate", SqlDbType.DateTime, 10, "ExitDate");
            daMain.InsertCommand.Parameters.Add(sql_param);

            sql_param = new SqlParameter("@DepositPaid", SqlDbType.Bit, 5, "DepositPaid");
            daMain.InsertCommand.Parameters.Add(sql_param);

            sql_param = new SqlParameter("@CustomerID", SqlDbType.Int, 5, "CustomerID");
            daMain.InsertCommand.Parameters.Add(sql_param);
        }

        private void Build_UPDATE_Parameters()
        {

            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@BookingNumber", SqlDbType.VarChar, 15, "BookingNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@EntryDate", SqlDbType.DateTime, 6, "EntryDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);


            param = new SqlParameter("@ExitDate", SqlDbType.DateTime, 6, "ExitDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@DepositPaid", SqlDbType.Bit, 6, "DepositPaid");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);


            param = new SqlParameter("@CustomerID", SqlDbType.Int, 5, "CustomerID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Original_ID", SqlDbType.Int, 5, "ReservationID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Create_INSERTCommand()
        {
            //Create the command that must be used to insert values into the Books table..
            daMain.InsertCommand = new SqlCommand("INSERT into Reservations (ReservationID, BookingNumber, EntryDate, ExitDate, DepositPaid, CustomerID) VALUES(@ReservationID, @BookingNumber, @EntryDate, @ExitDate, @DepositPaid, @CustomerID)", cnMain);
            Build_INSERTParameters();
        }

        private void Create_UPDATE_Command()
        {
            daMain.UpdateCommand = new SqlCommand("UPDATE Reservations SET BookingNumber = @BookingNumber, EntryDate = @EntryDate, ExitDate = @ExitDate, DepositPaid = @DepositPaid, CustomerID = @CustomerID " + "WHERE ReservationID = @Original_ID", cnMain);
            Build_UPDATE_Parameters();

        }

        private void Build_DELETE_Parameters()
        {
            SqlParameter param;
            param = new SqlParameter("@ReservationID", SqlDbType.Int, 5, "ReservationID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }

        private string Create_DELETE_Command()
        {
            string errorString = null;
            daMain.DeleteCommand = new SqlCommand("DELETE FROM  Reservations WHERE ReservationID = @ReservationID", cnMain);
            try
            {
                Build_DELETE_Parameters();
            }
            catch(Exception errObj)
            {
                errorString = errObj.Message + "  " + errObj.StackTrace;
            }
            return errorString;
        }

        public bool Update_DataSource()
        {
            Create_INSERTCommand();
            Create_UPDATE_Command();
            Create_DELETE_Command();
            bool is_success = UpdateDataSource(rsql_local, rtbl_name);
            return is_success;
        }

        

        #endregion


    }
}
