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
            this.label1 = new System.Windows.Forms.Label();
            this.Actualizeaza = new System.Windows.Forms.Button();
            this.cbStareConcediu = new System.Windows.Forms.ComboBox();
            this.dgvConcediuManager = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inceput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sfarsit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inlocuitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInchidereCM = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcediuManager)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(255, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Concediu Manager";
            // 
            // Actualizeaza
            // 
            this.Actualizeaza.Location = new System.Drawing.Point(544, 22);
            this.Actualizeaza.Name = "Actualizeaza";
            this.Actualizeaza.Size = new System.Drawing.Size(84, 23);
            this.Actualizeaza.TabIndex = 1;
            this.Actualizeaza.Text = "Actualizare";
            this.Actualizeaza.UseVisualStyleBackColor = true;
            this.Actualizeaza.Click += new System.EventHandler(this.Actualizare_Click);
            // 
            // cbStareConcediu
            // 
            this.cbStareConcediu.FormattingEnabled = true;
            this.cbStareConcediu.Location = new System.Drawing.Point(24, 13);
            this.cbStareConcediu.Name = "cbStareConcediu";
            this.cbStareConcediu.Size = new System.Drawing.Size(121, 28);
            this.cbStareConcediu.TabIndex = 2;
            this.cbStareConcediu.SelectedIndexChanged += new System.EventHandler(this.cbStareConcediu_SelectedIndexChanged);
            // 
            // dgvConcediuManager
            // 
            this.dgvConcediuManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConcediuManager.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Inceput,
            this.Sfarsit,
            this.Inlocuitor,
            this.Comentarii});
            this.dgvConcediuManager.Location = new System.Drawing.Point(24, 70);
            this.dgvConcediuManager.Name = "dgvConcediuManager";
            this.dgvConcediuManager.RowHeadersWidth = 51;
            this.dgvConcediuManager.RowTemplate.Height = 25;
            this.dgvConcediuManager.Size = new System.Drawing.Size(647, 246);
            this.dgvConcediuManager.TabIndex = 3;
            this.dgvConcediuManager.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvConcediuManager_RowStateChanged);
            this.dgvConcediuManager.SelectionChanged += new System.EventHandler(this.dgvConcediuManager_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nume";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
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
            this.Inlocuitor.Width = 125;
            // 
            // Comentarii
            // 
            this.Comentarii.HeaderText = "Comentarii";
            this.Comentarii.MinimumWidth = 6;
            this.Comentarii.Name = "Comentarii";
            this.Comentarii.Width = 125;
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
            this.btnInchidereCM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInchidereCM.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInchidereCM.ForeColor = System.Drawing.Color.Maroon;
            this.btnInchidereCM.Location = new System.Drawing.Point(660, 2);
            this.btnInchidereCM.Name = "btnInchidereCM";
            this.btnInchidereCM.Size = new System.Drawing.Size(37, 43);
            this.btnInchidereCM.TabIndex = 4;
            this.btnInchidereCM.Text = "X";
            this.btnInchidereCM.UseVisualStyleBackColor = false;
            this.btnInchidereCM.Click += new System.EventHandler(this.btnInchidereCM_Click);
            // 
            // ConcediuManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.btnInchidereCM);
            this.Controls.Add(this.dgvConcediuManager);
            this.Controls.Add(this.cbStareConcediu);
            this.Controls.Add(this.Actualizeaza);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConcediuManager";
            this.Text = "ConcediuManager";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcediuManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Button Actualizeaza;
        private ComboBox cbStareConcediu;
        private DataGridView dgvConcediuManager;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Nume;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Inceput;
        private DataGridViewTextBoxColumn Sfarsit;
        private DataGridViewTextBoxColumn Inlocuitor;
        private DataGridViewTextBoxColumn Comentarii;
        private Button btnInchidereCM;
    }
}