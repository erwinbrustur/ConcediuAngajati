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
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcStareConcediu = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcRaspunc = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnInchidereCA = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcedii)).BeginInit();
            this.SuspendLayout();
            // 
            // Actualizare
            // 
            this.Actualizare.Location = new System.Drawing.Point(565, 33);
            this.Actualizare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Actualizare.Name = "Actualizare";
            this.Actualizare.Size = new System.Drawing.Size(107, 23);
            this.Actualizare.TabIndex = 0;
            this.Actualizare.Text = "Actualizare";
            this.Actualizare.UseVisualStyleBackColor = false;
            this.Actualizare.Click += new System.EventHandler(this.Actualizare_Click);
            // 
            // cbStareConcediu
            // 
            this.cbStareConcediu.FormattingEnabled = true;
            this.cbStareConcediu.Location = new System.Drawing.Point(128, 22);
            this.cbStareConcediu.Name = "cbStareConcediu";
            this.cbStareConcediu.Size = new System.Drawing.Size(121, 23);
            this.cbStareConcediu.TabIndex = 1;
            this.cbStareConcediu.SelectedIndexChanged += new System.EventHandler(this.cbStareConcediu_SelectedIndexChanged);
            // 
            // dgvConcedii
            // 
            this.dgvConcedii.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConcedii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConcedii.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.dgvcStareConcediu,
            this.dgvcRaspunc});
            this.dgvConcedii.Location = new System.Drawing.Point(26, 74);
            this.dgvConcedii.MultiSelect = false;
            this.dgvConcedii.Name = "dgvConcedii";
            this.dgvConcedii.RowHeadersWidth = 51;
            this.dgvConcedii.RowTemplate.Height = 25;
            this.dgvConcedii.Size = new System.Drawing.Size(818, 270);
            this.dgvConcedii.TabIndex = 2;
            this.dgvConcedii.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConcedii_CellContentClick);
            this.dgvConcedii.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvConcedii_DefaultValuesNeeded);
            this.dgvConcedii.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvConcedii_RowStateChanged);
            this.dgvConcedii.SelectionChanged += new System.EventHandler(this.dgvConcedii_SelectionChanged);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Nume";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Data Inceput";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Data Sfarsit";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 125;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Inlocuitor";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 125;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Comentarii";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 125;
            // 
            // dgvcStareConcediu
            // 
            this.dgvcStareConcediu.HeaderText = "Stare concediu";
            this.dgvcStareConcediu.MinimumWidth = 6;
            this.dgvcStareConcediu.Name = "dgvcStareConcediu";
            this.dgvcStareConcediu.Width = 125;
            // 
            // dgvcRaspunc
            // 
            this.dgvcRaspunc.HeaderText = "Raspuns";
            this.dgvcRaspunc.MinimumWidth = 6;
            this.dgvcRaspunc.Name = "dgvcRaspunc";
            this.dgvcRaspunc.Text = "Actualizare";
            this.dgvcRaspunc.UseColumnTextForButtonValue = true;
            this.dgvcRaspunc.Width = 125;
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
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.Transparent;
            this.btnX.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnX.BackgroundImage")));
            this.btnX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Location = new System.Drawing.Point(821, 9);
            this.btnX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(39, 27);
            this.btnX.TabIndex = 12;
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Stare concediu:";
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
            // Nume
            // 
            this.Nume.HeaderText = "Nume";
            this.Nume.MinimumWidth = 6;
            this.Nume.Name = "Nume";
            this.Nume.Width = 125;
            // 
            // ConcediuAngajati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 375);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.dgvConcedii);
            this.Controls.Add(this.cbStareConcediu);
            this.Controls.Add(this.Actualizare);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ConcediuAngajati";
            this.Text = "ConcediuAngajati";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcedii)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Actualizare;
        private ComboBox cbStareConcediu;
        private DataGridView dgvConcedii;
        private Button btnInchidereCA;
        private Button btnX;
        private Label label1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Nume;
        private DataGridViewComboBoxColumn Column11;
        private DataGridViewButtonColumn Column12;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewComboBoxColumn dgvcStareConcediu;
        private DataGridViewButtonColumn dgvcRaspunc;
    }
}