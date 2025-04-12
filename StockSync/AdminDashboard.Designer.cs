namespace StockSync
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            pnlSidebar = new Panel();
            button1 = new Button();
            picLogo = new PictureBox();
            button3 = new Button();
            btnSales = new Button();
            btnLogout = new Button();
            btnInventory = new Button();
            pnlHeader = new Panel();
            pnlMainContent = new Panel();
            button2 = new Button();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = SystemColors.ActiveCaption;
            pnlSidebar.Controls.Add(button2);
            pnlSidebar.Controls.Add(button1);
            pnlSidebar.Controls.Add(picLogo);
            pnlSidebar.Controls.Add(button3);
            pnlSidebar.Controls.Add(btnSales);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnInventory);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 633);
            pnlSidebar.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 202);
            button1.Name = "button1";
            button1.Size = new Size(223, 41);
            button1.TabIndex = 9;
            button1.Text = "Inventory Report";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(58, 12);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(125, 125);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 2;
            picLogo.TabStop = false;
            // 
            // button3
            // 
            button3.Location = new Point(12, 428);
            button3.Name = "button3";
            button3.Size = new Size(223, 41);
            button3.TabIndex = 8;
            button3.Text = "Manage Users";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnSales
            // 
            btnSales.Location = new Point(12, 289);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(223, 41);
            btnSales.TabIndex = 7;
            btnSales.Text = "Sales";
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 564);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(64, 54);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnInventory
            // 
            btnInventory.Location = new Point(12, 155);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(223, 41);
            btnInventory.TabIndex = 2;
            btnInventory.Text = "Inventory";
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += btnInventory_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.GradientInactiveCaption;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(250, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(982, 125);
            pnlHeader.TabIndex = 1;
            // 
            // pnlMainContent
            // 
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(250, 125);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(982, 508);
            pnlMainContent.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(12, 336);
            button2.Name = "button2";
            button2.Size = new Size(223, 41);
            button2.TabIndex = 11;
            button2.Text = "Sales Report";
            button2.UseVisualStyleBackColor = true;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 633);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1250, 680);
            MinimumSize = new Size(1250, 680);
            Name = "AdminDashboard";
            Load += Form1_Load;
            pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Button button3;
        private Button btnSales;
        private Button btnLogout;
        private Button btnInventory;
        private PictureBox picLogo;
        private Panel pnlHeader;
        private Panel pnlMainContent;
        private Button button1;
        private Button button2;
    }
}