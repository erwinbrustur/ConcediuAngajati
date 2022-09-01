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
            this.components = new System.ComponentModel.Container();
            this.PaginaMea = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.Trimite = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.odihnaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbTipConcediu = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbInlocuitor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbComentarii = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.btnInchidereCC = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PaginaMea
            // 
            this.PaginaMea.BackColor = System.Drawing.Color.DarkSalmon;
            this.PaginaMea.FlatAppearance.BorderSize = 0;
            this.PaginaMea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PaginaMea.ForeColor = System.Drawing.Color.Maroon;
            this.PaginaMea.Location = new System.Drawing.Point(38, 20);
            this.PaginaMea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PaginaMea.Name = "PaginaMea";
            this.PaginaMea.Size = new System.Drawing.Size(101, 31);
            this.PaginaMea.TabIndex = 0;
            this.PaginaMea.Text = "Pagina mea";
            this.PaginaMea.UseVisualStyleBackColor = false;
            this.PaginaMea.Click += new System.EventHandler(this.PaginaMea_Click_1);
            this.PaginaMea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PaginaMea_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(39, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tip concediu :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.Maroon;
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.Gray;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.DarkSalmon;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.Maroon;
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.DarkSalmon;
            this.dateTimePicker1.Location = new System.Drawing.Point(205, 113);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(228, 27);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(415, 41);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // Trimite
            // 
            this.Trimite.BackColor = System.Drawing.Color.DarkSalmon;
            this.Trimite.FlatAppearance.BorderSize = 0;
            this.Trimite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Trimite.ForeColor = System.Drawing.Color.Maroon;
            this.Trimite.Location = new System.Drawing.Point(675, 327);
            this.Trimite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Trimite.Name = "Trimite";
            this.Trimite.Size = new System.Drawing.Size(86, 31);
            this.Trimite.TabIndex = 5;
            this.Trimite.Text = "Trimite";
            this.Trimite.UseVisualStyleBackColor = false;
            this.Trimite.Click += new System.EventHandler(this.Trimite_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.odihnaToolStripMenuItem,
            this.remoteToolStripMenuItem,
            this.medicalToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // odihnaToolStripMenuItem
            // 
            this.odihnaToolStripMenuItem.Name = "odihnaToolStripMenuItem";
            this.odihnaToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.odihnaToolStripMenuItem.Text = "Odihna";
            // 
            // remoteToolStripMenuItem
            // 
            this.remoteToolStripMenuItem.Name = "remoteToolStripMenuItem";
            this.remoteToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.remoteToolStripMenuItem.Text = "Remote";
            // 
            // medicalToolStripMenuItem
            // 
            this.medicalToolStripMenuItem.Name = "medicalToolStripMenuItem";
            this.medicalToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.medicalToolStripMenuItem.Text = "Medical";
            // 
            // cbTipConcediu
            // 
            this.cbTipConcediu.BackColor = System.Drawing.Color.DarkSalmon;
            this.cbTipConcediu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipConcediu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTipConcediu.ForeColor = System.Drawing.Color.Maroon;
            this.cbTipConcediu.FormattingEnabled = true;
            this.cbTipConcediu.Location = new System.Drawing.Point(39, 113);
            this.cbTipConcediu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTipConcediu.Name = "cbTipConcediu";
            this.cbTipConcediu.Size = new System.Drawing.Size(138, 28);
            this.cbTipConcediu.TabIndex = 7;
            this.cbTipConcediu.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkSalmon;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.Maroon;
            this.textBox1.Location = new System.Drawing.Point(730, 113);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 31);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(730, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = " Numar zile concediu :";
            // 
            // cbInlocuitor
            // 
            this.cbInlocuitor.FormattingEnabled = true;
            this.cbInlocuitor.Location = new System.Drawing.Point(470, 212);
            this.cbInlocuitor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbInlocuitor.Name = "cbInlocuitor";
            this.cbInlocuitor.Size = new System.Drawing.Size(138, 28);
            this.cbInlocuitor.TabIndex = 10;
            this.cbInlocuitor.SelectedIndexChanged += new System.EventHandler(this.cbInlocuitor_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Inlocuitor :";
            // 
            // rtbComentarii
            // 
            this.rtbComentarii.BackColor = System.Drawing.Color.DarkSalmon;
            this.rtbComentarii.Location = new System.Drawing.Point(39, 212);
            this.rtbComentarii.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbComentarii.Name = "rtbComentarii";
            this.rtbComentarii.Size = new System.Drawing.Size(394, 127);
            this.rtbComentarii.TabIndex = 12;
            this.rtbComentarii.Text = "";
            this.rtbComentarii.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Comentarii :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "De la :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(470, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Pana la :";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(470, 113);
            this.dateTimePicker3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(228, 27);
            this.dateTimePicker3.TabIndex = 16;
            this.dateTimePicker3.ValueChanged += new System.EventHandler(this.dateTimePicker3_ValueChanged);
            // 
            // btnInchidereCC
            // 
            this.btnInchidereCC.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnInchidereCC.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInchidereCC.ForeColor = System.Drawing.Color.Maroon;
            this.btnInchidereCC.Location = new System.Drawing.Point(865, 8);
            this.btnInchidereCC.Name = "btnInchidereCC";
            this.btnInchidereCC.Size = new System.Drawing.Size(37, 43);
            this.btnInchidereCC.TabIndex = 17;
            this.btnInchidereCC.Text = "X";
            this.btnInchidereCC.UseVisualStyleBackColor = false;
            this.btnInchidereCC.Click += new System.EventHandler(this.btnInchidereCC_Click);
            // 
            // CerereConcediu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.btnInchidereCC);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbComentarii);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbInlocuitor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbTipConcediu);
            this.Controls.Add(this.Trimite);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PaginaMea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CerereConcediu";
            this.Text = "CerereConcediu";
            this.Load += new System.EventHandler(this.CerereConcediu_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button PaginaMea;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Button Trimite;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem odihnaToolStripMenuItem;
        private ToolStripMenuItem remoteToolStripMenuItem;
        private ToolStripMenuItem medicalToolStripMenuItem;
        private ComboBox cbTipConcediu;
        private Label label2;
        public TextBox textBox1;
        private ComboBox cbInlocuitor;
        private Label label3;
        private RichTextBox rtbComentarii;
        private Label label4;
        private Label label5;
        private Label label6;
        private DateTimePicker dateTimePicker3;
        private Button btnInchidereCC;
    }
}