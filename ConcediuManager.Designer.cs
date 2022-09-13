namespace ConcediuAngajati
{
    partial class ConcediuManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConcediuManager));
            this.dgvConcediuManager = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inceput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sfarsit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inlocuitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipConcediu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Raspuns = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInchidereCM = new System.Windows.Forms.Button();
            this.lblNume = new System.Windows.Forms.Label();
            this.tbNume = new System.Windows.Forms.TextBox();
            this.lblPrenume = new System.Windows.Forms.Label();
            this.tbPrenume = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblStare = new System.Windows.Forms.Label();
            this.lblTipConcediu = new System.Windows.Forms.Label();
            this.cbStare = new System.Windows.Forms.ComboBox();
            this.cbTip = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcediuManager)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConcediuManager
            // 
            this.dgvConcediuManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConcediuManager.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Inceput,
            this.Sfarsit,
            this.Inlocuitor,
            this.TipConcediu,
            this.Comentarii,
            this.dataGridViewComboBoxColumn1,
            this.Raspuns});
            this.dgvConcediuManager.Location = new System.Drawing.Point(24, 113);
            this.dgvConcediuManager.Name = "dgvConcediuManager";
            this.dgvConcediuManager.RowHeadersWidth = 51;
            this.dgvConcediuManager.RowTemplate.Height = 25;
            this.dgvConcediuManager.Size = new System.Drawing.Size(1099, 309);
            this.dgvConcediuManager.TabIndex = 3;
            this.dgvConcediuManager.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConcedii_CellClick_1);
            this.dgvConcediuManager.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvConcediuManager_RowStateChanged);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nume";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // Inceput
            // 
            this.Inceput.HeaderText = "Inceput";
            this.Inceput.MinimumWidth = 6;
            this.Inceput.Name = "Inceput";
            this.Inceput.Width = 125;
            // 
            // Sfarsit
            // 
            this.Sfarsit.HeaderText = "Sfarsit";
            this.Sfarsit.MinimumWidth = 6;
            this.Sfarsit.Name = "Sfarsit";
            this.Sfarsit.Width = 125;
            // 
            // Inlocuitor
            // 
            this.Inlocuitor.HeaderText = "Inlocuitor";
            this.Inlocuitor.MinimumWidth = 6;
            this.Inlocuitor.Name = "Inlocuitor";
            this.Inlocuitor.Width = 150;
            // 
            // TipConcediu
            // 
            this.TipConcediu.HeaderText = "Tip Concediu";
            this.TipConcediu.MinimumWidth = 6;
            this.TipConcediu.Name = "TipConcediu";
            this.TipConcediu.Width = 125;
            // 
            // Comentarii
            // 
            this.Comentarii.HeaderText = "Comentarii";
            this.Comentarii.MinimumWidth = 6;
            this.Comentarii.Name = "Comentarii";
            this.Comentarii.Width = 125;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "Stare Concediu";
            this.dataGridViewComboBoxColumn1.MinimumWidth = 6;
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Width = 120;
            // 
            // Raspuns
            // 
            this.Raspuns.HeaderText = "Raspuns";
            this.Raspuns.MinimumWidth = 6;
            this.Raspuns.Name = "Raspuns";
            this.Raspuns.Text = "Actualizeaza";
            this.Raspuns.UseColumnTextForButtonValue = true;
            this.Raspuns.Width = 120;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Nume";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // Nume
            // 
            this.Nume.HeaderText = "Nume";
            this.Nume.MinimumWidth = 6;
            this.Nume.Name = "Nume";
            this.Nume.Width = 125;
            // 
            // btnInchidereCM
            // 
            this.btnInchidereCM.BackColor = System.Drawing.Color.Transparent;
            this.btnInchidereCM.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInchidereCM.BackgroundImage")));
            this.btnInchidereCM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInchidereCM.FlatAppearance.BorderSize = 0;
            this.btnInchidereCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInchidereCM.Location = new System.Drawing.Point(1102, 3);
            this.btnInchidereCM.Name = "btnInchidereCM";
            this.btnInchidereCM.Size = new System.Drawing.Size(42, 35);
            this.btnInchidereCM.TabIndex = 0;
            this.btnInchidereCM.UseVisualStyleBackColor = false;
            this.btnInchidereCM.Click += new System.EventHandler(this.btnInchidereCM_Click_1);
            // 
            // lblNume
            // 
            this.lblNume.AutoSize = true;
            this.lblNume.BackColor = System.Drawing.Color.Transparent;
            this.lblNume.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNume.ForeColor = System.Drawing.Color.White;
            this.lblNume.Location = new System.Drawing.Point(58, 71);
            this.lblNume.Name = "lblNume";
            this.lblNume.Size = new System.Drawing.Size(69, 28);
            this.lblNume.TabIndex = 4;
            this.lblNume.Text = "Nume:";
            this.lblNume.Click += new System.EventHandler(this.lblNume_Click);
            // 
            // tbNume
            // 
            this.tbNume.Location = new System.Drawing.Point(133, 72);
            this.tbNume.Name = "tbNume";
            this.tbNume.Size = new System.Drawing.Size(207, 27);
            this.tbNume.TabIndex = 5;
            // 
            // lblPrenume
            // 
            this.lblPrenume.AutoSize = true;
            this.lblPrenume.BackColor = System.Drawing.Color.Transparent;
            this.lblPrenume.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrenume.ForeColor = System.Drawing.Color.White;
            this.lblPrenume.Location = new System.Drawing.Point(384, 72);
            this.lblPrenume.Name = "lblPrenume";
            this.lblPrenume.Size = new System.Drawing.Size(93, 28);
            this.lblPrenume.TabIndex = 6;
            this.lblPrenume.Text = "Prenume:";
            // 
            // tbPrenume
            // 
            this.tbPrenume.Location = new System.Drawing.Point(483, 72);
            this.tbPrenume.Name = "tbPrenume";
            this.tbPrenume.Size = new System.Drawing.Size(207, 27);
            this.tbPrenume.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ConcediuAngajati.Properties.Resources.search;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(713, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 32);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStare
            // 
            this.lblStare.AutoSize = true;
            this.lblStare.BackColor = System.Drawing.Color.Transparent;
            this.lblStare.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStare.ForeColor = System.Drawing.Color.White;
            this.lblStare.Location = new System.Drawing.Point(791, 27);
            this.lblStare.Name = "lblStare";
            this.lblStare.Size = new System.Drawing.Size(143, 28);
            this.lblStare.TabIndex = 9;
            this.lblStare.Text = "Stare Concediu";
            // 
            // lblTipConcediu
            // 
            this.lblTipConcediu.AutoSize = true;
            this.lblTipConcediu.BackColor = System.Drawing.Color.Transparent;
            this.lblTipConcediu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTipConcediu.ForeColor = System.Drawing.Color.White;
            this.lblTipConcediu.Location = new System.Drawing.Point(808, 73);
            this.lblTipConcediu.Name = "lblTipConcediu";
            this.lblTipConcediu.Size = new System.Drawing.Size(126, 28);
            this.lblTipConcediu.TabIndex = 10;
            this.lblTipConcediu.Text = "Tip Concediu";
            // 
            // cbStare
            // 
            this.cbStare.FormattingEnabled = true;
            this.cbStare.Location = new System.Drawing.Point(939, 27);
            this.cbStare.Name = "cbStare";
            this.cbStare.Size = new System.Drawing.Size(151, 28);
            this.cbStare.TabIndex = 11;
            // 
            // cbTip
            // 
            this.cbTip.FormattingEnabled = true;
            this.cbTip.Location = new System.Drawing.Point(939, 73);
            this.cbTip.Name = "cbTip";
            this.cbTip.Size = new System.Drawing.Size(151, 28);
            this.cbTip.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(24, 428);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1099, 41);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(43, 3);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 33);
            this.button2.TabIndex = 14;
            this.button2.Text = "Inapoi";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(686, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(0, 0);
            this.button3.TabIndex = 15;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::ConcediuAngajati.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(713, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(39, 32);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(220, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 41);
            this.label1.TabIndex = 17;
            this.label1.Text = "Concediu Manager";
            // 
            // ConcediuManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1145, 481);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbTip);
            this.Controls.Add(this.cbStare);
            this.Controls.Add(this.lblTipConcediu);
            this.Controls.Add(this.lblStare);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbPrenume);
            this.Controls.Add(this.lblPrenume);
            this.Controls.Add(this.tbNume);
            this.Controls.Add(this.lblNume);
            this.Controls.Add(this.btnInchidereCM);
            this.Controls.Add(this.dgvConcediuManager);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConcediuManager";
            this.Text = "ConcediuManager";
            this.Load += new System.EventHandler(this.ConcediuAngajati_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcediuManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView dgvConcediuManager;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Nume;
        private Button btnInchidereCM;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Inceput;
        private DataGridViewTextBoxColumn Sfarsit;
        private DataGridViewTextBoxColumn Inlocuitor;
        private DataGridViewTextBoxColumn TipConcediu;
        private DataGridViewTextBoxColumn Comentarii;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private DataGridViewButtonColumn Raspuns;
        private Label lblNume;
        private TextBox tbNume;
        private Label lblPrenume;
        private TextBox tbPrenume;
        private Button button1;
        private Label lblStare;
        private Label lblTipConcediu;
        private ComboBox cbStare;
        private ComboBox cbTip;
        private Panel panel1;
        private Button button2;
        private Button button3;
        private Button btnRefresh;
        private Label label1;
    }
}