namespace StockSync
{
    partial class UpdateProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateProductForm));
            panel1 = new Panel();
            ProductNm = new TextBox();
            label3 = new Label();
            label2 = new Label();
            RemoveCategory = new CheckBox();
            label1 = new Label();
            Cancel = new Button();
            Save = new Button();
            Category = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(ProductNm);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(RemoveCategory);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Cancel);
            panel1.Controls.Add(Save);
            panel1.Controls.Add(Category);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(331, 269);
            panel1.TabIndex = 8;
            // 
            // ProductNm
            // 
            ProductNm.Location = new Point(28, 62);
            ProductNm.Name = "ProductNm";
            ProductNm.Size = new Size(275, 27);
            ProductNm.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 143);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 19;
            label3.Text = "Quantity";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 92);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 18;
            label2.Text = "Category";
            // 
            // RemoveCategory
            // 
            RemoveCategory.AutoSize = true;
            RemoveCategory.Location = new Point(218, 142);
            RemoveCategory.Name = "RemoveCategory";
            RemoveCategory.Size = new Size(85, 24);
            RemoveCategory.TabIndex = 17;
            RemoveCategory.Text = "Remove";
            RemoveCategory.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 39);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 16;
            label1.Text = "Name";
            // 
            // Cancel
            // 
            Cancel.Location = new Point(12, 219);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(101, 38);
            Cancel.TabIndex = 15;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // Save
            // 
            Save.Location = new Point(218, 219);
            Save.Name = "Save";
            Save.Size = new Size(101, 38);
            Save.TabIndex = 14;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // Category
            // 
            Category.DropDownStyle = ComboBoxStyle.DropDownList;
            Category.FormattingEnabled = true;
            Category.Location = new Point(28, 112);
            Category.Name = "Category";
            Category.Size = new Size(275, 28);
            Category.TabIndex = 9;
            // 
            // UpdateProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 269);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpdateProductForm";
            Text = "UpdateProduct";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button Cancel;
        private Button Save;
        private ComboBox Category;
        private Label label3;
        private Label label2;
        private CheckBox RemoveCategory;
        private Label label1;
        private TextBox ProductNm;
    }
}