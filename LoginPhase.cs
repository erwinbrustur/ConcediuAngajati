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
    public partial class LoginPhase : Form
    {
        public LoginPhase()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inregistrare ing = new Inregistrare();
            ing.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaginaPrincipala.PaginaPrincipala  ppg = new PaginaPrincipala.PaginaPrincipala();
            ppg.Show();
        }
    }
}
