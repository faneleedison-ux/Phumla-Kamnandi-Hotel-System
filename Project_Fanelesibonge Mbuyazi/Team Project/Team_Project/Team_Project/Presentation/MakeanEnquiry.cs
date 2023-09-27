using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team_Project.Business;
using Team_Project.Data;
using System.Collections.ObjectModel;

namespace Team_Project.Presentation
{
    public partial class MakeanEnquiry : Form
    {
        public MakeanEnquiry()
        {
            InitializeComponent();
        }

        HomeScreen HomeScreen;
        Collection<Reservation> reservation_Collection = new Collection<Reservation>();
        ReservationsDB resDB = new ReservationsDB();
        ReservationController resController = new ReservationController();
        Reservation res = new Reservation();

        #region deposit identifier 
        public void Determine_Deposit()
        {
            Reservation curr_res = new Reservation();

            if ((CustomerID_txt.Text.Length > 0 || ReservationID_txt.Text.Length > 0) && !(CustomerID_txt.Text.Length > 0 && ReservationID_txt.Text.Length > 0))        //ensures a single textbox is populated
            {
                if (CustomerID_txt.Text.Length > 0)
                {
                    if (resController.dep_CustID(CustomerID_txt.Text) != "")
                    {
                        MessageBox.Show(resController.dep_CustID(CustomerID_txt.Text), "DepID || CustID || Deposit Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (resController.dep_CustID(CustomerID_txt.Text) == "")
                    {
                        MessageBox.Show("Record not found", "No Record:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (ReservationID_txt.Text.Length > 0)
                {
                    if (resController.dep_ResID(ReservationID_txt.Text) != "")
                    {

                        MessageBox.Show(resController.dep_ResID(ReservationID_txt.Text), "DepID || CustID || Deposit Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Record not found", "Incorrect Information:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else { MessageBox.Show("Please enter a single record to search", "Incorrect Information:", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

    
        #endregion

        private void cb_Return_Click(object sender, EventArgs e)
        {
            HomeScreen = new HomeScreen();
            this.Hide();
            HomeScreen.ShowDialog();
        }


        #region ListView Set Up
        private void MakeanEnquiry_Load(object sender, EventArgs e)
        {
            Reservations_lstvw.View = View.Details;
            ResListView();

        }

        public void ResListView()
        {
            ListViewItem resDetails;
            reservation_Collection = null;
            Reservations_lstvw.Clear();
            

            Reservations_lstvw.Columns.Insert(0, "ReservationID", 110, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(1, "BookingNumber", 105, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(2, "EntryDate", 120, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(3, "ExitDate", 120, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(4, "DepositPaid", 120, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(5, "CustomerID", 110, HorizontalAlignment.Left);

            reservation_Collection = resDB.ALLreservation;
            

            foreach (Reservation res in reservation_Collection)
            {
                resDetails = new ListViewItem();
                resDetails.Text = res.ResID.ToString();
                resDetails.SubItems.Add(res.bNumber.ToString());
                resDetails.SubItems.Add(res.Entry.ToString());
                resDetails.SubItems.Add(res.Exit.ToString());
                resDetails.SubItems.Add(res.Paid.ToString());
                resDetails.SubItems.Add(res.FKCustomerID.ToString());

                Reservations_lstvw.Items.Add(resDetails);
            }


            Reservations_lstvw.Refresh();
            Reservations_lstvw.GridLines = true;
        }


        #endregion

        private void cb_search_Click(object sender, EventArgs e)
        {
            Determine_Deposit();
            CustomerID_txt.Clear();
            ReservationID_txt.Clear();
        }

        private void lblHeading_Click(object sender, EventArgs e)
        {
            Reservation res = new Reservation();

            ReservationController resControl = new ReservationController();

            MessageBox.Show(resControl.dep_CustID(CustomerID_txt.Text));
        }
    }
}
