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
    public partial class AdministrareAngajati : Form
    {
       
        public AdministrareAngajati()
        {
            InitializeComponent();
     
        }

    

        private void button1_Click(object sender, EventArgs e)
        {

            if (panelAdaugareAngajat.Visible == true)
                panelAdaugareAngajat.Hide();
            else
                panelAdaugareAngajat.Show();   
  
        }

        private void buttonModificareManageri_Click(object sender, EventArgs e)
        {
            if (panelModificareManageri.Visible == true)
                panelModificareManageri.Hide();
            else
                panelModificareManageri.Show();
        }

        private void panelAdaugareAngajat_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdministrareAngajati_Load(object sender, EventArgs e)
        {

        }
    }
}
