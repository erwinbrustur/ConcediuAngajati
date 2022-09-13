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
using ConcediuAngajati.Utils;
using System.Net.Mail;
using System.Net;

namespace ConcediuAngajati
{
    public partial class LoginPhase : Form
    {


        Angajat angajat;
        int GeneratedCode;
        string AuthCode;
        static readonly HttpClient client = new HttpClient();
        public LoginPhase()
        {
            InitializeComponent();
           panel2FA.Hide();
       
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Inregistrare ing = new Inregistrare();
       
            this.Hide();
            ing.Show();
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

                HttpResponseMessage response = await client.GetAsync(String.Format("{0}Angajat/GetAngajatByUsername?username={1}@totalsoft.ro&parola={2}", Globals.apiUrl, textBox1.Text, Hash(textBox2.Text)));
                response.EnsureSuccessStatusCode();
                string responsivebody = await response.Content.ReadAsStringAsync();
                angajat = JsonConvert.DeserializeObject<Angajat>(responsivebody);

                if (angajat != null && angajat.concediat == false)
                {
                    //Comenteaza urmatoarele 3 randuri cand activezi 2Fa
                   // PaginaPrincipala.PaginaPrincipala ppg = new PaginaPrincipala.PaginaPrincipala(angajat);
                  //  ppg.Show();
                   // this.Hide();

                     MailMessage message = new MailMessage();
                     SmtpClient smtp = new SmtpClient();
                     message.From = new MailAddress("sebastian.andrei@totalsoft.ro");
                     message.To.Add(new MailAddress("sebastian.andrei@totalsoft.ro"));
                     message.Subject = "Cod de Autentificare StrangerThings Hr";
                     message.Body = String.Format("Codul dumneavoastra de acces este: {0} ",AuthCode);
                     smtp.Port = 587;
                     smtp.Host = "mailer14.totalsoft.local";
                     smtp.EnableSsl = true;
                     smtp.UseDefaultCredentials = false;
                     smtp.Credentials = new NetworkCredential("sebastian.andrei@totalsoft.ro", "STats123rm");
                     smtp.Send(message);
                     panel2FA.Show();
                    button1.Hide();
                    button2.Hide();
                    textBox1.Hide();
                    textBox2.Hide();
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

            GeneratedCode = 0;
            int CodeLength = 4;

            string[] digit = new string[CodeLength];

            for (int i = 0; i < CodeLength; i++)
            {
                Random rnd = new Random();
                GeneratedCode = rnd.Next(10);
                digit[i] = GeneratedCode.ToString();
            }
            for (int i = 0; i < CodeLength; i++)
            {
                AuthCode = AuthCode + digit[i];
            }
        }

        private void btnInchidereLP_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                extragereAngajatByUsername();
            }
        }

        private void Btn2FA_Click(object sender, EventArgs e)
        {
            if (Cod2FA.Text == AuthCode)
            {
               PaginaPrincipala.PaginaPrincipala ppg = new PaginaPrincipala.PaginaPrincipala(angajat);
                ppg.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Eroare: Cod Gresit!");
            }
            }

        private void LoginPhase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                extragereAngajatByUsername();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                extragereAngajatByUsername();
            }
        }
    }
}
