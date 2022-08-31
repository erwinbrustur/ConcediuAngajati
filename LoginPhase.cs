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
        public string ExtractFromSql(string parametru,string user)
        {
            SqlConnection conexiune = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int");
            conexiune.Open();
            string CommandLine = "SELECT " + parametru + " FROM Angajat WHERE email='" + user + "totalsoft.ro'";
            SqlCommand cmd = new SqlCommand(CommandLine,conexiune);
            SqlDataReader dr = cmd.ExecuteReader();
            string parametrulDinBaza="";
            if (dr.Read()) {
                parametrulDinBaza = dr[0].ToString(); }
            conexiune.Close();
            return parametrulDinBaza;
        }
        public int ExtractIntFromSql(string parametru, string user)
        {
            SqlConnection conexiune = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int");
            conexiune.Open();
            string CommandLine = "SELECT " + parametru + " FROM Angajat WHERE email='" + user + "totalsoft.ro'";
            SqlCommand cmd = new SqlCommand(CommandLine, conexiune);
            SqlDataReader dr = cmd.ExecuteReader();
            int parametrulDinBaza = 0;
            if (dr.Read())
            {
                parametrulDinBaza = int.Parse((string)dr[0]);
            }
            conexiune.Close();
            return parametrulDinBaza;
        }
        public bool ExtractBoolFromSql(string parametru, string user)
        {
            SqlConnection conexiune = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int");
            conexiune.Open();
            string CommandLine = "SELECT " + parametru + " FROM Angajat WHERE email='" + user + "totalsoft.ro'";
            SqlCommand cmd = new SqlCommand(CommandLine, conexiune);
            SqlDataReader dr = cmd.ExecuteReader();
            bool parametrulDinBaza = true;
            if (dr.Read())
            {
                parametrulDinBaza = bool.Parse((string)dr[0]);
            }
            conexiune.Close();
            return parametrulDinBaza;
        }
        public DateTime ExtractDateFromSql(string parametru, string user)
        {
            SqlConnection conexiune = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int");
            conexiune.Open();
            string CommandLine = "SELECT " + parametru + " FROM Angajat WHERE email='" + user + "totalsoft.ro'";
            SqlCommand cmd = new SqlCommand(CommandLine, conexiune);
            SqlDataReader dr = cmd.ExecuteReader();
            DateTime parametrulDinBaza = DateTime.Now;
            if (dr.Read())
            {
                parametrulDinBaza = DateTime.Parse((string)dr[0]);
            }
            conexiune.Close();
            return parametrulDinBaza;
        }
        public byte[] ExtractByteArrFromSql(string parametru, string user)
        {
            SqlConnection conexiune = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int");
            conexiune.Open();
            string CommandLine = "SELECT " + parametru + " FROM Angajat WHERE email='" + user + "totalsoft.ro'";
            SqlCommand cmd = new SqlCommand(CommandLine,conexiune);
            SqlDataReader dr = cmd.ExecuteReader();
            byte[] parametrulDinBaza=Encoding.ASCII.GetBytes("");
            if (dr.Read())
            {
                parametrulDinBaza = (byte[])dr[0];
            }
            conexiune.Close();
            return parametrulDinBaza;
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
                    string nume, prenume, email, parola, nrTelefon, cnp, serie, no;
                    DateTime dataAngajare, dataNasterii;
                    byte[] poza;
                    bool esteAdmin;
                    int managerId,id;

                    
                    id = ExtractIntFromSql("id", textBox1.Text);
                    managerId = ExtractIntFromSql("managerId", textBox1.Text);
                    esteAdmin = ExtractBoolFromSql("esteAdmin", textBox1.Text);
                    nume = ExtractFromSql("nume",textBox1.Text);
                    prenume = ExtractFromSql("prenume", textBox1.Text);
                    email = ExtractFromSql("email", textBox1.Text);
                    parola = ExtractFromSql("parola", textBox1.Text);
                    nrTelefon = ExtractFromSql("nrTelefon", textBox1.Text);
                    dataAngajare = ExtractDateFromSql("dataAngajare", textBox1.Text);
                    dataNasterii = ExtractDateFromSql("dataNasterii", textBox1.Text);
                    cnp = ExtractFromSql("cnp", textBox1.Text);
                    serie = ExtractFromSql("serie", textBox1.Text);
                    no = ExtractFromSql("no", textBox1.Text);
                    poza = ExtractByteArrFromSql("poza", textBox1.Text);
                    
                    Angajat angajat = new Angajat(id,nume, prenume, email, parola,  dataAngajare, dataNasterii, cnp, serie, no, nrTelefon, poza,esteAdmin,managerId);
                    PaginaPrincipala.PaginaPrincipala ppg = new PaginaPrincipala.PaginaPrincipala(angajat);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
