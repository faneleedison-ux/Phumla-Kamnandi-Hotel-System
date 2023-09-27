
namespace Team_Project.Presentation
{
    partial class CancelBooking
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
            this.searchCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byReservationIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byCustomerNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnToHomeScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Reservations_lstvw = new System.Windows.Forms.ListView();
            this.lblHeading = new System.Windows.Forms.Label();
            this.tb_reservation = new System.Windows.Forms.TextBox();
            this.cb_reservartion = new Team_Project.Custom_Button.CB();
            this.cb_Cancel = new Team_Project.Custom_Button.CB();
            this.cb_Reset = new Team_Project.Custom_Button.CB();
            this.ms_Control.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms_Control
            // 
            this.ms_Control.BackColor = System.Drawing.Color.Black;
            this.ms_Control.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ms_Control.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ms_Control.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchCustomerToolStripMenuItem,
            this.operationsToolStripMenuItem,
            this.returnToHomeScreenToolStripMenuItem});
            this.ms_Control.Location = new System.Drawing.Point(0, 0);
            this.ms_Control.Name = "ms_Control";
            this.ms_Control.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.ms_Control.Size = new System.Drawing.Size(603, 25);
            this.ms_Control.TabIndex = 0;
            this.ms_Control.Text = "menuStrip1";
            // 
            // searchCustomerToolStripMenuItem
            // 
            this.searchCustomerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byReservationIDToolStripMenuItem,
            this.byCustomerNameToolStripMenuItem});
            this.searchCustomerToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Info;
            this.searchCustomerToolStripMenuItem.Name = "searchCustomerToolStripMenuItem";
            this.searchCustomerToolStripMenuItem.Size = new System.Drawing.Size(69, 21);
            this.searchCustomerToolStripMenuItem.Text = "Search:";
            // 
            // byReservationIDToolStripMenuItem
            // 
            this.byReservationIDToolStripMenuItem.Name = "byReservationIDToolStripMenuItem";
            this.byReservationIDToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.byReservationIDToolStripMenuItem.Text = "By ReservationID";
            // 
            // byCustomerNameToolStripMenuItem
            // 
            this.byCustomerNameToolStripMenuItem.Name = "byCustomerNameToolStripMenuItem";
            this.byCustomerNameToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.byCustomerNameToolStripMenuItem.Text = "By CustomerID";
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeReservationToolStripMenuItem});
            this.operationsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Info;
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(95, 21);
            this.operationsToolStripMenuItem.Text = "Operations:";
            // 
            // removeReservationToolStripMenuItem
            // 
            this.removeReservationToolStripMenuItem.Name = "removeReservationToolStripMenuItem";
            this.removeReservationToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.removeReservationToolStripMenuItem.Text = "Remove Reservation";
            // 
            // returnToHomeScreenToolStripMenuItem
            // 
            this.returnToHomeScreenToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Info;
            this.returnToHomeScreenToolStripMenuItem.Name = "returnToHomeScreenToolStripMenuItem";
            this.returnToHomeScreenToolStripMenuItem.Size = new System.Drawing.Size(176, 21);
            this.returnToHomeScreenToolStripMenuItem.Text = "Return to Home Screen:";
            this.returnToHomeScreenToolStripMenuItem.Click += new System.EventHandler(this.returnToHomeScreenToolStripMenuItem_Click);
            // 
            // Reservations_lstvw
            // 
            this.Reservations_lstvw.Font = new System.Drawing.Font("Century", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reservations_lstvw.HideSelection = false;
            this.Reservations_lstvw.Location = new System.Drawing.Point(18, 93);
            this.Reservations_lstvw.Margin = new System.Windows.Forms.Padding(2);
            this.Reservations_lstvw.Name = "Reservations_lstvw";
            this.Reservations_lstvw.Size = new System.Drawing.Size(563, 248);
            this.Reservations_lstvw.TabIndex = 1;
            this.Reservations_lstvw.UseCompatibleStateImageBehavior = false;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.SystemColors.Info;
            this.lblHeading.Location = new System.Drawing.Point(204, 40);
            this.lblHeading.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(218, 40);
            this.lblHeading.TabIndex = 3;
            this.lblHeading.Text = "Reservations:";
            // 
            // tb_reservation
            // 
            this.tb_reservation.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_reservation.Location = new System.Drawing.Point(129, 379);
            this.tb_reservation.Margin = new System.Windows.Forms.Padding(2);
            this.tb_reservation.Name = "tb_reservation";
            this.tb_reservation.Size = new System.Drawing.Size(172, 22);
            this.tb_reservation.TabIndex = 22;
            // 
            // cb_reservartion
            // 
            this.cb_reservartion.BackColor = System.Drawing.Color.BurlyWood;
            this.cb_reservartion.Background_Color = System.Drawing.Color.BurlyWood;
            this.cb_reservartion.Color_Border = System.Drawing.Color.Peru;
            this.cb_reservartion.FlatAppearance.BorderSize = 0;
            this.cb_reservartion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_reservartion.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_reservartion.ForeColor = System.Drawing.Color.Black;
            this.cb_reservartion.Location = new System.Drawing.Point(129, 405);
            this.cb_reservartion.Margin = new System.Windows.Forms.Padding(2);
            this.cb_reservartion.Name = "cb_reservartion";
            this.cb_reservartion.Radius_Border = 20;
            this.cb_reservartion.Size = new System.Drawing.Size(171, 44);
            this.cb_reservartion.Size_Border = 0;
            this.cb_reservartion.TabIndex = 21;
            this.cb_reservartion.Text = "Search Reservation ID:";
            this.cb_reservartion.Text_Color = System.Drawing.Color.Black;
            this.cb_reservartion.UseVisualStyleBackColor = false;
            this.cb_reservartion.Click += new System.EventHandler(this.cb_reservartion_Click);
            // 
            // cb_Cancel
            // 
            this.cb_Cancel.BackColor = System.Drawing.Color.BurlyWood;
            this.cb_Cancel.Background_Color = System.Drawing.Color.BurlyWood;
            this.cb_Cancel.Color_Border = System.Drawing.Color.Peru;
            this.cb_Cancel.FlatAppearance.BorderSize = 0;
            this.cb_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Cancel.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Cancel.ForeColor = System.Drawing.Color.Black;
            this.cb_Cancel.Location = new System.Drawing.Point(355, 429);
            this.cb_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Cancel.Name = "cb_Cancel";
            this.cb_Cancel.Radius_Border = 20;
            this.cb_Cancel.Size = new System.Drawing.Size(171, 44);
            this.cb_Cancel.Size_Border = 0;
            this.cb_Cancel.TabIndex = 23;
            this.cb_Cancel.Text = "Cancel Reservation";
            this.cb_Cancel.Text_Color = System.Drawing.Color.Black;
            this.cb_Cancel.UseVisualStyleBackColor = false;
            this.cb_Cancel.Click += new System.EventHandler(this.cb_Cancel_Click);
            // 
            // cb_Reset
            // 
            this.cb_Reset.BackColor = System.Drawing.Color.BurlyWood;
            this.cb_Reset.Background_Color = System.Drawing.Color.BurlyWood;
            this.cb_Reset.Color_Border = System.Drawing.Color.Peru;
            this.cb_Reset.FlatAppearance.BorderSize = 0;
            this.cb_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Reset.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Reset.ForeColor = System.Drawing.Color.Black;
            this.cb_Reset.Location = new System.Drawing.Point(355, 367);
            this.cb_Reset.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Reset.Name = "cb_Reset";
            this.cb_Reset.Radius_Border = 20;
            this.cb_Reset.Size = new System.Drawing.Size(171, 44);
            this.cb_Reset.Size_Border = 0;
            this.cb_Reset.TabIndex = 24;
            this.cb_Reset.Text = "Reset List";
            this.cb_Reset.Text_Color = System.Drawing.Color.Black;
            this.cb_Reset.UseVisualStyleBackColor = false;
            this.cb_Reset.Click += new System.EventHandler(this.cb_Reset_Click);
            // 
            // CancelBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(603, 484);
            this.Controls.Add(this.cb_Reset);
            this.Controls.Add(this.cb_Cancel);
            this.Controls.Add(this.tb_reservation);
            this.Controls.Add(this.cb_reservartion);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.Reservations_lstvw);
            this.Controls.Add(this.ms_Control);
            this.MainMenuStrip = this.ms_Control;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CancelBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CancelBooking";
            this.ms_Control.ResumeLayout(false);
            this.ms_Control.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ms_Control;
        private System.Windows.Forms.ToolStripMenuItem searchCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byReservationIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byCustomerNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeReservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnToHomeScreenToolStripMenuItem;
        private System.Windows.Forms.ListView Reservations_lstvw;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.TextBox tb_reservation;
        private Custom_Button.CB cb_reservartion;
        private Custom_Button.CB cb_Cancel;
        private Custom_Button.CB cb_Reset;
    }
}