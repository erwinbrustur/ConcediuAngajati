using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Reflection.Metadata;

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
        public static string Hash(string Value)
        {
            using var hash = SHA256.Create();
            var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(Value));
            return Convert.ToHexString(byteArray);
        }

        public Angajat ExtractAngajatFromSql(string user)
        {
            SqlConnection conexiune = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int");
            conexiune.Open();
            string CommandLine = "SELECT * FROM Angajat WHERE email='" + user + "@totalsoft.ro'";
            SqlCommand cmd = new SqlCommand(CommandLine, conexiune);
            SqlDataReader dr = cmd.ExecuteReader();
            Angajat angajat = null;
            if (dr.Read())
            {
                // Boolean d = Convert.ToBoolean(dr[12].ToString());
                // MessageBox.Show(dr[5].ToString());

                //  MessageBox.Show(Convert.ToInt32(dr[0].ToString()) + dr[1].ToString() + dr[2].ToString()+ dr[3].ToString()+ dr[4].ToString()+ Convert.ToDateTime(dr[5].ToString())+ Convert.ToDateTime(dr[6].ToString())+ dr[7].ToString()+ dr[8].ToString()+ dr[9].ToString(), dr[10].ToString()+ Convert.ToBoolean(dr[12].ToString())+ Convert.ToInt32(dr[13].ToString()));
                int id = Convert.ToInt32(dr[0].ToString());
                string nume = dr[1].ToString();
                string prenume = dr[2].ToString();
                string email = dr[3].ToString();
                string parola = dr[4].ToString();
                DateTime dataAngajare = Convert.ToDateTime(dr[5].ToString());
                DateTime dataNastere = Convert.ToDateTime(dr[6].ToString());
                string cnp = dr[7].ToString();
                string serie = dr[8].ToString();
                string numar = dr[9].ToString();
                string telefon = dr[10].ToString();
                byte[] poza = (byte[])dr[11];
                bool esteAdmin = Convert.ToBoolean(dr[12].ToString());
                int managerId = Convert.ToInt32(dr[13].ToString());
                //MessageBox.Show(dr[13].ToString());
                angajat = new Angajat(id,nume,prenume,email,parola,dataAngajare,dataNastere,cnp,serie,numar,telefon,poza,esteAdmin,managerId);
            }
            conexiune.Close();
            return angajat;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String user = textBox1.Text;

            SqlConnection sqlConnection = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int");

            sqlConnection.Open();

            // user din textbox verifica cu user din sql
            SqlCommand UserCheck = new SqlCommand(@"SELECT parola FROM Angajat WHERE email = '" + user +"@totalsoft.ro'",sqlConnection);
            //String parolaDinbaza = (String)UserCheck.ExecuteScalar();
            //MessageBox.Show(parolaDinbaza);
            
            SqlDataReader reader = UserCheck.ExecuteReader();
            
            String parolaDinbaza = "";

            if (reader.Read())
            {

                parolaDinbaza = reader[0].ToString();

                if (parolaDinbaza == Hash(textBox2.Text))
                {
                    string nume, prenume, email, parola, nrTelefon, cnp, serie, no;
                    DateTime dataAngajare, dataNasterii;
                    byte[] poza;
                    bool esteAdmin;
                    int managerId,id;



                    Angajat angajat = ExtractAngajatFromSql(user);

                    PaginaPrincipala.PaginaPrincipala ppg = new PaginaPrincipala.PaginaPrincipala(angajat);
                   // MessageBox.Show("User: " + angajat.Id + angajat.Nume + angajat.Prenume + angajat.Email + angajat.ManagerId);
                    ppg.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Parola incorecta!");
                }

            }
            else
            {
                MessageBox.Show("Utilizator gresit!");
            }
                //MessageBox.Show(parolaDinbaza);
            
          

            sqlConnection.Close();
            
            
            
        }

        // user
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
                //Opacity = 0.2;
        }


        //parola

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoginPhase_Load(object sender, EventArgs e)
        {

        }

        private void btnInchidereLP_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }
    }
}
