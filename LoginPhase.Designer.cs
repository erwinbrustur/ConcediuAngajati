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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPhase));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnInchidereLP = new System.Windows.Forms.Button();
            this.panel2FA = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cod2FA = new System.Windows.Forms.TextBox();
            this.Btn2FA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2FA.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(717, 368);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Utilizator";
            this.textBox1.Size = new System.Drawing.Size(185, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // textBox2
            // 
            this.textBox2.AcceptsReturn = true;
            this.textBox2.Location = new System.Drawing.Point(717, 397);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '•';
            this.textBox2.PlaceholderText = "Parola";
            this.textBox2.Size = new System.Drawing.Size(185, 23);
            this.textBox2.TabIndex = 1;
            this.textBox2.UseSystemPasswordChar = true;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(717, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Logare";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.Window;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button2.Location = new System.Drawing.Point(798, 439);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 26);
            this.button2.TabIndex = 3;
            this.button2.Text = "Inregistrare";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(365, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(395, 193);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnInchidereLP
            // 
            this.btnInchidereLP.BackColor = System.Drawing.Color.Transparent;
            this.btnInchidereLP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInchidereLP.BackgroundImage")));
            this.btnInchidereLP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInchidereLP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInchidereLP.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInchidereLP.ForeColor = System.Drawing.Color.Silver;
            this.btnInchidereLP.Location = new System.Drawing.Point(890, 4);
            this.btnInchidereLP.Name = "btnInchidereLP";
            this.btnInchidereLP.Size = new System.Drawing.Size(34, 32);
            this.btnInchidereLP.TabIndex = 5;
            this.btnInchidereLP.UseVisualStyleBackColor = false;
            this.btnInchidereLP.Click += new System.EventHandler(this.btnInchidereLP_Click);
            // 
            // panel2FA
            // 
            this.panel2FA.BackColor = System.Drawing.Color.Transparent;
            this.panel2FA.Controls.Add(this.label2);
            this.panel2FA.Controls.Add(this.label1);
            this.panel2FA.Controls.Add(this.Cod2FA);
            this.panel2FA.Controls.Add(this.Btn2FA);
            this.panel2FA.Location = new System.Drawing.Point(717, 368);
            this.panel2FA.Name = "panel2FA";
            this.panel2FA.Size = new System.Drawing.Size(217, 100);
            this.panel2FA.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Display", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.SeaShell;
            this.label2.Location = new System.Drawing.Point(10, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "format din 4 cifre primit pe email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Display", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.SeaShell;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Introduceti codul de autentificare";
            // 
            // Cod2FA
            // 
            this.Cod2FA.BackColor = System.Drawing.Color.SeaShell;
            this.Cod2FA.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Cod2FA.Location = new System.Drawing.Point(15, 58);
            this.Cod2FA.Name = "Cod2FA";
            this.Cod2FA.PlaceholderText = "Cod";
            this.Cod2FA.Size = new System.Drawing.Size(100, 27);
            this.Cod2FA.TabIndex = 3;
            this.Cod2FA.Tag = "";
            this.Cod2FA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Btn2FA
            // 
            this.Btn2FA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn2FA.ForeColor = System.Drawing.Color.SeaShell;
            this.Btn2FA.Location = new System.Drawing.Point(121, 58);
            this.Btn2FA.Name = "Btn2FA";
            this.Btn2FA.Size = new System.Drawing.Size(72, 27);
            this.Btn2FA.TabIndex = 1;
            this.Btn2FA.Text = "OK";
            this.Btn2FA.UseVisualStyleBackColor = true;
            this.Btn2FA.Click += new System.EventHandler(this.Btn2FA_Click);
            // 
            // LoginPhase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(931, 480);
            this.Controls.Add(this.panel2FA);
            this.Controls.Add(this.btnInchidereLP);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginPhase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginPhase";
            this.Load += new System.EventHandler(this.LoginPhase_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginPhase_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2FA.ResumeLayout(false);
            this.panel2FA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private Button btnInchidereLP;
        private Panel panel2FA;
        private Button Btn2FA;
        private TextBox Cod2FA;
        private Label label2;
        private Label label1;
    }
}