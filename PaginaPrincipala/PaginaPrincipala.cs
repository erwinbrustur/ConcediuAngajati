using System.Data.SqlClient;

namespace ConcediuAngajati.PaginaPrincipala
{
    public partial class PaginaPrincipala : Form
    {
        Angajat angajat;
        public PaginaPrincipala(Angajat a)
        {
            InitializeComponent();
            angajat = a;
            MemoryStream ms = new MemoryStream(a.Poza);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Concedii_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private bool esteInchis1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (esteInchis1)
            {
                DropDown.Height += 10;
                if(DropDown.Size == DropDown.MaximumSize)
                {
                    timer1.Stop();
                    esteInchis1 = false;
                }

            }else
            {
                DropDown.Height -= 10;
                if (DropDown.Size == DropDown.MinimumSize)
                {
                    timer1.Stop();
                    esteInchis1 = true;
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


        private bool esteInchis2;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (esteInchis2)
            {
                DropConcedii.Height += 10;
                if (DropConcedii.Size == DropConcedii.MaximumSize)
                {
                    timer2.Stop();
                    esteInchis2 = false;
                }

            }
            else
            {
                DropConcedii.Height -= 10;
                if (DropConcedii.Size == DropConcedii.MinimumSize)
                {
                    timer2.Stop();
                    esteInchis2 = true;
                }

            }
        }

        private bool esteInchis3;
        private void timer3_Tick(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            PaginaMea pg = new PaginaMea(angajat);
            pg.Show();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            //Afisare cerere
            CerereConcediu con = new CerereConcediu(angajat);
            con.Show();

            //Afiseaza calendarul magic
            CalendarMagic.CalendarMagic Calendar = new CalendarMagic.CalendarMagic();
            Calendar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            //Afisare istoric
            IstoricConcedii coni = new IstoricConcedii(angajat);
            coni.Show();
        }

        private void CereriConcedii_Click(object sender, EventArgs e)
        {
            //acest buton o sa fie vizibil pentru manager si admin
            timer4.Start();
                
        }

        private void PaginaPrincipala_Load(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int");
            cnx.Open();
            SqlCommand managerID = new SqlCommand("select managerId from Angajat group by managerId",cnx);
            SqlDataReader reader = managerID.ExecuteReader();
            List<string> iduri= new List<string>();


            while (reader.Read())
            {
                iduri.Add(reader[0].ToString());
            }

            foreach(string id in iduri)
            {
                if (angajat.Id.ToString() == id)
                {
                    CereriConcediBut.Show();
                    DropConcedii.Show();
                }
                else
                {
                    CereriConcediBut.Hide();
                    DropConcedii.Hide();
                }
                cnx.Close();
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdministrareAngajati admn = new AdministrareAngajati();
            admn.Show();
            
        }
        private bool esteInchis4;
        private void timer4_Tick(object sender, EventArgs e)
        {

            if (esteInchis4)
            {
                CereriConcediBut.Height += 10;
                if (CereriConcediBut.Size == CereriConcediBut.MaximumSize)
                {
                    timer4.Stop();
                    esteInchis4 = false;
                }

            }
            else
            {
                CereriConcediBut.Height -= 10;
                if (CereriConcediBut.Size == CereriConcediBut.MinimumSize)
                {
                    timer4.Stop();
                    esteInchis4 = true;
                }

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //concediuAngajati
            this.Close();
            ConcediuAngajati cang = new ConcediuAngajati(angajat);
            cang.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //concediu manageri
            ConcediuManager cmng = new ConcediuManager();
            cmng.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnInchiderePP_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            LoginPhase login = new LoginPhase();
            login.Show();
            this.Close();
        }
    }
}
