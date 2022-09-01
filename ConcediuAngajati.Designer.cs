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
            this.Actualizare = new System.Windows.Forms.Button();
            this.cbStareConcediu = new System.Windows.Forms.ComboBox();
            this.dgvConcedii = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcedii)).BeginInit();
            this.SuspendLayout();
            // 
            // Actualizare
            // 
            this.Actualizare.Location = new System.Drawing.Point(624, 26);
            this.Actualizare.Name = "Actualizare";
            this.Actualizare.Size = new System.Drawing.Size(107, 23);
            this.Actualizare.TabIndex = 0;
            this.Actualizare.Text = "Actualizare";
            this.Actualizare.UseVisualStyleBackColor = true;
            this.Actualizare.Click += new System.EventHandler(this.Actualizare_Click);
            // 
            // cbStareConcediu
            // 
            this.cbStareConcediu.FormattingEnabled = true;
            this.cbStareConcediu.Location = new System.Drawing.Point(31, 21);
            this.cbStareConcediu.Name = "cbStareConcediu";
            this.cbStareConcediu.Size = new System.Drawing.Size(121, 23);
            this.cbStareConcediu.TabIndex = 1;
            this.cbStareConcediu.SelectedIndexChanged += new System.EventHandler(this.cbStareConcediu_SelectedIndexChanged);
            // 
            // dgvConcedii
            // 
            this.dgvConcedii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConcedii.Location = new System.Drawing.Point(31, 73);
            this.dgvConcedii.Name = "dgvConcedii";
            this.dgvConcedii.RowTemplate.Height = 25;
            this.dgvConcedii.Size = new System.Drawing.Size(722, 270);
            this.dgvConcedii.TabIndex = 2;
            this.dgvConcedii.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvConcedii_RowStateChanged);
            this.dgvConcedii.SelectionChanged += new System.EventHandler(this.dgvConcedii_SelectionChanged);
            // 
            // ConcediuAngajati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
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
    }
}