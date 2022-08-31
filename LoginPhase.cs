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
                    PaginaPrincipala.PaginaPrincipala ppg = new PaginaPrincipala.PaginaPrincipala();
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

        }


        //parola

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
