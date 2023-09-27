using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team_Project.Presentation;
using Team_Project.Business;


namespace Team_Project
{
    public partial class HomeScreen : Form
    {
        #region Constructor
        public HomeScreen()
        {
            InitializeComponent();
            resController = new ReservationController();
            custController = new CustomerController();
        }
        #endregion

        #region variables 
        BusinessReports businessReports;
        CancelBooking cancelBooking;
        ChangeBooking changeBooking;
        CompanyInformation companyInformation;
        MakeanEnquiry makeanEnquiry;
        TelephonicOrder telephonicOrder;
        ReservationController resController;
        CustomerController custController;
        


        #endregion

        #region OnClick events
        private void Information_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            companyInformation = new CompanyInformation();
            companyInformation.ShowDialog();
        }

        private void Telephone_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            telephonicOrder = new TelephonicOrder(resController, custController);
            telephonicOrder.ShowDialog();
        }
        private void Enquiry_btn_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            makeanEnquiry = new MakeanEnquiry();
            makeanEnquiry.ShowDialog();
        }

        private void Change_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            changeBooking = new ChangeBooking(resController, custController);
            changeBooking.ShowDialog();
        }


        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            cancelBooking = new CancelBooking(resController);
            cancelBooking.ShowDialog();
        }

        private void Reports_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            businessReports = new BusinessReports();
            businessReports.ShowDialog();
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region MouseEnter / MouseLeave events

        private void Telephone_btn_MouseEnter(object sender, EventArgs e)
        {
            Telephone_btn.Font = new Font(Telephone_btn.Font, FontStyle.Bold);
            Telephone_btn.ForeColor = Color.Gold;
        }

        private void Telephone_btn_MouseLeave(object sender, EventArgs e)
        {
            Telephone_btn.Font = new Font(Telephone_btn.Font, FontStyle.Regular);
            Telephone_btn.ForeColor = Color.White;
        }

        private void Change_btn_MouseEnter(object sender, EventArgs e)
        {
            Change_btn.Font = new Font(Change_btn.Font, FontStyle.Bold);
            Change_btn.ForeColor = Color.Gold;
        }

        private void Change_btn_MouseLeave(object sender, EventArgs e)
        {
            Change_btn.Font = new Font(Change_btn.Font, FontStyle.Regular);
            Change_btn.ForeColor = Color.White;
        }

        private void Cancel_btn_MouseEnter(object sender, EventArgs e)
        {
            Cancel_btn.Font = new Font(Cancel_btn.Font, FontStyle.Bold);
            Cancel_btn.ForeColor = Color.Gold;

        }

        private void Cancel_btn_MouseLeave(object sender, EventArgs e)
        {
            Cancel_btn.Font = new Font(Cancel_btn.Font, FontStyle.Regular);
            Cancel_btn.ForeColor = Color.White;
        }



        private void Enquiry_btn_MouseEnter(object sender, EventArgs e)
        {
            Enquiry_btn.Font = new Font(Enquiry_btn.Font, FontStyle.Bold);
            Enquiry_btn.ForeColor = Color.Gold;
        }

        private void Enquiry_btn_MouseLeave(object sender, EventArgs e)
        {
            Enquiry_btn.Font = new Font(Enquiry_btn.Font, FontStyle.Regular);
            Enquiry_btn.ForeColor = Color.White;
        }

        private void Reports_btn_MouseEnter(object sender, EventArgs e)
        {
            Reports_btn.Font = new Font(Reports_btn.Font, FontStyle.Bold);
            Reports_btn.ForeColor = Color.Gold;
        }

        private void Reports_btn_MouseLeave(object sender, EventArgs e)
        {
            Reports_btn.Font = new Font(Reports_btn.Font, FontStyle.Regular);
            Reports_btn.ForeColor = Color.White;
        }

        private void Information_btn_MouseEnter(object sender, EventArgs e)
        {
            Information_btn.Font = new Font(Information_btn.Font, FontStyle.Bold);
            Information_btn.ForeColor = Color.Gold;
        }

        private void Information_btn_MouseLeave(object sender, EventArgs e)
        {
            Information_btn.Font = new Font(Information_btn.Font, FontStyle.Regular);
            Information_btn.ForeColor = Color.White;
        }

        private void Close_btn_MouseEnter(object sender, EventArgs e)
        {
            Close_btn.Font = new Font(Close_btn.Font, FontStyle.Bold);
            Close_btn.ForeColor = Color.Gold;
        }

        private void Close_btn_MouseLeave(object sender, EventArgs e)
        {
            Close_btn.Font = new Font(Close_btn.Font, FontStyle.Regular);
            Close_btn.ForeColor = Color.White;
        }

        #endregion

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            DateTime currDate = DateTime.Now;
            Date_lbl.Text = string.Format("{0}", currDate.ToString("G"));

        }
    }
}
