﻿namespace ConcediuAngajati
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(227, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 38);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 338);
            this.Controls.Add(this.Actualizare);
            this.Controls.Add(this.cbStareConcediu);
            this.Controls.Add(this.dgvConcedii);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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