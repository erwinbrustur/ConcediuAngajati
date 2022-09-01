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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.checkAccept = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Respins = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.checkAccept)).BeginInit();
            this.SuspendLayout();
            // 
            // checkAccept
            // 
            this.checkAccept.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSalmon;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.LightCoral;
            this.checkAccept.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.checkAccept.BackgroundColor = System.Drawing.Color.White;
            this.checkAccept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.checkAccept.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn3,
            this.Respins});
            this.checkAccept.GridColor = System.Drawing.Color.Maroon;
            this.checkAccept.Location = new System.Drawing.Point(11, 65);
            this.checkAccept.Name = "checkAccept";
            this.checkAccept.RowHeadersWidth = 51;
            this.checkAccept.RowTemplate.Height = 29;
            this.checkAccept.Size = new System.Drawing.Size(879, 371);
            this.checkAccept.TabIndex = 13;
            this.checkAccept.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.HeaderText = "Accept";
            this.dataGridViewCheckBoxColumn3.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn3.Width = 125;
            // 
            // Respins
            // 
            this.Respins.HeaderText = "Respins";
            this.Respins.MinimumWidth = 6;
            this.Respins.Name = "Respins";
            this.Respins.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Respins.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Respins.Width = 125;
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
            // ConcediuAngajati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(904, 451);
            this.Controls.Add(this.checkAccept);
            this.Controls.Add(this.label1);
            this.Name = "ConcediuAngajati";
            this.Text = "ConcediuAngajati";
            ((System.ComponentModel.ISupportInitialize)(this.checkAccept)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView checkAccept;
        private Label label1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private DataGridViewCheckBoxColumn Respins;
    }
}