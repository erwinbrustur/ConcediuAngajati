namespace ConcediuAngajati
{
    partial class IstoricConcedii
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IstoricConcedii));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.lblIstoric = new System.Windows.Forms.Label();
            this.btnInchidere = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AutoArrange = false;
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.ForeColor = System.Drawing.Color.Maroon;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(21, 63);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(804, 317);
            this.listView1.TabIndex = 3;
            this.listView1.TabStop = false;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Nume";
            this.columnHeader8.Width = 120;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Data Inceput";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data Sfarsit";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tip Concediu";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Inlocuitor";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Comentarii";
            this.columnHeader5.Width = 140;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Stare Concediu";
            this.columnHeader6.Width = 100;
            // 
            // lblIstoric
            // 
            this.lblIstoric.BackColor = System.Drawing.Color.Transparent;
            this.lblIstoric.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIstoric.ForeColor = System.Drawing.Color.Black;
            this.lblIstoric.Location = new System.Drawing.Point(301, 9);
            this.lblIstoric.Name = "lblIstoric";
            this.lblIstoric.Size = new System.Drawing.Size(200, 51);
            this.lblIstoric.TabIndex = 4;
            this.lblIstoric.Text = "Istoric Concedii";
            this.lblIstoric.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblIstoric.Click += new System.EventHandler(this.lblIstoric_Click);
            // 
            // btnInchidere
            // 
            this.btnInchidere.BackColor = System.Drawing.Color.Transparent;
            this.btnInchidere.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInchidere.BackgroundImage")));
            this.btnInchidere.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInchidere.FlatAppearance.BorderSize = 0;
            this.btnInchidere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInchidere.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInchidere.ForeColor = System.Drawing.Color.Transparent;
            this.btnInchidere.Location = new System.Drawing.Point(929, 9);
            this.btnInchidere.Name = "btnInchidere";
            this.btnInchidere.Size = new System.Drawing.Size(29, 32);
            this.btnInchidere.TabIndex = 5;
            this.btnInchidere.TabStop = false;
            this.btnInchidere.UseVisualStyleBackColor = false;
            this.btnInchidere.Click += new System.EventHandler(this.btnInchidere_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(21, 405);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(937, 73);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(26, 16);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 31);
            this.button1.TabIndex = 7;
            this.button1.TabStop = false;
            this.button1.Text = "Inapoi";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IstoricConcedii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(971, 495);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnInchidere);
            this.Controls.Add(this.lblIstoric);
            this.Controls.Add(this.listView1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IstoricConcedii";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IstoricConcedii";
            this.Load += new System.EventHandler(this.IstoricConcedii_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Label lblIstoric;
        private Button btnInchidere;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader8;
        private Panel panel1;
        private Button button1;
    }
}