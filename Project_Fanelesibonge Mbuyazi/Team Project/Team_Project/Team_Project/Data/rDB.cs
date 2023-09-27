using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Team_Project.Properties;
using System.Data;
using System.Windows.Forms;

namespace Team_Project.Data
{
    public class rDB
    {
        #region Variable declaration
        //Settings.Default object is used to select the correct connection string and link the database
        private string strConn = Settings.Default.PhumaKamnandiConnectionString;
        protected SqlConnection cnMain;
        protected DataSet dsMain;
        protected SqlDataAdapter daMain;

        public enum Database_Operations
        {
            add,
            delete,
            edit
        }
        #endregion

        #region Constructor
        public rDB()
        {
            try
            {
                //Open a connection & create a new dataset object to store information
                cnMain = new SqlConnection(strConn);
                dsMain = new DataSet();
            }
            catch (SystemException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error");       // importing the necessary library to use MessageBox tool
                return;
            }
        }

        #endregion

        #region Update the DateSet
        public void FillDataSet(string aSQLstring, string aTable)
        {
            //fills dataset fresh from the db for a specific table and with a specific Query
            try
            {
                daMain = new SqlDataAdapter(aSQLstring, cnMain);
                cnMain.Open();
                //dsMain.Clear();
                daMain.Fill(dsMain, aTable);
                cnMain.Close();
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
            }
        }

        #endregion

        #region Update the data source 
        protected bool UpdateDataSource(string sqlLocal, string table)
        {
            bool success;
            try
            {
                cnMain.Open();
                daMain.Update(dsMain, table);   // opening, updating and closing dataset 
                cnMain.Close();
                FillDataSet(sqlLocal, table);       // invoking FillDataSet method to repopulate dataset
                success = true;
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
                success = false;        // throw in case of Exception
            }
            finally
            {
            }
            return success;
        }
        #endregion
    }
}
