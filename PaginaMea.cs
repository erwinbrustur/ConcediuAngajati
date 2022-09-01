using ConcediuAngajati.PaginaPrincipala;
using System.Windows.Forms;

namespace ConcediuAngajati
{
    public partial class PaginaMea : Form
    {
        Angajat angajat;
        public PaginaMea(Angajat a)
        {
            InitializeComponent();
             angajat = a;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaginaPrincipala.PaginaPrincipala pagprin = new PaginaPrincipala.PaginaPrincipala(angajat);
            pagprin.ShowDialog();
            
      
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CerereConcediu cerereConcediu = new CerereConcediu(angajat);
            cerereConcediu.ShowDialog();
            this.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            TotiAngajatii tanga = new TotiAngajatii();
            tanga.ShowDialog();
            this.Show();
        }

        private void Meniu_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        bool esteInchis;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (esteInchis)
            {
                MeniuFlow.Height += 10;
                if (MeniuFlow.Size == MeniuFlow.MaximumSize)
                {
                    timer1.Stop();
                    esteInchis = false;
                }

            }
            else
            {
                MeniuFlow.Height -= 10;
                if (MeniuFlow.Size == MeniuFlow.MinimumSize)
                {
                    timer1.Stop();
                    esteInchis = true;
                }

            }
        }
    }
}