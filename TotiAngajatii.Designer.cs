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
            this.PaginaMea = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PaginaMea
            // 
            this.PaginaMea.Location = new System.Drawing.Point(46, 20);
            this.PaginaMea.Name = "PaginaMea";
            this.PaginaMea.Size = new System.Drawing.Size(87, 23);
            this.PaginaMea.TabIndex = 0;
            this.PaginaMea.Text = "PaginaMea";
            this.PaginaMea.UseVisualStyleBackColor = true;
            this.PaginaMea.Click += new System.EventHandler(this.PaginaMea_Click);
            // 
            // TotiAngajatii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PaginaMea);
            this.Name = "TotiAngajatii";
            this.Text = "TotiAngajatii";
            this.ResumeLayout(false);

        }

        #endregion

        private Button PaginaMea;
    }
}