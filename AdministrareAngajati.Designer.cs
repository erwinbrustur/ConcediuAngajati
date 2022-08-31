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
            this.BtnPaginaPrincipala = new System.Windows.Forms.Button();
            this.buttonAdaugareAngajat = new System.Windows.Forms.Button();
            this.buttonModificareManageri = new System.Windows.Forms.Button();
            this.panelAdaugareAngajat = new System.Windows.Forms.Panel();
            this.panelModificareManageri = new System.Windows.Forms.Panel();
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
            this.panelAdaugareAngajat.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelAdaugareAngajat.Location = new System.Drawing.Point(0, 115);
            this.panelAdaugareAngajat.Name = "panelAdaugareAngajat";
            this.panelAdaugareAngajat.Size = new System.Drawing.Size(803, 382);
            this.panelAdaugareAngajat.TabIndex = 3;
            this.panelAdaugareAngajat.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAdaugareAngajat_Paint);
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
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.panelModificareManageri);
            this.Controls.Add(this.panelAdaugareAngajat);
            this.Controls.Add(this.buttonModificareManageri);
            this.Controls.Add(this.buttonAdaugareAngajat);
            this.Controls.Add(this.BtnPaginaPrincipala);
            this.Name = "AdministrareAngajati";
            this.Text = "AdministrareAngajati";
            this.Load += new System.EventHandler(this.AdministrareAngajati_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnPaginaPrincipala;
        private Button buttonAdaugareAngajat;
        private Button buttonModificareManageri;
        private Panel panelAdaugareAngajat;
        private Panel panelModificareManageri;
    }
}