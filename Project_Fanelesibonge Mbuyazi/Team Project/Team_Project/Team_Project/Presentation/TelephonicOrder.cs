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
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace Team_Project.Presentation
{
    public partial class TelephonicOrder : Form
    {
        public TelephonicOrder(ReservationController res_Controller, CustomerController cust_Controller)
        {
            InitializeComponent();
            resController = res_Controller;
            custController = cust_Controller;
        }

        #region determinant methods
        public string gen_bookingNumber()
        {
            Random rand = new Random();
            int length_char = 2;
            StringBuilder str_build = new StringBuilder();
            string result = "";

            char letters;

            for (int i = 0; i < length_char; i++)
            {
                double flt = rand.NextDouble();     
                int shift = Convert.ToInt32(Math.Floor(25 * flt));  // creating a 25 number inclusive format
                letters = Convert.ToChar(shift + 65);    // converting integer to it's relative letter
                str_build.Append(letters);
                result = str_build + rand.Next(10, 99).ToString();
            }
            return result;
        }


        public bool determine_Deposit()
        {
            if (cb_depositpaid.Checked == true)
            { return true; }                            // determines whether checkbox is checked or not and returns a boolean variable
            else
            { return false; }
        }

        #endregion 

        #region variables
        HomeScreen homeScreen;

        Customer customer;
        Collection<Customer> customers;
        CustomerController custController;
        //CustomerDB customerDB = new CustomerDB();

        Reservation reservation;
        Collection<Reservation> reservations;
        ReservationController resController;
        //ReservationsDB resDB = new ReservationsDB();


        #endregion

        #region reservation_insert_check
        private void reservation_check()
        {
            //Reservation aRes;
            //ReservationController resController = new ReservationController();
            if (CN_txt.Text.Length > 0 && PC_txt.Text.Length > 0 && sAddress_txt.Text.Length > 0 && Suburb_txt.Text.Length > 0)
            {
                if (PC_txt.Text.Length == 4)
                {
                    if (capacity_check() == true)
                    {
                        if (dt_Entry.Value.Date > DateTime.Now || dt_exit.Value.Date > DateTime.Now || dt_Entry.Value.Date < dt_exit.Value.Date)
                        {
                            reservation = new Reservation(reservations.Count+1, gen_bookingNumber(), dt_Entry.Value.Date, dt_exit.Value.Date, int.Parse(txt_CID.Text), determine_Deposit());
                            reservations.Add(reservation);
                            resController.Data_Maintenance(reservation, rDB.Database_Operations.add);
                            resController.FinalizeChanges();
                            AddCustomer();
                            MessageBox.Show("You have succesfully registered a reservation", "Succesful Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reservations_lstvw.Refresh();
                        }
                        else
                        { MessageBox.Show("Please ensure you have entered valid dates", "Incorrect Dates:", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        MessageBox.Show("The hotel is operating at maximum capacity now", "Insufficient capacity:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else { MessageBox.Show("Please enter a 4-digit postal code", "Incorrect Length:", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Please fill all necessary boxes", "Recquired Information:", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public bool capacity_check()
        {
            Reservation aRes = new Reservation();
            int counter = 0;
            int count = 0;
            while (counter < reservations.Count)
            {
                aRes = reservations[counter];
                
                if (dt_exit.Value.Date <= aRes.Exit && dt_exit.Value.Date >= aRes.Entry )       // determines if dates are viable based on hotel room contraint of 5
                {
                    count++;
                    counter++;

                }

                else
                {
                    counter++;
                }
            }

            if (count < 6)
            {
                return true;
            }
            else { return false; }

            
        }

        #endregion

        #region Add Customer

        private void AddCustomer()
        {
            PopulateCustomer();
            customers.Add(customer);
            custController.Data_Maintenance(customer, rDB.Database_Operations.add);
            custController.FinalizeChanges();
            Customers_lstvw.Refresh();
        }

        #endregion
        #region methods

        private void PopulateCustomer()
        {
            customer = new Customer(int.Parse(txt_CID.Text), CN_txt.Text, sAddress_txt.Text, Suburb_txt.Text, PC_txt.Text, reservationNotes_txt.Text);
        }
        private void ClearAll()
        {
            CN_txt.Clear();
            PC_txt.Clear();
            sAddress_txt.Clear();
            Suburb_txt.Clear();
            dt_Entry.Value = DateTime.Today;
            dt_exit.Value = DateTime.Today.AddDays(2);  // assumption customer will only stay for 2 days

        }

        private void Populate_boxes(Customer customer)
        {
            CN_txt.Text = customer.CustName;
            txt_CID.Text = customer.CustID.ToString();
            sAddress_txt.Text = customer.CustAddress;
            PC_txt.Text = customer.PostalCode;
            Suburb_txt.Text = customer.Suburb;
            reservationNotes_txt.Text = customer.ResNotes;
        }
        #endregion

        #region ListView set up
        public void setUpEmployeeListView()
        {
            ListViewItem customerLSTVW ;
            customers = null;
            Customers_lstvw.Clear();

            Customers_lstvw.Columns.Insert(0, "Customer ID", 130, HorizontalAlignment.Left);
            Customers_lstvw.Columns.Insert(1, "Customer Name", 130, HorizontalAlignment.Left);
            Customers_lstvw.Columns.Insert(2, "Customer Address", 130, HorizontalAlignment.Left);
            Customers_lstvw.Columns.Insert(3, "Suburb", 130, HorizontalAlignment.Left);
            Customers_lstvw.Columns.Insert(4, "Postal Code", 130, HorizontalAlignment.Left);
            Customers_lstvw.Columns.Insert(5, "Reservation Notes", 550, HorizontalAlignment.Left);

            customers = custController.ALLcustomers;

            foreach (Customer customer in customers)
            {
                customerLSTVW = new ListViewItem();
                customerLSTVW.Text = customer.CustID.ToString();
                customerLSTVW.SubItems.Add(customer.CustName.ToString());
                customerLSTVW.SubItems.Add(customer.CustAddress.ToString());
                customerLSTVW.SubItems.Add(customer.Suburb.ToString());
                customerLSTVW.SubItems.Add(customer.PostalCode.ToString());
                customerLSTVW.SubItems.Add(customer.ResNotes.ToString());
                Customers_lstvw.Items.Add(customerLSTVW);
            }
           
            Customers_lstvw.Refresh();
            Customers_lstvw.GridLines = true;
        }
        private void Customers_lstvw_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Customers_lstvw.SelectedItems.Count > 0)   // if you selected an item 
            {
                customer = custController.Find(Customers_lstvw.SelectedItems[0].Text);  //selected student becoms current student
                                                                                             // Show the details of the selected student in the controls
                Populate_boxes(customer);
            }

        }



        public void ResListView()
        {
            ListViewItem resDetails;
            reservations = null;
            Reservations_lstvw.Clear();


            Reservations_lstvw.Columns.Insert(0, "ReservationID", 110, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(1, "BookingNumber", 130, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(2, "EntryDate", 150, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(3, "ExitDate", 150, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(4, "DepositPaid", 130, HorizontalAlignment.Left);
            Reservations_lstvw.Columns.Insert(5, "CustomerID", 105, HorizontalAlignment.Left);

            reservations = resController.ALLreservation;


            foreach (Reservation res in reservations)
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



        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            homeScreen = new HomeScreen();
            homeScreen.ShowDialog();
        }

        private void cb2_Click(object sender, EventArgs e)
        {
            ClearAll();         // invoking the ClearAll() method to reset all textboxes
        }

        private void lbl_additional_Click(object sender, EventArgs e)
        {
            if (lbl_additional.Text == "Show Customers and Current Bookings")
            {
                this.WindowState = FormWindowState.Maximized;   // maximizing windowState to show hidden tools
                lbl_additional.Text = "Hide Customers and Current Bookings";
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                lbl_additional.Text = "Show Customers and Current Bookings";
                this.StartPosition = FormStartPosition.CenterScreen;
            }

        }

        private void TelephonicOrder_Load(object sender, EventArgs e)
        {
            Customers_lstvw.View = View.Details;
            Reservations_lstvw.View = View.Details;
            setUpEmployeeListView();
            ResListView();
        }

        private void lbl_additional_MouseEnter(object sender, EventArgs e)
        {
            lbl_additional.ForeColor = Color.LightBlue;
        }

        private void lbl_additional_MouseLeave(object sender, EventArgs e)
        {
            lbl_additional.ForeColor = Color.White;
        }

        private void cb1_Click(object sender, EventArgs e)
        {
            reservation_check();

        }

        private void txt_CID_TextChanged(object sender, EventArgs e)
        {

        }
    }


}
