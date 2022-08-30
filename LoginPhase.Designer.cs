namespace ConcediuAngajati
{
    partial class LoginPhase
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
            this.Username = new System.Windows.Forms.TextBox();
            this.Parola = new System.Windows.Forms.TextBox();
            this.Logare = new System.Windows.Forms.Button();
            this.Inregistrare = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(550, 303);
            this.Username.Name = "Username";
            this.Username.PlaceholderText = "Utilizator";
            this.Username.Size = new System.Drawing.Size(205, 23);
            this.Username.TabIndex = 0;
            this.Username.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // Parola
            // 
            this.Parola.Location = new System.Drawing.Point(550, 342);
            this.Parola.Name = "Parola";
            this.Parola.PlaceholderText = "Parola";
            this.Parola.Size = new System.Drawing.Size(205, 23);
            this.Parola.TabIndex = 1;
            // 
            // Logare
            // 
            this.Logare.Location = new System.Drawing.Point(550, 396);
            this.Logare.Name = "Logare";
            this.Logare.Size = new System.Drawing.Size(75, 23);
            this.Logare.TabIndex = 2;
            this.Logare.Text = "Logare";
            this.Logare.UseVisualStyleBackColor = true;
            this.Logare.Click += new System.EventHandler(this.Logare_Click);
            // 
            // Inregistrare
            // 
            this.Inregistrare.Location = new System.Drawing.Point(631, 396);
            this.Inregistrare.Name = "Inregistrare";
            this.Inregistrare.Size = new System.Drawing.Size(124, 23);
            this.Inregistrare.TabIndex = 3;
            this.Inregistrare.Text = "Inregistrare";
            this.Inregistrare.UseVisualStyleBackColor = true;
            this.Inregistrare.Click += new System.EventHandler(this.Inregistrare_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(550, 371);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(118, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Retine utilizatorul";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // LoginPhase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Inregistrare);
            this.Controls.Add(this.Logare);
            this.Controls.Add(this.Parola);
            this.Controls.Add(this.Username);
            this.Name = "LoginPhase";
            this.Text = "LoginPhase";
            this.Load += new System.EventHandler(this.LoginPhase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox Username;
        private TextBox Parola;
        private Button Logare;
        private Button Inregistrare;
        private CheckBox checkBox1;
    }
}