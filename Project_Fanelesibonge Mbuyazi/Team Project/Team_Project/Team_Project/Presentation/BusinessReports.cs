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
    public partial class BusinessReports : Form
    {
        public BusinessReports()
        {
            InitializeComponent();
        }

        HomeScreen HomeScreen;

        #region MouseEnter/ MouseLeave events
        private void Report1_btn_MouseEnter(object sender, EventArgs e)
        {
            Report1_btn.Font = new Font(Report1_btn.Font, FontStyle.Bold);
            Report1_btn.ForeColor = Color.Gold;
            Report1_btn.BackColor = Color.Black;
        }

        private void Report1_btn_MouseLeave(object sender, EventArgs e)
        {
            Report1_btn.Font = new Font(Report1_btn.Font, FontStyle.Regular);
            Report1_btn.ForeColor = Color.Black;
            Report1_btn.BackColor = Color.BurlyWood;
        }

        private void Report2_btn_MouseEnter(object sender, EventArgs e)
        {
            Report2_btn.Font = new Font(Report2_btn.Font, FontStyle.Bold);
            Report2_btn.ForeColor = Color.Gold;
            Report2_btn.BackColor = Color.Black;
        }

        private void Report2_btn_MouseLeave(object sender, EventArgs e)
        {
            Report2_btn.Font = new Font(Report2_btn.Font, FontStyle.Regular);
            Report2_btn.ForeColor = Color.Black;
            Report2_btn.BackColor = Color.BurlyWood;
        }

        private void Merge_btn_MouseEnter(object sender, EventArgs e)
        {
            Merge_btn.Font = new Font(Merge_btn.Font, FontStyle.Bold);
            Merge_btn.ForeColor = Color.Gold;
            Merge_btn.BackColor = Color.Black;
        }

        private void Merge_btn_MouseLeave(object sender, EventArgs e)
        {
            Merge_btn.Font = new Font(Merge_btn.Font, FontStyle.Regular);
            Merge_btn.ForeColor = Color.Black;
            Merge_btn.BackColor = Color.BurlyWood ;
        }

        private void Return_btn_MouseEnter(object sender, EventArgs e)
        {
            Return_btn.Font = new Font(Return_btn.Font, FontStyle.Bold);
            Return_btn.ForeColor = Color.Gold;
            Return_btn.BackColor = Color.Black;
        }

        private void Return_btn_MouseLeave(object sender, EventArgs e)
        {
            Return_btn.Font = new Font(Return_btn.Font, FontStyle.Regular);
            Return_btn.ForeColor = Color.Black;
            Return_btn.BackColor = Color.BurlyWood;
        }

        #endregion

        private void Return_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeScreen = new HomeScreen();
            HomeScreen.ShowDialog();
        }

        private void BusinessReports_Load(object sender, EventArgs e)
        {

        }
    }
}
