namespace StockSync
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            pnlMainContent = new Panel();
            dgvInventory = new DataGridView();
            pnlHeader = new Panel();
            TotalPrices = new Label();
            label3 = new Label();
            TotalStocks = new Label();
            label1 = new Label();
            btnBack = new Button();
            lblProductName = new Label();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblPrice = new Label();
            txtSellingPrice = new TextBox();
            lblStock = new Label();
            txtStockQuantity = new TextBox();
            lblExpiration = new Label();
            dtpExpirationDate = new DateTimePicker();
            btnAddProduct = new Button();
            btnUpdateProduct = new Button();
            btnArchiveProduct = new Button();
            btnCategory = new Button();
            NoExp = new CheckBox();
            cmbProductName = new ComboBox();
            Archive = new Button();
            pnlSidebar = new Panel();
            lblSupplyQuantity = new Label();
            label2 = new Label();
            pnlMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            pnlHeader.SuspendLayout();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMainContent
            // 
            pnlMainContent.Controls.Add(dgvInventory);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(250, 125);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(982, 508);
            pnlMainContent.TabIndex = 5;
            // 
            // dgvInventory
            // 
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(47, 44);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.Size = new Size(897, 412);
            dgvInventory.TabIndex = 0;
            dgvInventory.CellContentClick += dgvInventory_CellContentClick;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.GradientInactiveCaption;
            pnlHeader.Controls.Add(TotalPrices);
            pnlHeader.Controls.Add(label3);
            pnlHeader.Controls.Add(TotalStocks);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(250, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(982, 125);
            pnlHeader.TabIndex = 4;
            // 
            // TotalPrices
            // 
            TotalPrices.AutoSize = true;
            TotalPrices.BackColor = SystemColors.Info;
            TotalPrices.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalPrices.Location = new Point(178, 62);
            TotalPrices.Name = "TotalPrices";
            TotalPrices.Size = new Size(44, 20);
            TotalPrices.TabIndex = 3;
            TotalPrices.Text = "Total";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 62);
            label3.Name = "label3";
            label3.Size = new Size(125, 20);
            label3.TabIndex = 2;
            label3.Text = "Total Prices of all:";
            // 
            // TotalStocks
            // 
            TotalStocks.AutoSize = true;
            TotalStocks.BackColor = SystemColors.Info;
            TotalStocks.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalStocks.Location = new Point(144, 32);
            TotalStocks.Name = "TotalStocks";
            TotalStocks.Size = new Size(44, 20);
            TotalStocks.TabIndex = 1;
            TotalStocks.Text = "Total";
            TotalStocks.Click += TotalStocks_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.GradientInactiveCaption;
            label1.Location = new Point(47, 32);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 0;
            label1.Text = "Total Stocks:";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 564);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(64, 54);
            btnBack.TabIndex = 6;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(12, 9);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(107, 20);
            lblProductName.TabIndex = 0;
            lblProductName.Text = "Product Name:\t";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(12, 62);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(72, 20);
            lblCategory.TabIndex = 7;
            lblCategory.Text = "Category:\t";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(12, 85);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(196, 28);
            cmbCategory.TabIndex = 1;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(12, 116);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(93, 20);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "Selling Price:\t";
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.Location = new Point(12, 139);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.Size = new Size(196, 27);
            txtSellingPrice.TabIndex = 2;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(12, 169);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(108, 20);
            lblStock.TabIndex = 11;
            lblStock.Text = "Stock Quantity:\t";
            // 
            // txtStockQuantity
            // 
            txtStockQuantity.Location = new Point(12, 192);
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.Size = new Size(115, 27);
            txtStockQuantity.TabIndex = 3;
            // 
            // lblExpiration
            // 
            lblExpiration.AutoSize = true;
            lblExpiration.Location = new Point(12, 222);
            lblExpiration.Name = "lblExpiration";
            lblExpiration.Size = new Size(115, 20);
            lblExpiration.TabIndex = 13;
            lblExpiration.Text = "Expiration Date:\t";
            // 
            // dtpExpirationDate
            // 
            dtpExpirationDate.Location = new Point(12, 245);
            dtpExpirationDate.Name = "dtpExpirationDate";
            dtpExpirationDate.Size = new Size(196, 27);
            dtpExpirationDate.TabIndex = 4;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(12, 278);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(93, 38);
            btnAddProduct.TabIndex = 5;
            btnAddProduct.Text = "Add";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnUpdateProduct
            // 
            btnUpdateProduct.Location = new Point(111, 278);
            btnUpdateProduct.Name = "btnUpdateProduct";
            btnUpdateProduct.Size = new Size(97, 38);
            btnUpdateProduct.TabIndex = 6;
            btnUpdateProduct.Text = "Update";
            btnUpdateProduct.UseVisualStyleBackColor = true;
            btnUpdateProduct.Click += btnUpdateProduct_Click;
            // 
            // btnArchiveProduct
            // 
            btnArchiveProduct.Location = new Point(12, 387);
            btnArchiveProduct.Name = "btnArchiveProduct";
            btnArchiveProduct.Size = new Size(151, 29);
            btnArchiveProduct.TabIndex = 7;
            btnArchiveProduct.Text = "Delete";
            btnArchiveProduct.UseVisualStyleBackColor = true;
            btnArchiveProduct.Click += btnArchiveProduct_Click;
            // 
            // btnCategory
            // 
            btnCategory.Location = new Point(12, 422);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(151, 29);
            btnCategory.TabIndex = 1;
            btnCategory.Text = "Add Category";
            btnCategory.UseVisualStyleBackColor = true;
            btnCategory.Click += btnCategory_Click;
            // 
            // NoExp
            // 
            NoExp.AutoSize = true;
            NoExp.Location = new Point(129, 221);
            NoExp.Name = "NoExp";
            NoExp.Size = new Size(79, 24);
            NoExp.TabIndex = 1;
            NoExp.Text = "No Exp";
            NoExp.UseVisualStyleBackColor = true;
            NoExp.CheckedChanged += NoExp_CheckedChanged;
            // 
            // cmbProductName
            // 
            cmbProductName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductName.DropDownWidth = 250;
            cmbProductName.FormattingEnabled = true;
            cmbProductName.Location = new Point(12, 32);
            cmbProductName.Name = "cmbProductName";
            cmbProductName.Size = new Size(196, 28);
            cmbProductName.TabIndex = 4;
            cmbProductName.SelectedIndexChanged += cmbProductName_SelectedIndexChanged;
            // 
            // Archive
            // 
            Archive.Location = new Point(12, 457);
            Archive.Name = "Archive";
            Archive.Size = new Size(151, 29);
            Archive.TabIndex = 14;
            Archive.Text = "Archives";
            Archive.UseVisualStyleBackColor = true;
            Archive.Click += Archive_Click;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = SystemColors.ActiveCaption;
            pnlSidebar.Controls.Add(lblSupplyQuantity);
            pnlSidebar.Controls.Add(label2);
            pnlSidebar.Controls.Add(Archive);
            pnlSidebar.Controls.Add(cmbProductName);
            pnlSidebar.Controls.Add(NoExp);
            pnlSidebar.Controls.Add(btnCategory);
            pnlSidebar.Controls.Add(btnArchiveProduct);
            pnlSidebar.Controls.Add(btnUpdateProduct);
            pnlSidebar.Controls.Add(btnAddProduct);
            pnlSidebar.Controls.Add(dtpExpirationDate);
            pnlSidebar.Controls.Add(lblExpiration);
            pnlSidebar.Controls.Add(txtStockQuantity);
            pnlSidebar.Controls.Add(lblStock);
            pnlSidebar.Controls.Add(txtSellingPrice);
            pnlSidebar.Controls.Add(lblPrice);
            pnlSidebar.Controls.Add(cmbCategory);
            pnlSidebar.Controls.Add(lblCategory);
            pnlSidebar.Controls.Add(lblProductName);
            pnlSidebar.Controls.Add(btnBack);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 633);
            pnlSidebar.TabIndex = 3;
            // 
            // lblSupplyQuantity
            // 
            lblSupplyQuantity.AutoSize = true;
            lblSupplyQuantity.BackColor = Color.White;
            lblSupplyQuantity.BorderStyle = BorderStyle.FixedSingle;
            lblSupplyQuantity.Location = new Point(155, 195);
            lblSupplyQuantity.Name = "lblSupplyQuantity";
            lblSupplyQuantity.Size = new Size(19, 22);
            lblSupplyQuantity.TabIndex = 1;
            lblSupplyQuantity.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(142, 169);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 15;
            label2.Text = "Supply:";
            // 
            // Inventory
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
            Name = "Inventory";
            Load += Inventory_Load;
            pnlMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMainContent;
        private Panel pnlHeader;
        private DataGridView dgvInventory;
        private Label TotalPrices;
        private Label label3;
        private Label TotalStocks;
        private Label label1;
        private Button btnBack;
        private Label lblProductName;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblPrice;
        private TextBox txtSellingPrice;
        private Label lblStock;
        private TextBox txtStockQuantity;
        private Label lblExpiration;
        private DateTimePicker dtpExpirationDate;
        private Button btnAddProduct;
        private Button btnUpdateProduct;
        private Button btnArchiveProduct;
        private Button btnCategory;
        private CheckBox NoExp;
        private ComboBox cmbProductName;
        private Button Archive;
        private Panel pnlSidebar;
        private Label lblSupplyQuantity;
        private Label label2;
    }
}