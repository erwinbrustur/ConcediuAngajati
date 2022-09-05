namespace ConcediuAngajati
{
    partial class TotiAngajatii
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TotiAngajatii));
            this.listView1 = new System.Windows.Forms.ListView();
            this.Nume = new System.Windows.Forms.ColumnHeader();
            this.Prenume = new System.Windows.Forms.ColumnHeader();
            this.Email = new System.Windows.Forms.ColumnHeader();
            this.Manager = new System.Windows.Forms.ColumnHeader();
            this.Echipa = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.BackgroundImageTiled = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nume,
            this.Prenume,
            this.Email,
            this.Manager,
            this.Echipa});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 83);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(643, 355);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // Nume
            // 
            this.Nume.Text = "Nume";
            this.Nume.Width = 100;
            // 
            // Prenume
            // 
            this.Prenume.Tag = "Prenume";
            this.Prenume.Text = "Prenume";
            this.Prenume.Width = 100;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 200;
            // 
            // Manager
            // 
            this.Manager.Text = "Manager";
            this.Manager.Width = 100;
            // 
            // Echipa
            // 
            this.Echipa.Text = "Departament";
            this.Echipa.Width = 150;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "Inapoi la pagina principala";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // TotiAngajatii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(681, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TotiAngajatii";
            this.Text = "TotiAngajatii";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listView1;
        private ColumnHeader Nume;
        private ColumnHeader Prenume;
        private ColumnHeader Email;
        private ColumnHeader Manager;
        private ColumnHeader Echipa;
        private Button button1;
    }
}