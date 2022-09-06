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
using ProiectASP.Models;
using Newtonsoft.Json;

namespace ConcediuAngajati
{
    public partial class LoginPhase : Form
    {
        static readonly HttpClient client = new HttpClient();
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


        public async void extragereAngajatByUsername()
        {
            try
            {

                HttpResponseMessage response = await client.GetAsync("http://localhost:5096/GetAngajatByUsername?username=" + textBox1.Text + "@totalsoft.ro&parola=" + Hash(textBox2.Text));
                response.EnsureSuccessStatusCode();
                string responsivebody = await response.Content.ReadAsStringAsync();

                Angajat angajat = JsonConvert.DeserializeObject<Angajat>(responsivebody);

                if (angajat != null)
                {
                    PaginaPrincipala.PaginaPrincipala ppg = new PaginaPrincipala.PaginaPrincipala(angajat);
                    ppg.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Parola/Username incorect");
                }
               


            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            extragereAngajatByUsername();
            
            
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
