using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcediuAngajati.PaginaPrincipala
{
    public partial class PaginaPrincipala : Form
    {
        public PaginaPrincipala()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Concedii_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool esteInchis;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (esteInchis)
            {
                DropDown.Height += 10;
                if(DropDown.Size == DropDown.MaximumSize)
                {
                    timer1.Stop();
                    esteInchis = false;
                }

            }else
            {
                DropDown.Height -= 10;
                if (DropDown.Size == DropDown.MinimumSize)
                {
                    timer1.Stop();
                    esteInchis = true;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
