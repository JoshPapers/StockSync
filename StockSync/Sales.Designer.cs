namespace StockSync
{
    partial class Sales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales));
            pnlHeader = new Panel();
            txtSearchProduct = new TextBox();
            label1 = new Label();
            lblStockAvailable = new Label();
            dgvProducts = new DataGridView();
            label2 = new Label();
            numQuantity = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            lblSellingPrice = new Label();
            label6 = new Label();
            panel1 = new Panel();
            btnAddToCart = new Button();
            dgvCart = new DataGridView();
            panel4 = new Panel();
            label9 = new Label();
            panel5 = new Panel();
            removeButton = new Button();
            btnConfirmSale = new Button();
            btnCancelSale = new Button();
            label5 = new Label();
            lblTotalAmount = new Label();
            backbutton = new Button();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.GradientInactiveCaption;
            pnlHeader.Controls.Add(txtSearchProduct);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1232, 90);
            pnlHeader.TabIndex = 5;
            // 
            // txtSearchProduct
            // 
            txtSearchProduct.Location = new Point(151, 35);
            txtSearchProduct.Name = "txtSearchProduct";
            txtSearchProduct.Size = new Size(368, 27);
            txtSearchProduct.TabIndex = 2;
            txtSearchProduct.TextChanged += txtSearchProduct_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.GradientInactiveCaption;
            label1.Location = new Point(34, 38);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 0;
            label1.Text = "Search Product:";
            // 
            // lblStockAvailable
            // 
            lblStockAvailable.AutoSize = true;
            lblStockAvailable.BackColor = SystemColors.Info;
            lblStockAvailable.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStockAvailable.Location = new Point(174, 20);
            lblStockAvailable.Name = "lblStockAvailable";
            lblStockAvailable.Size = new Size(18, 20);
            lblStockAvailable.TabIndex = 1;
            lblStockAvailable.Text = "0";
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(34, 123);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(618, 314);
            dgvProducts.TabIndex = 6;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.GradientInactiveCaption;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 440);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 4;
            label2.Text = "Selected Product";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(361, 18);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(150, 27);
            numQuantity.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.GradientInactiveCaption;
            label3.Location = new Point(54, 20);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 8;
            label3.Text = "Stock Available:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.GradientInactiveCaption;
            label4.Location = new Point(54, 58);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 9;
            label4.Text = "Selling Price:";
            // 
            // lblSellingPrice
            // 
            lblSellingPrice.AutoSize = true;
            lblSellingPrice.BackColor = SystemColors.Info;
            lblSellingPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSellingPrice.Location = new Point(153, 58);
            lblSellingPrice.Name = "lblSellingPrice";
            lblSellingPrice.Size = new Size(18, 20);
            lblSellingPrice.TabIndex = 10;
            lblSellingPrice.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.GradientInactiveCaption;
            label6.Location = new Point(287, 20);
            label6.Name = "label6";
            label6.Size = new Size(68, 20);
            label6.TabIndex = 11;
            label6.Text = "Quantity:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnAddToCart);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(numQuantity);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(lblStockAvailable);
            panel1.Controls.Add(lblSellingPrice);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(34, 472);
            panel1.Name = "panel1";
            panel1.Size = new Size(618, 109);
            panel1.TabIndex = 12;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new Point(287, 58);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(224, 29);
            btnAddToCart.TabIndex = 12;
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // dgvCart
            // 
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(40, 33);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(462, 314);
            dgvCart.TabIndex = 13;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaption;
            panel4.Controls.Add(label9);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(dgvCart);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(693, 90);
            panel4.Name = "panel4";
            panel4.Size = new Size(539, 543);
            panel4.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.GradientInactiveCaption;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(40, 350);
            label9.Name = "label9";
            label9.Size = new Size(38, 20);
            label9.TabIndex = 15;
            label9.Text = "Cart";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(removeButton);
            panel5.Controls.Add(btnConfirmSale);
            panel5.Controls.Add(btnCancelSale);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(lblTotalAmount);
            panel5.Location = new Point(40, 382);
            panel5.Name = "panel5";
            panel5.Size = new Size(462, 109);
            panel5.TabIndex = 13;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(344, 16);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(94, 29);
            removeButton.TabIndex = 16;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // btnConfirmSale
            // 
            btnConfirmSale.Location = new Point(240, 58);
            btnConfirmSale.Name = "btnConfirmSale";
            btnConfirmSale.Size = new Size(198, 29);
            btnConfirmSale.TabIndex = 13;
            btnConfirmSale.Text = "Confirm";
            btnConfirmSale.UseVisualStyleBackColor = true;
            btnConfirmSale.Click += btnConfirmSale_Click;
            // 
            // btnCancelSale
            // 
            btnCancelSale.Location = new Point(23, 58);
            btnCancelSale.Name = "btnCancelSale";
            btnCancelSale.Size = new Size(198, 29);
            btnCancelSale.TabIndex = 12;
            btnCancelSale.Text = "Cancel";
            btnCancelSale.UseVisualStyleBackColor = true;
            btnCancelSale.Click += btnCancelSale_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.GradientInactiveCaption;
            label5.Location = new Point(23, 20);
            label5.Name = "label5";
            label5.Size = new Size(102, 20);
            label5.TabIndex = 8;
            label5.Text = "Total Amount:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.BackColor = SystemColors.Info;
            lblTotalAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmount.Location = new Point(131, 20);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(18, 20);
            lblTotalAmount.TabIndex = 1;
            lblTotalAmount.Text = "0";
            // 
            // backbutton
            // 
            backbutton.Location = new Point(12, 592);
            backbutton.Name = "backbutton";
            backbutton.Size = new Size(94, 29);
            backbutton.TabIndex = 15;
            backbutton.Text = "Back";
            backbutton.UseVisualStyleBackColor = true;
            backbutton.Click += backbutton_Click;
            // 
            // Sales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1232, 633);
            Controls.Add(backbutton);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(dgvProducts);
            Controls.Add(pnlHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1250, 680);
            MinimumSize = new Size(1250, 680);
            Name = "Sales";
            Text = "Sales";
            Load += Sales_Load_1;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private TextBox txtSearchProduct;
        private Label lblStockAvailable;
        private Label label1;
        private DataGridView dgvProducts;
        private Label label2;
        private NumericUpDown numQuantity;
        private Label label3;
        private Label label4;
        private Label lblSellingPrice;
        private Label label6;
        private Panel panel1;
        private Button btnAddToCart;
        private DataGridView dgvCart;
        private Panel panel4;
        private Panel panel5;
        private Button btnCancelSale;
        private Label label5;
        private Label lblTotalAmount;
        private Button btnConfirmSale;
        private Label label9;
        private Button backbutton;
        private Button removeButton;
    }
}