namespace ConcediuAngajati
{
    partial class FormInregistrareIntermediar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInregistrareIntermediar));
            this.tbCNP = new System.Windows.Forms.TextBox();
            this.tbSerie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNumar = new System.Windows.Forms.TextBox();
            this.pbImagineProfil = new System.Windows.Forms.PictureBox();
            this.btnInregistrare = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagineProfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCNP
            // 
            this.tbCNP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCNP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCNP.Location = new System.Drawing.Point(371, 77);
            this.tbCNP.MaxLength = 13;
            this.tbCNP.Name = "tbCNP";
            this.tbCNP.Size = new System.Drawing.Size(226, 27);
            this.tbCNP.TabIndex = 0;
            this.tbCNP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCNP_KeyPress);
            this.tbCNP.Validating += new System.ComponentModel.CancelEventHandler(this.tbCNP_Validating);
            // 
            // tbSerie
            // 
            this.tbSerie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSerie.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbSerie.Location = new System.Drawing.Point(371, 132);
            this.tbSerie.MaxLength = 2;
            this.tbSerie.Name = "tbSerie";
            this.tbSerie.Size = new System.Drawing.Size(226, 27);
            this.tbSerie.TabIndex = 1;
            this.tbSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSerie_KeyPress);
            this.tbSerie.Validating += new System.ComponentModel.CancelEventHandler(this.tbSerie_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(264, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "CNP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(264, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Serie:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(264, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Numar:";
            // 
            // tbNumar
            // 
            this.tbNumar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNumar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbNumar.Location = new System.Drawing.Point(371, 187);
            this.tbNumar.MaxLength = 6;
            this.tbNumar.Name = "tbNumar";
            this.tbNumar.Size = new System.Drawing.Size(226, 27);
            this.tbNumar.TabIndex = 2;
            this.tbNumar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumar_KeyPress);
            this.tbNumar.Validating += new System.ComponentModel.CancelEventHandler(this.tbNumar_Validating);
            // 
            // pbImagineProfil
            // 
            this.pbImagineProfil.BackColor = System.Drawing.Color.DarkGray;
            this.pbImagineProfil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbImagineProfil.Image = ((System.Drawing.Image)(resources.GetObject("pbImagineProfil.Image")));
            this.pbImagineProfil.Location = new System.Drawing.Point(32, 61);
            this.pbImagineProfil.Name = "pbImagineProfil";
            this.pbImagineProfil.Size = new System.Drawing.Size(158, 139);
            this.pbImagineProfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagineProfil.TabIndex = 6;
            this.pbImagineProfil.TabStop = false;
            this.pbImagineProfil.Click += new System.EventHandler(this.pbImagineProfil_Click);
            // 
            // btnInregistrare
            // 
            this.btnInregistrare.BackColor = System.Drawing.Color.Transparent;
            this.btnInregistrare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInregistrare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInregistrare.ForeColor = System.Drawing.Color.White;
            this.btnInregistrare.Location = new System.Drawing.Point(729, 287);
            this.btnInregistrare.Name = "btnInregistrare";
            this.btnInregistrare.Size = new System.Drawing.Size(94, 35);
            this.btnInregistrare.TabIndex = 4;
            this.btnInregistrare.Text = "Inregistrare";
            this.btnInregistrare.UseVisualStyleBackColor = false;
            this.btnInregistrare.Click += new System.EventHandler(this.btnInregistrare_Click);
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.Transparent;
            this.btnX.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnX.BackgroundImage")));
            this.btnX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.ForeColor = System.Drawing.Color.Transparent;
            this.btnX.Location = new System.Drawing.Point(811, 5);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(34, 35);
            this.btnX.TabIndex = 11;
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(32, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "*Adaugati o fotografie";
            // 
            // FormInregistrareIntermediar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(853, 339);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.btnInregistrare);
            this.Controls.Add(this.pbImagineProfil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNumar);
            this.Controls.Add(this.tbSerie);
            this.Controls.Add(this.tbCNP);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInregistrareIntermediar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInregitsrareIntermediar";
            ((System.ComponentModel.ISupportInitialize)(this.pbImagineProfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbCNP;
        private TextBox tbSerie;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbNumar;
        private PictureBox pbImagineProfil;
        private Button btnInregistrare;
        private Button btnX;
        private ErrorProvider errorProvider1;
        private Label label4;
    }
}