namespace ConcediuAngajati
{
    partial class CerereConcediu
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
            this.PaginaMea = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.Trimite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PaginaMea
            // 
            this.PaginaMea.Location = new System.Drawing.Point(33, 15);
            this.PaginaMea.Name = "PaginaMea";
            this.PaginaMea.Size = new System.Drawing.Size(88, 23);
            this.PaginaMea.TabIndex = 0;
            this.PaginaMea.Text = "Pagina mea";
            this.PaginaMea.UseVisualStyleBackColor = true;
            this.PaginaMea.Click += new System.EventHandler(this.PaginaMea_Click_1);
            this.PaginaMea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PaginaMea_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(33, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Tip concediu";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tip concediu :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(179, 85);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(411, 85);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // Trimite
            // 
            this.Trimite.Location = new System.Drawing.Point(591, 245);
            this.Trimite.Name = "Trimite";
            this.Trimite.Size = new System.Drawing.Size(75, 23);
            this.Trimite.TabIndex = 5;
            this.Trimite.Text = "Trimite";
            this.Trimite.UseVisualStyleBackColor = true;
            this.Trimite.Click += new System.EventHandler(this.Trimite_Click);
            // 
            // CerereConcediu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Trimite);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PaginaMea);
            this.Name = "CerereConcediu";
            this.Text = "CerereConcediu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button PaginaMea;
        private TextBox textBox1;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Button Trimite;
    }
}