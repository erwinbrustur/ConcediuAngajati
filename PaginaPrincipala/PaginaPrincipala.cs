using ConcediuAngajati.CalendarMagic;
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

        private void button5_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (esteInchis)
            {
                DropConcedii.Height += 10;
                if (DropConcedii.Size == DropConcedii.MaximumSize)
                {
                    timer2.Stop();
                    esteInchis = false;
                }

            }
            else
            {
                DropConcedii.Height -= 10;
                if (DropConcedii.Size == DropConcedii.MinimumSize)
                {
                    timer2.Stop();
                    esteInchis = true;
                }

            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(esteInchis)
            {
                AdminDrop.Height += 10;
                if (AdminDrop.Size == AdminDrop.MaximumSize)
                {
                    timer3.Stop();
                    esteInchis = false;
                }

            }
            else
            {
                AdminDrop.Height -= 10;
                if (AdminDrop.Size == AdminDrop.MinimumSize)
                {
                    timer3.Stop();
                    esteInchis = true;
                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PaginaMea pg = new PaginaMea();
            pg.Show();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Afisare cerere
            CerereConcediu con = new CerereConcediu();
            con.Show();

            //Afiseaza calendarul magic
            CalendarMagic.CalendarMagic Calendar = new CalendarMagic.CalendarMagic();
            Calendar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Afisare istoric
            IstoricConcediu coni = new IstoricConcediu();
            coni.Show();
        }
    }
}
