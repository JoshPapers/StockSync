namespace StockSync
{
    partial class AddSupply
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSupply));
            btnAddToSupplies = new Button();
            dtpPurchaseDate = new DateTimePicker();
            lblExpiration = new Label();
            txtQuantity = new TextBox();
            lblStock = new Label();
            txtRawCost = new TextBox();
            lblPrice = new Label();
            lblProductName = new Label();
            txtSupplier = new TextBox();
            label1 = new Label();
            button1 = new Button();
            dtgvSupplyRecords = new DataGridView();
            cboProductName = new ComboBox();
            label3 = new Label();
            btnMarkReturned = new Button();
            button2 = new Button();
            UpdateProductName = new Button();
            lblTotalCost = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dtgvSupplyRecords).BeginInit();
            SuspendLayout();
            // 
            // btnAddToSupplies
            // 
            btnAddToSupplies.Location = new Point(29, 300);
            btnAddToSupplies.Name = "btnAddToSupplies";
            btnAddToSupplies.Size = new Size(196, 38);
            btnAddToSupplies.TabIndex = 20;
            btnAddToSupplies.Text = "Add to Supplies";
            btnAddToSupplies.UseVisualStyleBackColor = true;
            btnAddToSupplies.Click += btnAddToSupplies_Click;
            // 
            // dtpPurchaseDate
            // 
            dtpPurchaseDate.Location = new Point(29, 267);
            dtpPurchaseDate.Name = "dtpPurchaseDate";
            dtpPurchaseDate.Size = new Size(196, 27);
            dtpPurchaseDate.TabIndex = 19;
            // 
            // lblExpiration
            // 
            lblExpiration.AutoSize = true;
            lblExpiration.Location = new Point(29, 244);
            lblExpiration.Name = "lblExpiration";
            lblExpiration.Size = new Size(106, 20);
            lblExpiration.TabIndex = 24;
            lblExpiration.Text = "Purchase Date:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(29, 103);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(196, 27);
            txtQuantity.TabIndex = 17;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(29, 80);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(68, 20);
            lblStock.TabIndex = 23;
            lblStock.Text = "Quantity:\t";
            // 
            // txtRawCost
            // 
            txtRawCost.Location = new Point(29, 151);
            txtRawCost.Name = "txtRawCost";
            txtRawCost.Size = new Size(114, 27);
            txtRawCost.TabIndex = 16;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(29, 128);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(73, 20);
            lblPrice.TabIndex = 22;
            lblPrice.Text = "Raw Cost:\r\n";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(29, 31);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(107, 20);
            lblProductName.TabIndex = 14;
            lblProductName.Text = "Product Name:\t";
            // 
            // txtSupplier
            // 
            txtSupplier.Location = new Point(29, 201);
            txtSupplier.Name = "txtSupplier";
            txtSupplier.Size = new Size(196, 27);
            txtSupplier.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 178);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 26;
            label1.Text = "Supplier:\r\n";
            // 
            // button1
            // 
            button1.Location = new Point(9, 462);
            button1.Name = "button1";
            button1.Size = new Size(87, 29);
            button1.TabIndex = 28;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dtgvSupplyRecords
            // 
            dtgvSupplyRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvSupplyRecords.Location = new Point(250, 30);
            dtgvSupplyRecords.Name = "dtgvSupplyRecords";
            dtgvSupplyRecords.RowHeadersWidth = 51;
            dtgvSupplyRecords.Size = new Size(737, 447);
            dtgvSupplyRecords.TabIndex = 29;
            dtgvSupplyRecords.CellContentClick += dtgvSupplyRecords_CellContentClick;
            // 
            // cboProductName
            // 
            cboProductName.FormattingEnabled = true;
            cboProductName.Location = new Point(29, 54);
            cboProductName.Name = "cboProductName";
            cboProductName.Size = new Size(196, 28);
            cboProductName.TabIndex = 30;
            cboProductName.SelectedIndexChanged += cboProductName_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(149, 133);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 32;
            label3.Text = "Total Cost:\r\n";
            // 
            // btnMarkReturned
            // 
            btnMarkReturned.Location = new Point(29, 344);
            btnMarkReturned.Name = "btnMarkReturned";
            btnMarkReturned.Size = new Size(196, 38);
            btnMarkReturned.TabIndex = 33;
            btnMarkReturned.Text = "Return/Archive\r\n";
            btnMarkReturned.UseVisualStyleBackColor = true;
            btnMarkReturned.Click += btnMarkReturned_Click;
            // 
            // button2
            // 
            button2.Location = new Point(29, 388);
            button2.Name = "button2";
            button2.Size = new Size(196, 38);
            button2.TabIndex = 34;
            button2.Text = "Archives";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // UpdateProductName
            // 
            UpdateProductName.Location = new Point(131, 432);
            UpdateProductName.Name = "UpdateProductName";
            UpdateProductName.Size = new Size(94, 29);
            UpdateProductName.TabIndex = 35;
            UpdateProductName.Text = "Update";
            UpdateProductName.UseVisualStyleBackColor = true;
            UpdateProductName.Click += UpdateProductName_Click;
            // 
            // lblTotalCost
            // 
            lblTotalCost.Location = new Point(149, 151);
            lblTotalCost.Name = "lblTotalCost";
            lblTotalCost.Size = new Size(76, 27);
            lblTotalCost.TabIndex = 36;
            // 
            // AddSupply
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1012, 503);
            Controls.Add(lblTotalCost);
            Controls.Add(UpdateProductName);
            Controls.Add(button2);
            Controls.Add(btnMarkReturned);
            Controls.Add(label3);
            Controls.Add(cboProductName);
            Controls.Add(dtgvSupplyRecords);
            Controls.Add(button1);
            Controls.Add(txtSupplier);
            Controls.Add(label1);
            Controls.Add(btnAddToSupplies);
            Controls.Add(dtpPurchaseDate);
            Controls.Add(lblExpiration);
            Controls.Add(txtQuantity);
            Controls.Add(lblStock);
            Controls.Add(txtRawCost);
            Controls.Add(lblPrice);
            Controls.Add(lblProductName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddSupply";
            Text = "AddSupply";
            Load += AddSupply_Load_1;
            ((System.ComponentModel.ISupportInitialize)dtgvSupplyRecords).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddToSupplies;
        private DateTimePicker dtpPurchaseDate;
        private Label lblExpiration;
        private TextBox txtQuantity;
        private Label lblStock;
        private TextBox txtRawCost;
        private Label lblPrice;
        private Label lblProductName;
        private TextBox txtSupplier;
        private Label label1;
        private Button button1;
        private DataGridView dtgvSupplyRecords;
        private ComboBox cboProductName;
        private Label label3;
        private Button btnMarkReturned;
        private Button button2;
        private Button UpdateProductName;
        private TextBox lblTotalCost;
    }
}