namespace StockSync
{
    partial class UpdateProductFormSupply
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
            panel1 = new Panel();
            Source = new TextBox();
            label4 = new Label();
            ProductNm = new TextBox();
            label1 = new Label();
            Cancel = new Button();
            Save = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(Source);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(ProductNm);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Cancel);
            panel1.Controls.Add(Save);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(331, 269);
            panel1.TabIndex = 9;
            // 
            // Source
            // 
            Source.Location = new Point(28, 115);
            Source.Name = "Source";
            Source.Size = new Size(275, 27);
            Source.TabIndex = 26;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 92);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 25;
            label4.Text = "Supplier";
            // 
            // ProductNm
            // 
            ProductNm.Location = new Point(28, 62);
            ProductNm.Name = "ProductNm";
            ProductNm.Size = new Size(275, 27);
            ProductNm.TabIndex = 22;
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
            Cancel.Click += Cancel_Click_1;
            // 
            // Save
            // 
            Save.Location = new Point(218, 219);
            Save.Name = "Save";
            Save.Size = new Size(101, 38);
            Save.TabIndex = 14;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click_1;
            // 
            // UpdateProductFormSupply
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 269);
            Controls.Add(panel1);
            Name = "UpdateProductFormSupply";
            Text = "UpdateProductFormSupply";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox ProductNm;
        private Label label1;
        private Button Cancel;
        private Button Save;
        private TextBox Source;
        private Label label4;
    }
}