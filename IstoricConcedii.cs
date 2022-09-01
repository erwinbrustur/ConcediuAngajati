using ConcediuAngajati.PaginaPrincipala;
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
    public partial class IstoricConcedii : Form
    {
        Angajat angajat;
        public IstoricConcedii(Angajat a)
        {
            InitializeComponent();
            angajat = a;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInchidere_Click(object sender, EventArgs e)
        {
            PaginaPrincipala.PaginaPrincipala paginap = new PaginaPrincipala.PaginaPrincipala(angajat);
            paginap.Show();
            this.Close();
        }
    }
}
