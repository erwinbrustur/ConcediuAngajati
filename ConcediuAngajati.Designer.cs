namespace ConcediuAngajati
{
    partial class ConcediuAngajati
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbStareConcediu = new System.Windows.Forms.ComboBox();
            this.dgvConcedii = new System.Windows.Forms.DataGridView();
            this.Actualizare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcedii)).BeginInit();
            this.SuspendLayout();
            // 
            // checkAccept
            // 
            this.checkAccept.AllowUserToOrderColumns = true;
            this.checkAccept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.checkAccept.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn3,
            this.Respins});
            this.checkAccept.Location = new System.Drawing.Point(10, 49);
            this.checkAccept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkAccept.Name = "checkAccept";
            this.checkAccept.RowHeadersWidth = 51;
            this.checkAccept.RowTemplate.Height = 29;
            this.checkAccept.Size = new System.Drawing.Size(769, 278);
            this.checkAccept.TabIndex = 13;
            this.checkAccept.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.HeaderText = "Accept";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Respins
            // 
            this.Respins.HeaderText = "Respins";
            this.Respins.Name = "Respins";
            this.Respins.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Respins.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(259, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 51);
            this.label1.TabIndex = 12;
            this.label1.Text = "Concediu Angajati";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbStareConcediu
            // 
            this.cbStareConcediu.FormattingEnabled = true;
            this.cbStareConcediu.Location = new System.Drawing.Point(10, 16);
            this.cbStareConcediu.Name = "cbStareConcediu";
            this.cbStareConcediu.Size = new System.Drawing.Size(121, 23);
            this.cbStareConcediu.TabIndex = 14;
            this.cbStareConcediu.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dgvConcedii
            // 
            this.dgvConcedii.AllowUserToOrderColumns = true;
            this.dgvConcedii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConcedii.Location = new System.Drawing.Point(10, 49);
            this.dgvConcedii.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvConcedii.MultiSelect = false;
            this.dgvConcedii.Name = "dgvConcedii";
            this.dgvConcedii.RowHeadersWidth = 51;
            this.dgvConcedii.RowTemplate.Height = 29;
            this.dgvConcedii.Size = new System.Drawing.Size(769, 278);
            this.dgvConcedii.TabIndex = 13;
            this.dgvConcedii.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConcedii_CellContentClick);
            this.dgvConcedii.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            this.dgvConcedii.SelectionChanged += new System.EventHandler(this.dgvConcedii_SelectionChanged);
            // 
            // Actualizare
            // 
            this.Actualizare.Location = new System.Drawing.Point(677, 15);
            this.Actualizare.Name = "Actualizare";
            this.Actualizare.Size = new System.Drawing.Size(75, 23);
            this.Actualizare.TabIndex = 15;
            this.Actualizare.Text = "Actualizare";
            this.Actualizare.UseVisualStyleBackColor = true;
            this.Actualizare.Click += new System.EventHandler(this.Actualizare_Click);
            // 
            // ConcediuAngajati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 338);
            this.Controls.Add(this.checkAccept);
            this.Controls.Add(this.label1);
            this.Name = "ConcediuAngajati";
            this.Text = "ConcediuAngajati";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcedii)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Label label1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private ComboBox cbStareConcediu;
        private DataGridView dgvConcedii;
        private Button Actualizare;
    }
}