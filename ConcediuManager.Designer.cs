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
            this.label1 = new System.Windows.Forms.Label();
            this.cbStareConcediu = new System.Windows.Forms.ComboBox();
            this.dgvConcediuManager = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInchidereCM = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inceput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sfarsit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inlocuitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipConcediu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Raspuns = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcediuManager)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(441, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Concediu Manager";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbStareConcediu
            // 
            this.cbStareConcediu.FormattingEnabled = true;
            this.cbStareConcediu.Location = new System.Drawing.Point(24, 13);
            this.cbStareConcediu.Name = "cbStareConcediu";
            this.cbStareConcediu.Size = new System.Drawing.Size(121, 28);
            this.cbStareConcediu.TabIndex = 2;
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
            this.dgvConcediuManager.Location = new System.Drawing.Point(24, 69);
            this.dgvConcediuManager.Name = "dgvConcediuManager";
            this.dgvConcediuManager.RowHeadersWidth = 51;
            this.dgvConcediuManager.RowTemplate.Height = 25;
            this.dgvConcediuManager.Size = new System.Drawing.Size(1100, 353);
            this.dgvConcediuManager.TabIndex = 3;
            this.dgvConcediuManager.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConcedii_CellClick_1);
            this.dgvConcediuManager.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvConcediuManager_RowStateChanged);
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
            this.btnInchidereCM.Location = new System.Drawing.Point(1102, 2);
            this.btnInchidereCM.Name = "btnInchidereCM";
            this.btnInchidereCM.Size = new System.Drawing.Size(42, 35);
            this.btnInchidereCM.TabIndex = 0;
            this.btnInchidereCM.UseVisualStyleBackColor = false;
            this.btnInchidereCM.Click += new System.EventHandler(this.btnInchidereCM_Click_1);
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
            // ConcediuManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1145, 481);
            this.Controls.Add(this.btnInchidereCM);
            this.Controls.Add(this.dgvConcediuManager);
            this.Controls.Add(this.cbStareConcediu);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConcediuManager";
            this.Text = "ConcediuManager";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcediuManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private ComboBox cbStareConcediu;
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
    }
}