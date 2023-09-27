
namespace Team_Project.Presentation
{
    partial class CompanyInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ms_Control = new System.Windows.Forms.MenuStrip();
            this.projectInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_companyInfo = new System.Windows.Forms.Panel();
            this.Temp_lbl = new System.Windows.Forms.Label();
            this.information_ret = new System.Windows.Forms.RichTextBox();
            this.ms_Control.SuspendLayout();
            this.pnl_companyInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms_Control
            // 
            this.ms_Control.BackColor = System.Drawing.SystemColors.Info;
            this.ms_Control.Font = new System.Drawing.Font("Century", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ms_Control.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ms_Control.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectInformationToolStripMenuItem,
            this.informationAboutToolStripMenuItem,
            this.returnToolStripMenuItem});
            this.ms_Control.Location = new System.Drawing.Point(0, 0);
            this.ms_Control.Name = "ms_Control";
            this.ms_Control.Size = new System.Drawing.Size(800, 31);
            this.ms_Control.TabIndex = 1;
            this.ms_Control.Text = "menuStrip1";
            // 
            // projectInformationToolStripMenuItem
            // 
            this.projectInformationToolStripMenuItem.Name = "projectInformationToolStripMenuItem";
            this.projectInformationToolStripMenuItem.Size = new System.Drawing.Size(223, 27);
            this.projectInformationToolStripMenuItem.Text = "Project Information:";
            this.projectInformationToolStripMenuItem.Click += new System.EventHandler(this.projectInformationToolStripMenuItem_Click);
            // 
            // informationAboutToolStripMenuItem
            // 
            this.informationAboutToolStripMenuItem.Name = "informationAboutToolStripMenuItem";
            this.informationAboutToolStripMenuItem.Size = new System.Drawing.Size(246, 27);
            this.informationAboutToolStripMenuItem.Text = "Company Information:";
            this.informationAboutToolStripMenuItem.Click += new System.EventHandler(this.informationAboutToolStripMenuItem_Click);
            // 
            // returnToolStripMenuItem
            // 
            this.returnToolStripMenuItem.Name = "returnToolStripMenuItem";
            this.returnToolStripMenuItem.Size = new System.Drawing.Size(99, 27);
            this.returnToolStripMenuItem.Text = "Return:";
            this.returnToolStripMenuItem.Click += new System.EventHandler(this.returnToolStripMenuItem_Click);
            // 
            // pnl_companyInfo
            // 
            this.pnl_companyInfo.BackColor = System.Drawing.SystemColors.Info;
            this.pnl_companyInfo.Controls.Add(this.Temp_lbl);
            this.pnl_companyInfo.Controls.Add(this.information_ret);
            this.pnl_companyInfo.Font = new System.Drawing.Font("Century", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_companyInfo.Location = new System.Drawing.Point(53, 84);
            this.pnl_companyInfo.Name = "pnl_companyInfo";
            this.pnl_companyInfo.Size = new System.Drawing.Size(685, 336);
            this.pnl_companyInfo.TabIndex = 2;
            this.pnl_companyInfo.Visible = false;
            // 
            // Temp_lbl
            // 
            this.Temp_lbl.AutoSize = true;
            this.Temp_lbl.Font = new System.Drawing.Font("Century", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Temp_lbl.Location = new System.Drawing.Point(172, 25);
            this.Temp_lbl.Name = "Temp_lbl";
            this.Temp_lbl.Size = new System.Drawing.Size(349, 35);
            this.Temp_lbl.TabIndex = 1;
            this.Temp_lbl.Text = "Company Information:";
            // 
            // information_ret
            // 
            this.information_ret.BackColor = System.Drawing.SystemColors.Info;
            this.information_ret.ForeColor = System.Drawing.Color.Black;
            this.information_ret.Location = new System.Drawing.Point(20, 80);
            this.information_ret.Name = "information_ret";
            this.information_ret.Size = new System.Drawing.Size(639, 212);
            this.information_ret.TabIndex = 0;
            this.information_ret.Text = "";
            // 
            // CompanyInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_companyInfo);
            this.Controls.Add(this.ms_Control);
            this.Name = "CompanyInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompanyInformation";
            this.ms_Control.ResumeLayout(false);
            this.ms_Control.PerformLayout();
            this.pnl_companyInfo.ResumeLayout(false);
            this.pnl_companyInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ms_Control;
        private System.Windows.Forms.ToolStripMenuItem informationAboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnToolStripMenuItem;
        private System.Windows.Forms.Panel pnl_companyInfo;
        private System.Windows.Forms.Label Temp_lbl;
        private System.Windows.Forms.RichTextBox information_ret;
    }
}