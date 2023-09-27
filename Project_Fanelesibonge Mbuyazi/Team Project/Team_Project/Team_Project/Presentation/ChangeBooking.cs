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
    public partial class ChangeBooking : Form
    {

        #region Constructor
        public ChangeBooking(ReservationController reservationController, CustomerController customerController)
        {
            InitializeComponent();
            resController = reservationController;
            custController = customerController;
            this.Load += ChangeBooking_Load;
            this.Activated += ChangeBooking_Activated;
        }
        #endregion

        #region Form Events
        private void ChangeBooking_Activated(object sender, EventArgs e)
        {
            Reservations_lstvw.View = View.Details;
            Customer_listvw.View = View.Details;
            ResListView();
            CustomerListView();
        }

        private void ChangeBooking_Load(object sender, EventArgs e)
        {
            Reservations_lstvw.View = View.Details;
            Customer_listvw.View = View.Details;
        }
        #endregion

        #region Variables
        HomeScreen HomeScreen;
        Collection<Reservation> reservation_Collection;
        Collection<Customer> customer_Collection;
        //ReservationsDB resDB = new ReservationsDB();
        //CustomerDB custDB = new CustomerDB();
        ReservationController resController;
        CustomerController custController;
        Reservation reservation;
        Customer customer;
        #endregion

        #region Event Click Methods
        private void cb_HomeScreen_Click(object sender, EventArgs e)
        {
            HomeScreen = new HomeScreen();
            this.Hide();
            HomeScreen.ShowDialog();
        }

        private void cb_entry_Click(object sender, EventArgs e)
        {
            if(tb_entry.Text.Length==0 || tb_entry.Text == "")
            {
                MessageBox.Show("Enter a Customer ID");
            }
            else
            {
                String custID = tb_entry.Text;
                Search_Customer(custID);
            }
        }

        private void cb_reservartion_Click(object sender, EventArgs e)
        {
            if(tb_reservation.Text.Length==0 || tb_reservation.Text == "")
            {
                MessageBox.Show("Enter a Reservation ID");
            }
            else
            {
                String resID = tb_reservation.Text;
                Search_Reservation(resID);
            }
        }

        private void cb_Confirm_Click(object sender, EventArgs e)
        {
            if((tb_entry.Text!="" || tb_entry.Text.Length!=0) && (CustName_txt.Text=="" || CustAddress_txt.Text=="" || CustPOBox_txt.Text=="" || CustsSuburb_txt.Text=="" || CustName_txt.Text.Length == 0 || CustAddress_txt.Text.Length == 0 || CustPOBox_txt.Text.Length == 0 || CustsSuburb_txt.Text.Length == 0))
            {
                MessageBox.Show("Customer Fields Cannot Be Empty");
            }/*
            else if ((tb_reservation.Text!="" || tb_reservation.Text.Length!=0) && (dateTimePickerEntry.Value ==  || ExitDate_txt.Text == "" || EntryDate_txt.Text.Length == 0 || ExitDate_txt.Text.Length == 0))
            {
                MessageBox.Show("Reservation Fields Cannot Be Empty");
            }
            else if ((tb_entry.Text == "" || tb_entry.Text.Length == 0) && !(CustName_txt.Text == "" || CustAddress_txt.Text == "" || CustPOBox_txt.Text == "" || CustsSuburb_txt.Text == "" || CustName_txt.Text.Length == 0 || CustAddress_txt.Text.Length == 0 || CustPOBox_txt.Text.Length == 0 || CustsSuburb_txt.Text.Length == 0))
            {
                MessageBox.Show("Search Customer ID");
            }
            else if ((tb_reservation.Text == "" || tb_reservation.Text.Length == 0) && !(EntryDate_txt.Text == "" || ExitDate_txt.Text == "" || EntryDate_txt.Text.Length == 0 || ExitDate_txt.Text.Length == 0))
            {
                MessageBox.Show("Search reservation ID");
            }*/
            else
            {
                if ((tb_entry.Text != "" || tb_entry.Text.Length != 0) && (tb_reservation.Text != "" || tb_reservation.Text.Length != 0))
                {
                    //Check if FK match
                    Confirm_Change_Customer();
                    Confirm_Change_Reservation();
                }
                else if(tb_entry.Text!="" || tb_entry.Text.Length != 0)
                {
                    Confirm_Change_Customer();
                }
                else if(tb_reservation.Text!="" || tb_reservation.Text.Length != 0)
                {
                    Confirm_Change_Reservation();
                }
            }
        }

        private void cb1_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
        #endregion

        #region Utility Methods
        private void ClearTextBoxes()
        {
            CustName_txt.Text = "";
            CustAddress_txt.Text = "";
            CustPOBox_txt.Text = "";
            CustsSuburb_txt.Text = "";
            dateTimePickerEntry.Text = "";
            dateTimePickerExit.Text = "";
            tb_entry.Text = "";
            tb_reservation.Text = "";
        }

        private void Populate_Customer_boxes(Customer customer)
        {
            tb_entry.Text = customer.CustID.ToString();
            CustName_txt.Text = customer.CustName;
            CustAddress_txt.Text = customer.CustAddress;
            CustPOBox_txt.Text = customer.PostalCode;
            CustsSuburb_txt.Text = customer.Suburb;
        }

        private void Populate_Reservation_boxes(Reservation reservation)
        {
            tb_reservation.Text = reservation.ResID.ToString();
            dateTimePickerEntry.Value = reservation.Entry;
            dateTimePickerExit.Value = reservation.Exit;

        }

        private void Confirm_Change_Reservation()
        {
            //ReservationController resController = new ReservationController();
            //Reservation aRes = new Reservation();

            Reservation aRes = resController.Find(tb_reservation.Text);

            aRes.Entry = dateTimePickerEntry.Value;
            aRes.Exit = dateTimePickerExit.Value;

            resController.Data_Maintenance(aRes, rDB.Database_Operations.edit);
            resController.FinalizeChanges();

            ClearTextBoxes();
            Reservations_lstvw.Refresh();
            Reservations_lstvw.GridLines = true;
        }

        private void Confirm_Change_Customer()
        {
            //CustomerController custController = new CustomerController();
            //Customer aCust = new Customer();

            PopulateCustomer();
            //Customer aCust = custController.Find(tb_entry.Text);

            custController.Data_Maintenance(customer, rDB.Database_Operations.edit);
            custController.FinalizeChanges();

            ClearTextBoxes();
            Customer_listvw.Refresh();
            Customer_listvw.GridLines = true;
        }

        public void PopulateCustomer()
        {
            customer = new Customer(Convert.ToInt32(tb_entry.Text), CustName_txt.Text, CustAddress_txt.Text, CustsSuburb_txt.Text, CustPOBox_txt.Text);
        }

        #endregion

        #region Listview Setup
        public void ResListView()
        {
            ListViewItem resDetails;
            reservation_Collection = null;
            Reservations_lstvw.Clear();

            Reservations_lstvw.Columns.Insert(0, "Reservation ID", 110, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(1, "Entry Date", 120, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(2, "Exit Date", 120, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(3, "Paid", 120, HorizontalAlignment.Left);

            reservation_Collection = resController.ALLreservation;

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

        public void CustomerListView()
        {
            ListViewItem custDetails;
            customer_Collection = null;
            Customer_listvw.Clear();


            Customer_listvw.Columns.Insert(0, "Customer ID", 105, HorizontalAlignment.Left);
            Customer_listvw.Columns.Insert(1, "Custmoer Full Name", 120, HorizontalAlignment.Left);
            Customer_listvw.Columns.Insert(2, "Address", 120, HorizontalAlignment.Left);
            Customer_listvw.Columns.Insert(3, "P.O Box", 120, HorizontalAlignment.Left);
            Customer_listvw.Columns.Insert(4, "Suburb", 120, HorizontalAlignment.Left);

            customer_Collection = custController.ALLcustomers;

            foreach (Customer cust in customer_Collection)
            {
                custDetails = new ListViewItem();
                custDetails.Text = cust.CustID.ToString();
                custDetails.SubItems.Add(cust.CustName.ToString());
                custDetails.SubItems.Add(cust.CustAddress.ToString());
                custDetails.SubItems.Add(cust.PostalCode.ToString());
                custDetails.SubItems.Add(cust.Suburb.ToString());

                Customer_listvw.Items.Add(custDetails);
            }

            Customer_listvw.Refresh();
            Customer_listvw.GridLines = true;
        }

        #endregion

        #region Listview Selected Item
        private void Reservations_lstvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ReservationController resController = new ReservationController();
            //Reservation aRes = new Reservation();

            if(Reservations_lstvw.SelectedItems.Count > 0)
            {
                reservation = resController.Find(Reservations_lstvw.SelectedItems[0].Text);

                Populate_Reservation_boxes(reservation);
            }
        }

        private void Customer_listvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CustomerController custController = new CustomerController();
            //Customer aCust = new Customer();


            if (Customer_listvw.SelectedItems.Count > 0)   // if you selected an item 
            {
                customer = custController.Find(Customer_listvw.SelectedItems[0].Text);  //selected student becoms current student
                                                                                  // Show the details of the selected student in the controls
                Populate_Customer_boxes(customer);
            }
        }
        #endregion

        #region Search Methods

        private void Search_Customer(String _customer)
        {
            //CustomerController custController = new CustomerController();
            //Customer aCust = new Customer();

            customer = custController.Find(_customer);

            Populate_Customer_boxes(customer);
        }

        private void Search_Reservation(String _reservation)
        {
            //ReservationController resController = new ReservationController();
            //Reservation aRes = new Reservation();

            reservation = resController.Find(_reservation);

            Populate_Reservation_boxes(reservation);
        }


        #endregion

    }
}
