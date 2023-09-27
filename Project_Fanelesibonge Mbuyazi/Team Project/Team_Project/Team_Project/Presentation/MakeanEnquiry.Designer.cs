
namespace Team_Project.Presentation
{
    partial class MakeanEnquiry
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
            this.Reservations_lstvw = new System.Windows.Forms.ListView();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lbl_Entry = new System.Windows.Forms.Label();
            this.ReservationID_txt = new System.Windows.Forms.TextBox();
            this.lbl_CustomerID = new System.Windows.Forms.Label();
            this.CustomerID_txt = new System.Windows.Forms.TextBox();
            this.cb_Return = new Team_Project.Custom_Button.CB();
            this.cb_search = new Team_Project.Custom_Button.CB();
            this.SuspendLayout();
            // 
            // Reservations_lstvw
            // 
            this.Reservations_lstvw.HideSelection = false;
            this.Reservations_lstvw.Location = new System.Drawing.Point(43, 97);
            this.Reservations_lstvw.Name = "Reservations_lstvw";
            this.Reservations_lstvw.Size = new System.Drawing.Size(920, 295);
            this.Reservations_lstvw.TabIndex = 0;
            this.Reservations_lstvw.UseCompatibleStateImageBehavior = false;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.SystemColors.Info;
            this.lblHeading.Location = new System.Drawing.Point(361, 23);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(279, 50);
            this.lblHeading.TabIndex = 2;
            this.lblHeading.Text = "Reservations:";
            this.lblHeading.Click += new System.EventHandler(this.lblHeading_Click);
            // 
            // lbl_Entry
            // 
            this.lbl_Entry.AutoSize = true;
            this.lbl_Entry.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Entry.ForeColor = System.Drawing.SystemColors.Info;
            this.lbl_Entry.Location = new System.Drawing.Point(39, 433);
            this.lbl_Entry.Name = "lbl_Entry";
            this.lbl_Entry.Size = new System.Drawing.Size(201, 21);
            this.lbl_Entry.TabIndex = 21;
            this.lbl_Entry.Text = "Enter ReservationID:";
            // 
            // ReservationID_txt
            // 
            this.ReservationID_txt.BackColor = System.Drawing.SystemColors.Info;
            this.ReservationID_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReservationID_txt.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReservationID_txt.ForeColor = System.Drawing.SystemColors.MenuText;
            this.ReservationID_txt.Location = new System.Drawing.Point(302, 431);
            this.ReservationID_txt.Name = "ReservationID_txt";
            this.ReservationID_txt.Size = new System.Drawing.Size(242, 28);
            this.ReservationID_txt.TabIndex = 22;
            // 
            // lbl_CustomerID
            // 
            this.lbl_CustomerID.AutoSize = true;
            this.lbl_CustomerID.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CustomerID.ForeColor = System.Drawing.SystemColors.Info;
            this.lbl_CustomerID.Location = new System.Drawing.Point(39, 477);
            this.lbl_CustomerID.Name = "lbl_CustomerID";
            this.lbl_CustomerID.Size = new System.Drawing.Size(221, 21);
            this.lbl_CustomerID.TabIndex = 23;
            this.lbl_CustomerID.Text = "||   Enter CustomerID:";
            // 
            // CustomerID_txt
            // 
            this.CustomerID_txt.BackColor = System.Drawing.SystemColors.Info;
            this.CustomerID_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomerID_txt.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerID_txt.Location = new System.Drawing.Point(302, 475);
            this.CustomerID_txt.Name = "CustomerID_txt";
            this.CustomerID_txt.Size = new System.Drawing.Size(242, 28);
            this.CustomerID_txt.TabIndex = 24;
            // 
            // cb_Return
            // 
            this.cb_Return.BackColor = System.Drawing.Color.Khaki;
            this.cb_Return.Background_Color = System.Drawing.Color.Khaki;
            this.cb_Return.Color_Border = System.Drawing.Color.Peru;
            this.cb_Return.FlatAppearance.BorderSize = 0;
            this.cb_Return.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Return.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Return.ForeColor = System.Drawing.Color.Black;
            this.cb_Return.Location = new System.Drawing.Point(570, 469);
            this.cb_Return.Name = "cb_Return";
            this.cb_Return.Radius_Border = 20;
            this.cb_Return.Size = new System.Drawing.Size(393, 40);
            this.cb_Return.Size_Border = 0;
            this.cb_Return.TabIndex = 25;
            this.cb_Return.Text = "Return:";
            this.cb_Return.Text_Color = System.Drawing.Color.Black;
            this.cb_Return.UseVisualStyleBackColor = false;
            this.cb_Return.Click += new System.EventHandler(this.cb_Return_Click);
            // 
            // cb_search
            // 
            this.cb_search.BackColor = System.Drawing.Color.Khaki;
            this.cb_search.Background_Color = System.Drawing.Color.Khaki;
            this.cb_search.Color_Border = System.Drawing.Color.Peru;
            this.cb_search.FlatAppearance.BorderSize = 0;
            this.cb_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_search.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_search.ForeColor = System.Drawing.Color.Black;
            this.cb_search.Location = new System.Drawing.Point(570, 423);
            this.cb_search.Name = "cb_search";
            this.cb_search.Radius_Border = 20;
            this.cb_search.Size = new System.Drawing.Size(393, 40);
            this.cb_search.Size_Border = 0;
            this.cb_search.TabIndex = 3;
            this.cb_search.Text = "Search Entry:";
            this.cb_search.Text_Color = System.Drawing.Color.Black;
            this.cb_search.UseVisualStyleBackColor = false;
            this.cb_search.Click += new System.EventHandler(this.cb_search_Click);
            // 
            // MakeanEnquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(1014, 538);
            this.Controls.Add(this.cb_Return);
            this.Controls.Add(this.CustomerID_txt);
            this.Controls.Add(this.lbl_CustomerID);
            this.Controls.Add(this.ReservationID_txt);
            this.Controls.Add(this.lbl_Entry);
            this.Controls.Add(this.cb_search);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.Reservations_lstvw);
            this.Name = "MakeanEnquiry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MakeanEnquiry";
            this.Load += new System.EventHandler(this.MakeanEnquiry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Reservations_lstvw;
        private System.Windows.Forms.Label lblHeading;
        private Custom_Button.CB cb_search;
        private System.Windows.Forms.Label lbl_Entry;
        private System.Windows.Forms.TextBox ReservationID_txt;
        private System.Windows.Forms.Label lbl_CustomerID;
        private System.Windows.Forms.TextBox CustomerID_txt;
        private Custom_Button.CB cb_Return;
    }
}