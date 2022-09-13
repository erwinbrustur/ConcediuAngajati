namespace ConcediuAngajati.CalendarMagic
{
    partial class UserControlDays
    { /// <summary> 
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.zi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zi
            // 
            this.zi.AutoSize = true;
            this.zi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.zi.Location = new System.Drawing.Point(4, 12);
            this.zi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.zi.Name = "zi";
            this.zi.Size = new System.Drawing.Size(27, 20);
            this.zi.TabIndex = 0;
            this.zi.Text = "00";
            // 
            // UserControlDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zi);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "UserControlDays";
            this.Size = new System.Drawing.Size(94, 72);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label zi;
    }
}
