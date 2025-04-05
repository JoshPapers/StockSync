namespace StockSync
{
    partial class AddCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCategory));
            pnlMainContent = new Panel();
            addCat = new Button();
            Category = new TextBox();
            label1 = new Label();
            btnBack = new Button();
            pnlHeader = new Panel();
            pnlMainContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = SystemColors.GradientInactiveCaption;
            pnlMainContent.Controls.Add(addCat);
            pnlMainContent.Controls.Add(Category);
            pnlMainContent.Controls.Add(label1);
            pnlMainContent.Controls.Add(btnBack);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(0, 0);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(422, 254);
            pnlMainContent.TabIndex = 5;
            // 
            // addCat
            // 
            addCat.Location = new Point(283, 127);
            addCat.Name = "addCat";
            addCat.Size = new Size(82, 34);
            addCat.TabIndex = 11;
            addCat.Text = "Add";
            addCat.UseVisualStyleBackColor = true;
            addCat.Click += addCat_Click;
            // 
            // Category
            // 
            Category.Location = new Point(173, 94);
            Category.Name = "Category";
            Category.Size = new Size(192, 27);
            Category.TabIndex = 10;
            Category.Text = "\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 97);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 8;
            label1.Text = "Add Category:";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 188);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(64, 54);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.GradientInactiveCaption;
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(422, 254);
            pnlHeader.TabIndex = 4;
            // 
            // AddCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 254);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddCategory";
            Text = "Add Category";
            Load += AddCategory_Load;
            pnlMainContent.ResumeLayout(false);
            pnlMainContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMainContent;
        private Panel pnlHeader;
        private Button btnBack;
        private TextBox Category;
        private Label label1;
        private Button addCat;
    }
}