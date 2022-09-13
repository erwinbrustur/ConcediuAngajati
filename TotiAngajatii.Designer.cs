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
            this.Departament = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.TBNume = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBPrenume = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.CBManager = new System.Windows.Forms.ComboBox();
            this.CBDepartament = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.Inapoi = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.Departament});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(38, 223);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1001, 417);
            this.listView1.TabIndex = 0;
            this.listView1.TabStop = false;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // Nume
            // 
            this.Nume.Text = "Nume";
            this.Nume.Width = 200;
            // 
            // Prenume
            // 
            this.Prenume.Tag = "Prenume";
            this.Prenume.Text = "Prenume";
            this.Prenume.Width = 200;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 200;
            // 
            // Manager
            // 
            this.Manager.Text = "Manager";
            this.Manager.Width = 200;
            // 
            // Departament
            // 
            this.Departament.Text = "Departament";
            this.Departament.Width = 200;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(1043, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 28);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TBNume
            // 
            this.TBNume.Location = new System.Drawing.Point(42, 107);
            this.TBNume.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TBNume.Name = "TBNume";
            this.TBNume.Size = new System.Drawing.Size(202, 27);
            this.TBNume.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(42, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nume:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(250, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prenume:";
            // 
            // TBPrenume
            // 
            this.TBPrenume.Location = new System.Drawing.Point(250, 107);
            this.TBPrenume.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TBPrenume.Name = "TBPrenume";
            this.TBPrenume.Size = new System.Drawing.Size(202, 27);
            this.TBPrenume.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(458, 107);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 31);
            this.button2.TabIndex = 6;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CBManager
            // 
            this.CBManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBManager.FormattingEnabled = true;
            this.CBManager.Location = new System.Drawing.Point(837, 175);
            this.CBManager.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CBManager.Name = "CBManager";
            this.CBManager.Size = new System.Drawing.Size(202, 28);
            this.CBManager.TabIndex = 7;
            this.CBManager.TabStop = false;
            // 
            // CBDepartament
            // 
            this.CBDepartament.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBDepartament.FormattingEnabled = true;
            this.CBDepartament.Location = new System.Drawing.Point(837, 107);
            this.CBDepartament.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CBDepartament.Name = "CBDepartament";
            this.CBDepartament.Size = new System.Drawing.Size(202, 28);
            this.CBDepartament.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Snow;
            this.label3.Location = new System.Drawing.Point(837, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 28);
            this.label3.TabIndex = 9;
            this.label3.Text = "Manager:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(837, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "Departament:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(38, 648);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1001, 49);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(3, 4);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 31);
            this.button3.TabIndex = 0;
            this.button3.TabStop = false;
            this.button3.Text = ">";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Inapoi
            // 
            this.Inapoi.BackColor = System.Drawing.Color.Transparent;
            this.Inapoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Inapoi.Location = new System.Drawing.Point(14, 7);
            this.Inapoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Inapoi.Name = "Inapoi";
            this.Inapoi.Size = new System.Drawing.Size(86, 33);
            this.Inapoi.TabIndex = 12;
            this.Inapoi.TabStop = false;
            this.Inapoi.Text = "Inapoi";
            this.Inapoi.UseVisualStyleBackColor = false;
            this.Inapoi.Click += new System.EventHandler(this.Inapoi_Click);
            // 
            // TotiAngajatii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1081, 709);
            this.Controls.Add(this.Inapoi);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CBDepartament);
            this.Controls.Add(this.CBManager);
            this.Controls.Add(this.TBPrenume);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBNume);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TotiAngajatii";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TotiAngajatii";
            this.Load += new System.EventHandler(this.TotiAngajatii_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView listView1;
        private ColumnHeader Nume;
        private ColumnHeader Prenume;
        private ColumnHeader Email;
        private ColumnHeader Manager;
        private ColumnHeader Departament;
        private Button button1;
        private TextBox TBNume;
        private Label label1;
        private Label label2;
        private TextBox TBPrenume;
        private Button button2;
        private ComboBox CBManager;
        private ComboBox CBDepartament;
        private Label label3;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button3;
        private Button Inapoi;
    }
}