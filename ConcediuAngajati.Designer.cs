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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConcediuAngajati));
            this.Actualizare = new System.Windows.Forms.Button();
            this.cbStareConcediu = new System.Windows.Forms.ComboBox();
            this.dgvConcedii = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInchidereCA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcedii)).BeginInit();
            this.SuspendLayout();
            // 
            // Actualizare
            // 
            this.Actualizare.Location = new System.Drawing.Point(624, 26);
            this.Actualizare.Name = "Actualizare";
            this.Actualizare.Size = new System.Drawing.Size(122, 31);
            this.Actualizare.TabIndex = 0;
            this.Actualizare.Text = "Actualizare";
            this.Actualizare.UseVisualStyleBackColor = false;
            this.Actualizare.Click += new System.EventHandler(this.Actualizare_Click);
            // 
            // cbStareConcediu
            // 
            this.cbStareConcediu.FormattingEnabled = true;
            this.cbStareConcediu.Location = new System.Drawing.Point(35, 28);
            this.cbStareConcediu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbStareConcediu.Name = "cbStareConcediu";
            this.cbStareConcediu.Size = new System.Drawing.Size(138, 28);
            this.cbStareConcediu.TabIndex = 1;
            this.cbStareConcediu.SelectedIndexChanged += new System.EventHandler(this.cbStareConcediu_SelectedIndexChanged);
            // 
            // dgvConcedii
            // 
            this.dgvConcedii.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConcedii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConcedii.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvConcedii.Location = new System.Drawing.Point(35, 97);
            this.dgvConcedii.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvConcedii.MultiSelect = false;
            this.dgvConcedii.Name = "dgvConcedii";
            this.dgvConcedii.RowHeadersWidth = 51;
            this.dgvConcedii.RowTemplate.Height = 25;
            this.dgvConcedii.Size = new System.Drawing.Size(825, 360);
            this.dgvConcedii.TabIndex = 2;
            this.dgvConcedii.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConcedii_CellContentClick);
            this.dgvConcedii.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvConcedii_RowStateChanged);
            this.dgvConcedii.SelectionChanged += new System.EventHandler(this.dgvConcedii_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nume";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Data Inceput";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Data Sfarsit";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Inlocuitor";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Comentarii";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // btnInchidereCA
            // 
            this.btnInchidereCA.BackColor = System.Drawing.Color.Transparent;
            this.btnInchidereCA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInchidereCA.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInchidereCA.Location = new System.Drawing.Point(865, 12);
            this.btnInchidereCA.Name = "btnInchidereCA";
            this.btnInchidereCA.Size = new System.Drawing.Size(37, 43);
            this.btnInchidereCA.TabIndex = 3;
            this.btnInchidereCA.Text = "X";
            this.btnInchidereCA.UseVisualStyleBackColor = false;
            this.btnInchidereCA.Click += new System.EventHandler(this.btnInchidereCA_Click);
            // 
            // ConcediuAngajati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvConcedii);
            this.Controls.Add(this.cbStareConcediu);
            this.Controls.Add(this.Actualizare);
            this.Name = "ConcediuAngajati";
            this.Text = "ConcediuAngajati";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcedii)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button Actualizare;
        private ComboBox cbStareConcediu;
        private DataGridView dgvConcedii;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Button btnInchidereCA;
    }
}