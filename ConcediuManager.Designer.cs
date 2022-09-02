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
            this.Respins = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Accept = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnInchidereCM = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(273, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Concediu Manager";
            // 
            // Respins
            // 
            this.Respins.HeaderText = "Respins";
            this.Respins.MinimumWidth = 6;
            this.Respins.Name = "Respins";
            this.Respins.Width = 125;
            // 
            // Accept
            // 
            this.Accept.HeaderText = "Accept";
            this.Accept.MinimumWidth = 6;
            this.Accept.Name = "Accept";
            this.Accept.Width = 125;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Accept,
            this.Respins});
            this.dataGridView1.Location = new System.Drawing.Point(11, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(678, 305);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // btnInchidereCM
            // 
            this.btnInchidereCM.BackColor = System.Drawing.Color.Transparent;
            this.btnInchidereCM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInchidereCM.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInchidereCM.Location = new System.Drawing.Point(751, 9);
            this.btnInchidereCM.Name = "btnInchidereCM";
            this.btnInchidereCM.Size = new System.Drawing.Size(37, 43);
            this.btnInchidereCM.TabIndex = 2;
            this.btnInchidereCM.Text = "X";
            this.btnInchidereCM.UseVisualStyleBackColor = false;
            this.btnInchidereCM.Click += new System.EventHandler(this.btnInchidereCM_Click);
            // 
            // ConcediuManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.btnInchidereCM);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConcediuManager";
            this.Text = "ConcediuManager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private DataGridViewCheckBoxColumn Respins;
        private DataGridViewCheckBoxColumn Accept;
        private DataGridView dataGridView1;
        private Button btnInchidereCM;
    }
}