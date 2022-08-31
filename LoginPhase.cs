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

            String user = textBox1.Text;

            SqlConnection sqlConnection = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int");

            sqlConnection.Open();

            // user din textbox verifica cu user din sql
            SqlCommand UserCheck = new SqlCommand(@"SELECT parola FROM Angajat WHERE email = '" + user +"@totalsoft.ro'",sqlConnection);
            //String parolaDinbaza = (String)UserCheck.ExecuteScalar();
            //MessageBox.Show(parolaDinbaza);
            
            SqlDataReader reader = UserCheck.ExecuteReader();
            
                String parolaDinbaza = reader[0].ToString();
                MessageBox.Show(parolaDinbaza);
            


            sqlConnection.Close();
            
            
            //PaginaPrincipala.PaginaPrincipala  ppg = new PaginaPrincipala.PaginaPrincipala();
            //ppg.Show();
            //this.Hide();
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
