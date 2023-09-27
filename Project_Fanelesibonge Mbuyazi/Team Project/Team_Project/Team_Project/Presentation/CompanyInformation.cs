using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team_Project.Presentation
{
    public partial class CompanyInformation : Form
    {
        public CompanyInformation()
        {
            InitializeComponent();
        }
        HomeScreen HomeScreen;

        #region methods 

        private void Information_regulation(int identifier) // identifier all method to perform different operations
        {
            switch (identifier)
            {
                case 0:
                    {
                        pnl_companyInfo.Visible = true;
                        Temp_lbl.Text = "Company Information:";
                        information_ret.Text = string.Format("The Phumla Kamnandi is an innovative hotel group currently expanding it's operations to be in service of more customers across South Africa. \n" +
                            "Our company aims to cater enhancing experiences whilst to citizens across South Africa at complimenting pricing. \n" +
                            "Our employees represent our freindly and innutive company motto, and are the essence of nature of this establishment. \n " +
                            "We wish those reading this message, a wonderful day.");
                        information_ret.SelectAll();
                        information_ret.SelectionAlignment = HorizontalAlignment.Center;
                        information_ret.Enabled = false;
                        break;
                    }
                case 1:
                    {
                        pnl_companyInfo.Visible = true;
                        Temp_lbl.Text = "Project Information:";
                        information_ret.Text = string.Format("This INF2011S project assigned by the University of Cape Town requires the planning and development of an Information System that attempts to account for the needs of a hotel group \n" +
                                                             "In this stage of the project, we present a program the company would be able to utilize to record and manipulate hotel records, combined with various other functionalities, such as business reports. \n" +
                                                             "We hope you enjoy our work.");
                        information_ret.SelectAll();
                        information_ret.SelectionAlignment = HorizontalAlignment.Center;
                        information_ret.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        pnl_companyInfo.Visible = false;
                        break;
                    }
            }

        }

        #endregion

        private void informationAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information_regulation(0);
        }

        private void projectInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information_regulation(1);      // calling the method with identifier to return specific response
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information_regulation(2);
            this.Hide();
            HomeScreen = new HomeScreen();
            HomeScreen.ShowDialog();
        }
    }
}
