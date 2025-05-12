namespace StockSync
{
    partial class SalesReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesReport));
            btnPrint = new Button();
            btnGenerateReport = new Button();
            dgvInventoryReport = new DataGridView();
            cmbProducts = new ComboBox();
            panel2 = new Panel();
            btnBack = new Button();
            txtYear = new TextBox();
            label1 = new Label();
            cmbMonth = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvInventoryReport).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(867, 622);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(151, 29);
            btnPrint.TabIndex = 15;
            btnPrint.Text = "Print Report";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(867, 122);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(151, 29);
            btnGenerateReport.TabIndex = 13;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            // 
            // dgvInventoryReport
            // 
            dgvInventoryReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventoryReport.Location = new Point(294, 164);
            dgvInventoryReport.Name = "dgvInventoryReport";
            dgvInventoryReport.ReadOnly = true;
            dgvInventoryReport.RowHeadersWidth = 51;
            dgvInventoryReport.Size = new Size(724, 452);
            dgvInventoryReport.TabIndex = 16;
            // 
            // cmbProducts
            // 
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(391, 123);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(457, 28);
            cmbProducts.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(btnBack);
            panel2.Controls.Add(txtYear);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(cmbMonth);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 105);
            panel2.Name = "panel2";
            panel2.Size = new Size(260, 558);
            panel2.TabIndex = 14;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 517);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(151, 29);
            btnBack.TabIndex = 10;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(88, 59);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(151, 27);
            txtYear.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 24);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 1;
            label1.Text = "Month:";
            // 
            // cmbMonth
            // 
            cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMonth.FormattingEnabled = true;
            cmbMonth.Location = new Point(88, 21);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new Size(151, 28);
            cmbMonth.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 62);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 4;
            label2.Text = "Year:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(278, 126);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 11;
            label3.Text = "Select Product:";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1045, 105);
            panel1.TabIndex = 10;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(437, 38);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(172, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SALES REPORT";
            // 
            // SalesReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 663);
            Controls.Add(btnPrint);
            Controls.Add(btnGenerateReport);
            Controls.Add(dgvInventoryReport);
            Controls.Add(cmbProducts);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1063, 710);
            MinimumSize = new Size(1063, 710);
            Name = "SalesReport";
            Text = "SalesReport";
            Load += SalesReport_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInventoryReport).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrint;
        private Button btnGenerateReport;
        private DataGridView dgvInventoryReport;
        private ComboBox cmbProducts;
        private Panel panel2;
        private Button btnBack;
        private TextBox txtYear;
        private Label label1;
        private ComboBox cmbMonth;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Label lblTitle;
    }
}