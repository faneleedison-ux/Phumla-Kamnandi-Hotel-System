using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team_Project.Business;
using Team_Project.Data;

namespace Team_Project.Presentation
{
    public partial class CancelBooking : Form
    {
        #region Constructor
        public CancelBooking(ReservationController reservationController)
        {
            InitializeComponent();
            ReservationController = reservationController;
            this.Load += CancelBooking_Load;
            this.Activated += CancelBooking_Activated;
        }
        #endregion

        #region Form Events
        private void CancelBooking_Activated(object sender, EventArgs e)
        {
            Reservations_lstvw.View = View.Details;
            ResListView();
        }

        private void CancelBooking_Load(object sender, EventArgs e)
        {
            Reservations_lstvw.View = View.Details;
        }
        #endregion

        #region Variables
        HomeScreen HomeScreen;
        ReservationController ReservationController;
        Collection<Reservation> reservation_Collection;
        Reservation reservation;
        //ReservationsDB resDB = new ReservationsDB();
        #endregion

        #region Menu ToolStrip
        private void returnToHomeScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeScreen = new HomeScreen();
            HomeScreen.ShowDialog();
        }
        #endregion

        #region Click Events
        private void cb_reservartion_Click(object sender, EventArgs e)
        {
            if (tb_reservation.Text.Length == 0 || tb_reservation.Text == "")
            {
                MessageBox.Show("Enter a Customer ID");
            }
            else
            {
                String resID = tb_reservation.Text;
                Search_Reservation(resID);
            }
        }

        private void cb_Cancel_Click(object sender, EventArgs e)
        {
            reservation = ReservationController.Find(tb_reservation.Text.Trim());
            ReservationController.Data_Maintenance(reservation, rDB.Database_Operations.delete);
            ReservationController.FinalizeChanges();
            ResListView();
            ClearTextBoxes();
        }

        private void cb_Reset_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            ResListView();
        }

        #endregion

        #region Utility Methods
        private void ClearTextBoxes()
        {
            tb_reservation.Text = "";
        }

        private void Populate_IDBox(Reservation reservation)
        {
            tb_reservation.Text = reservation.ResID.ToString();
        }
        #endregion

        #region Listview Setup

        private void ResListView()
        {
            ListViewItem resDetails;
            reservation_Collection = null;
            Reservations_lstvw.Clear();

            Reservations_lstvw.Columns.Insert(0, "Reservation ID", 110, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(1, "Entry Date", 120, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(2, "Exit Date", 120, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(3, "Paid", 120, HorizontalAlignment.Left);

            reservation_Collection = ReservationController.ALLreservation;

            foreach (Reservation res in reservation_Collection)
            {
                resDetails = new ListViewItem();
                resDetails.Text = res.ResID.ToString();
                resDetails.SubItems.Add(res.Entry.ToString());
                resDetails.SubItems.Add(res.Exit.ToString());
                resDetails.SubItems.Add(res.Paid.ToString());

                Reservations_lstvw.Items.Add(resDetails);
            }

            Reservations_lstvw.Refresh();
            Reservations_lstvw.GridLines = true;
        }

        #endregion

        #region Listview Selected Item
        private void Reservations_lstvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ReservationController resController = new ReservationController();
            //Reservation aRes = new Reservation();

            if (Reservations_lstvw.SelectedItems.Count > 0)
            {
                reservation = ReservationController.Find(Reservations_lstvw.SelectedItems[0].Text);

                Populate_IDBox(reservation);
                Reservation_listview_Searched_Item(reservation);
            }
        }

        #endregion

        #region Search Methods
        private void Search_Reservation(String _reservation)
        {
            //ReservationController resController = new ReservationController();
            //Reservation aRes = new Reservation();

            reservation = ReservationController.Find(_reservation);
            Reservation_listview_Searched_Item(reservation);
        }

        private void Reservation_listview_Searched_Item(Reservation res)
        {
            ListViewItem resDetails;
            reservation_Collection = null;
            Reservations_lstvw.Clear();

            Reservations_lstvw.Columns.Insert(0, "Reservation ID", 110, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(1, "Entry Date", 120, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(2, "Exit Date", 120, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(3, "Paid", 120, HorizontalAlignment.Left);

            resDetails = new ListViewItem();
            resDetails.Text = res.ResID.ToString();
            resDetails.SubItems.Add(res.Entry.ToString());
            resDetails.SubItems.Add(res.Exit.ToString());
            resDetails.SubItems.Add(res.Paid.ToString());

            Reservations_lstvw.Items.Add(resDetails);

            Reservations_lstvw.Refresh();
            Reservations_lstvw.GridLines = true;
        }

        #endregion

        
    }
}
