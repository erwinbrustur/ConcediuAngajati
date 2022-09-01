namespace ConcediuAngajati
{
    partial class AdministrareAngajati
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministrareAngajati));
            this.BtnPaginaPrincipala = new System.Windows.Forms.Button();
            this.buttonAdaugareAngajat = new System.Windows.Forms.Button();
            this.buttonModificareManageri = new System.Windows.Forms.Button();
            this.panelAdaugareAngajat = new System.Windows.Forms.Panel();
            this.ConfParola = new System.Windows.Forms.TextBox();
            this.Parola = new System.Windows.Forms.TextBox();
            this.BtnAdaugareAngajat = new System.Windows.Forms.Button();
            this.Poza = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NrTel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CNP = new System.Windows.Forms.TextBox();
            this.Nr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Serie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Prenume = new System.Windows.Forms.TextBox();
            this.LblPrenume = new System.Windows.Forms.Label();
            this.Nume = new System.Windows.Forms.TextBox();
            this.LblNume = new System.Windows.Forms.Label();
            this.panelModificareManageri = new System.Windows.Forms.Panel();
            this.panelAdaugareAngajat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Poza)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnPaginaPrincipala
            // 
            this.BtnPaginaPrincipala.Location = new System.Drawing.Point(12, 12);
            this.BtnPaginaPrincipala.Name = "BtnPaginaPrincipala";
            this.BtnPaginaPrincipala.Size = new System.Drawing.Size(164, 34);
            this.BtnPaginaPrincipala.TabIndex = 0;
            this.BtnPaginaPrincipala.Text = "Inapoi la pagina principala";
            this.BtnPaginaPrincipala.UseVisualStyleBackColor = true;
            // 
            // buttonAdaugareAngajat
            // 
            this.buttonAdaugareAngajat.Location = new System.Drawing.Point(12, 78);
            this.buttonAdaugareAngajat.Name = "buttonAdaugareAngajat";
            this.buttonAdaugareAngajat.Size = new System.Drawing.Size(125, 31);
            this.buttonAdaugareAngajat.TabIndex = 1;
            this.buttonAdaugareAngajat.Text = "Adaugare angajat";
            this.buttonAdaugareAngajat.UseVisualStyleBackColor = true;
            this.buttonAdaugareAngajat.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonModificareManageri
            // 
            this.buttonModificareManageri.Location = new System.Drawing.Point(143, 78);
            this.buttonModificareManageri.Name = "buttonModificareManageri";
            this.buttonModificareManageri.Size = new System.Drawing.Size(125, 31);
            this.buttonModificareManageri.TabIndex = 2;
            this.buttonModificareManageri.Text = "Modificare manageri";
            this.buttonModificareManageri.UseVisualStyleBackColor = true;
            this.buttonModificareManageri.Click += new System.EventHandler(this.buttonModificareManageri_Click);
            // 
            // panelAdaugareAngajat
            // 
            this.panelAdaugareAngajat.BackColor = System.Drawing.Color.White;
            this.panelAdaugareAngajat.Controls.Add(this.ConfParola);
            this.panelAdaugareAngajat.Controls.Add(this.Parola);
            this.panelAdaugareAngajat.Controls.Add(this.BtnAdaugareAngajat);
            this.panelAdaugareAngajat.Controls.Add(this.Poza);
            this.panelAdaugareAngajat.Controls.Add(this.label7);
            this.panelAdaugareAngajat.Controls.Add(this.label6);
            this.panelAdaugareAngajat.Controls.Add(this.NrTel);
            this.panelAdaugareAngajat.Controls.Add(this.label5);
            this.panelAdaugareAngajat.Controls.Add(this.groupBox1);
            this.panelAdaugareAngajat.Controls.Add(this.Email);
            this.panelAdaugareAngajat.Controls.Add(this.label2);
            this.panelAdaugareAngajat.Controls.Add(this.Prenume);
            this.panelAdaugareAngajat.Controls.Add(this.LblPrenume);
            this.panelAdaugareAngajat.Controls.Add(this.Nume);
            this.panelAdaugareAngajat.Controls.Add(this.LblNume);
            this.panelAdaugareAngajat.Location = new System.Drawing.Point(0, 115);
            this.panelAdaugareAngajat.Name = "panelAdaugareAngajat";
            this.panelAdaugareAngajat.Size = new System.Drawing.Size(803, 382);
            this.panelAdaugareAngajat.TabIndex = 3;
            this.panelAdaugareAngajat.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAdaugareAngajat_Paint);
            // 
            // ConfParola
            // 
            this.ConfParola.BackColor = System.Drawing.Color.DarkSalmon;
            this.ConfParola.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfParola.ForeColor = System.Drawing.Color.Maroon;
            this.ConfParola.Location = new System.Drawing.Point(349, 249);
            this.ConfParola.Multiline = true;
            this.ConfParola.Name = "ConfParola";
            this.ConfParola.PasswordChar = '•';
            this.ConfParola.Size = new System.Drawing.Size(143, 23);
            this.ConfParola.TabIndex = 9;
            // 
            // Parola
            // 
            this.Parola.BackColor = System.Drawing.Color.DarkSalmon;
            this.Parola.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Parola.ForeColor = System.Drawing.Color.Maroon;
            this.Parola.Location = new System.Drawing.Point(94, 249);
            this.Parola.Multiline = true;
            this.Parola.Name = "Parola";
            this.Parola.PasswordChar = '•';
            this.Parola.Size = new System.Drawing.Size(143, 23);
            this.Parola.TabIndex = 8;
            // 
            // BtnAdaugareAngajat
            // 
            this.BtnAdaugareAngajat.BackColor = System.Drawing.Color.DarkSalmon;
            this.BtnAdaugareAngajat.FlatAppearance.BorderSize = 0;
            this.BtnAdaugareAngajat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdaugareAngajat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAdaugareAngajat.ForeColor = System.Drawing.Color.Maroon;
            this.BtnAdaugareAngajat.Location = new System.Drawing.Point(568, 222);
            this.BtnAdaugareAngajat.Name = "BtnAdaugareAngajat";
            this.BtnAdaugareAngajat.Size = new System.Drawing.Size(131, 50);
            this.BtnAdaugareAngajat.TabIndex = 20;
            this.BtnAdaugareAngajat.Text = "Adaugare angajat";
            this.BtnAdaugareAngajat.UseVisualStyleBackColor = false;
            this.BtnAdaugareAngajat.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Poza
            // 
            this.Poza.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Poza.BackgroundImage")));
            this.Poza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Poza.Location = new System.Drawing.Point(558, 45);
            this.Poza.Name = "Poza";
            this.Poza.Size = new System.Drawing.Size(150, 125);
            this.Poza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Poza.TabIndex = 19;
            this.Poza.TabStop = false;
            this.Poza.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(243, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Confirmare parola";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(48, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Parola";
            // 
            // NrTel
            // 
            this.NrTel.BackColor = System.Drawing.Color.DarkSalmon;
            this.NrTel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NrTel.ForeColor = System.Drawing.Color.Maroon;
            this.NrTel.Location = new System.Drawing.Point(360, 91);
            this.NrTel.Multiline = true;
            this.NrTel.Name = "NrTel";
            this.NrTel.Size = new System.Drawing.Size(143, 23);
            this.NrTel.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(254, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Numar de telefon";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Snow;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CNP);
            this.groupBox1.Controls.Add(this.Nr);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Serie);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(48, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 93);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carte de identitate";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Serie";
            // 
            // CNP
            // 
            this.CNP.BackColor = System.Drawing.Color.DarkSalmon;
            this.CNP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CNP.ForeColor = System.Drawing.Color.Maroon;
            this.CNP.Location = new System.Drawing.Point(46, 59);
            this.CNP.Multiline = true;
            this.CNP.Name = "CNP";
            this.CNP.Size = new System.Drawing.Size(143, 23);
            this.CNP.TabIndex = 7;
            // 
            // Nr
            // 
            this.Nr.BackColor = System.Drawing.Color.DarkSalmon;
            this.Nr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Nr.ForeColor = System.Drawing.Color.Maroon;
            this.Nr.Location = new System.Drawing.Point(301, 19);
            this.Nr.Multiline = true;
            this.Nr.Name = "Nr";
            this.Nr.Size = new System.Drawing.Size(143, 23);
            this.Nr.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(11, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "CNP";
            // 
            // Serie
            // 
            this.Serie.BackColor = System.Drawing.Color.DarkSalmon;
            this.Serie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Serie.ForeColor = System.Drawing.Color.Maroon;
            this.Serie.Location = new System.Drawing.Point(46, 19);
            this.Serie.Multiline = true;
            this.Serie.Name = "Serie";
            this.Serie.Size = new System.Drawing.Size(143, 23);
            this.Serie.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(251, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Numar";
            // 
            // Email
            // 
            this.Email.BackColor = System.Drawing.Color.DarkSalmon;
            this.Email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Email.ForeColor = System.Drawing.Color.Maroon;
            this.Email.Location = new System.Drawing.Point(360, 42);
            this.Email.Multiline = true;
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(143, 23);
            this.Email.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(249, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nume de utilizator";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Prenume
            // 
            this.Prenume.BackColor = System.Drawing.Color.DarkSalmon;
            this.Prenume.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Prenume.ForeColor = System.Drawing.Color.Maroon;
            this.Prenume.Location = new System.Drawing.Point(94, 88);
            this.Prenume.Multiline = true;
            this.Prenume.Name = "Prenume";
            this.Prenume.Size = new System.Drawing.Size(143, 23);
            this.Prenume.TabIndex = 2;
            this.Prenume.TextChanged += new System.EventHandler(this.Prenume_TextChanged);
            // 
            // LblPrenume
            // 
            this.LblPrenume.AutoSize = true;
            this.LblPrenume.ForeColor = System.Drawing.Color.Maroon;
            this.LblPrenume.Location = new System.Drawing.Point(33, 91);
            this.LblPrenume.Name = "LblPrenume";
            this.LblPrenume.Size = new System.Drawing.Size(55, 15);
            this.LblPrenume.TabIndex = 2;
            this.LblPrenume.Text = "Prenume";
            this.LblPrenume.Click += new System.EventHandler(this.LblPrenume_Click);
            // 
            // Nume
            // 
            this.Nume.BackColor = System.Drawing.Color.DarkSalmon;
            this.Nume.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Nume.ForeColor = System.Drawing.Color.Maroon;
            this.Nume.Location = new System.Drawing.Point(94, 42);
            this.Nume.Multiline = true;
            this.Nume.Name = "Nume";
            this.Nume.Size = new System.Drawing.Size(143, 23);
            this.Nume.TabIndex = 1;
            this.Nume.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LblNume
            // 
            this.LblNume.AutoSize = true;
            this.LblNume.ForeColor = System.Drawing.Color.Maroon;
            this.LblNume.Location = new System.Drawing.Point(48, 45);
            this.LblNume.Name = "LblNume";
            this.LblNume.Size = new System.Drawing.Size(40, 15);
            this.LblNume.TabIndex = 0;
            this.LblNume.Text = "Nume";
            this.LblNume.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelModificareManageri
            // 
            this.panelModificareManageri.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelModificareManageri.Location = new System.Drawing.Point(0, 115);
            this.panelModificareManageri.Name = "panelModificareManageri";
            this.panelModificareManageri.Size = new System.Drawing.Size(803, 382);
            this.panelModificareManageri.TabIndex = 4;
            // 
            // AdministrareAngajati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.panelModificareManageri);
            this.Controls.Add(this.panelAdaugareAngajat);
            this.Controls.Add(this.buttonModificareManageri);
            this.Controls.Add(this.buttonAdaugareAngajat);
            this.Controls.Add(this.BtnPaginaPrincipala);
            this.DoubleBuffered = true;
            this.Name = "AdministrareAngajati";
            this.Text = "AdministrareAngajati";
            this.Load += new System.EventHandler(this.AdministrareAngajati_Load);
            this.panelAdaugareAngajat.ResumeLayout(false);
            this.panelAdaugareAngajat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Poza)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnPaginaPrincipala;
        private Button buttonAdaugareAngajat;
        private Button buttonModificareManageri;
        private Panel panelAdaugareAngajat;
        private Panel panelModificareManageri;
        private Label LblNume;
        private TextBox CNP;
        private Label label1;
        private TextBox Email;
        private Label label2;
        private TextBox Prenume;
        private Label LblPrenume;
        private TextBox Nume;
        private GroupBox groupBox1;
        private Label label4;
        private TextBox Nr;
        private TextBox Serie;
        private Label label3;
        private PictureBox Poza;
        private Label label7;
        private Label label6;
        private TextBox NrTel;
        private Label label5;
        private Button BtnAdaugareAngajat;
        private TextBox ConfParola;
        private TextBox Parola;
    }
}