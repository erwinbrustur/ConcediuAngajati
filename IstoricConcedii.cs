using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcediuAngajati
{
    public partial class FormInregitsrareIntermediar : Form
    {
        public FormInregitsrareIntermediar()
        {
            InitializeComponent();
        }


        private void btnAdaugaImagine_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                PictureBox pictureBox = new PictureBox();
                //pictureBox.Image = dlg.
            }

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
