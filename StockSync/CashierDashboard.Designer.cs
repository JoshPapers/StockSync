namespace StockSync
{
    partial class CashierDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierDashboard));
            pnlMainContent = new Panel();
            pnlHeader = new Panel();
            pnlSidebar = new Panel();
            picLogo = new PictureBox();
            btnSales = new Button();
            btnLogout = new Button();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlMainContent
            // 
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(250, 125);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(982, 508);
            pnlMainContent.TabIndex = 5;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.GradientInactiveCaption;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(250, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(982, 125);
            pnlHeader.TabIndex = 4;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = SystemColors.ActiveCaption;
            pnlSidebar.Controls.Add(picLogo);
            pnlSidebar.Controls.Add(btnSales);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 633);
            pnlSidebar.TabIndex = 3;
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
            // btnSales
            // 
            btnSales.Location = new Point(12, 217);
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
            // CashierDashboard
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
            Name = "CashierDashboard";
            Text = "Cashier";
            Load += CashierDashboard_Load;
            pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMainContent;
        private Panel pnlHeader;
        private Panel pnlSidebar;
        private PictureBox picLogo;
        private Button btnSales;
        private Button btnLogout;
    }
}