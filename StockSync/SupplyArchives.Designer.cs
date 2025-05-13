namespace StockSync
{
    partial class SupplyArchives
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplyArchives));
            dgvArchive = new DataGridView();
            Back = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvArchive).BeginInit();
            SuspendLayout();
            // 
            // dgvArchive
            // 
            dgvArchive.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArchive.Location = new Point(24, 22);
            dgvArchive.Name = "dgvArchive";
            dgvArchive.RowHeadersWidth = 51;
            dgvArchive.Size = new Size(664, 424);
            dgvArchive.TabIndex = 1;
            // 
            // Back
            // 
            Back.Location = new Point(24, 452);
            Back.Name = "Back";
            Back.Size = new Size(99, 33);
            Back.TabIndex = 2;
            Back.Text = "Back";
            Back.UseVisualStyleBackColor = true;
            // 
            // SupplyArchives
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(712, 493);
            Controls.Add(Back);
            Controls.Add(dgvArchive);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SupplyArchives";
            Text = "SupplyArchives";
            Load += SupplyArchives_Load;
            ((System.ComponentModel.ISupportInitialize)dgvArchive).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvArchive;
        private Button Back;
    }
}