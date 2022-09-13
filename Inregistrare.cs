using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;
using ProiectASP.Models;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ConcediuAngajati
{
    public partial class Inregistrare : Form
    {
        public Inregistrare()
        {
            InitializeComponent();
            this.panel2.BackColor = Color.FromArgb(64, 127, 124, 127);
            //this.FieldNume.BackColor = Color.FromArgb(64, 128, 0, 0);

        }
        public static string Hash(string Value)
        {
            using var hash = SHA256.Create();
            var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(Value));
            return Convert.ToHexString(byteArray);
        }
        private void FieldNume_TextChanged(object sender,EventArgs e)
        {

        }
        private void FieldPrenume_TextChanged(object sender, EventArgs e)
        {

        }
        public void button2_Click(object sender, EventArgs e)
        {
            string strRegex = "^[1256]\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])(0[1-9]|[1-4]\\d|5[0-2]|99)(00[1-9]|0[1-9]\\d|[1-9]\\d\\d)\\d$";
            string nrtlfRegex = "^(\\+4|)?(07[0-8]{1}[0-9]{1}|02[0-9]{2}|03[0-9]{2}){1}?(\\s|\\.|\\-)?([0-9]{3}(\\s|\\.|\\-|)){2}$";
            Regex regexTlf = new Regex(nrtlfRegex);
            Regex regexCNP = new Regex(strRegex);
            if (FieldPass.Text == "")
            {
                MessageBox.Show("Parola este obligatorie!");
            }
            else if (FieldPass.TextLength < 8)
            {
                MessageBox.Show("Parola este prea scurta!");
            }
            else if (FieldEmail.Text == "")
            {
                MessageBox.Show("Emailul este obligatoriu!");
            }
            else if (FieldEmail.Text.IndexOf("@totalsoft.ro") == -1)
            {
                MessageBox.Show("Email invalid!");
            }

            else if (!regexTlf.IsMatch(FieldNrTel.Text))
            {
                MessageBox.Show("Numarul de telefon contine doar cifre!");
            }
        
            else if (FieldNrTel.Text == "")
            {
                
                MessageBox.Show("Numarul de telefon este obligatoriu");
            }
            else if (FieldNrTel.Text.Length != 10)
            {
                MessageBox.Show("Numarul de telefon trebuie sa aiba 10 cifre dar are doar "+FieldNrTel.Text.Length+" cifre!");
            }
            else if (FieldNume.Text == "")
            {
                MessageBox.Show("Numele este obligatoriu");
            }
            else if (FieldPrenume.Text == "")
            {
                MessageBox.Show("Prenumele este obligatoriu");
            }
            else if (FieldPass.Text == FieldConfirmPass.Text)
            {

                Angajat a = new Angajat() { Nume = FieldNume.Text, Prenume = FieldPrenume.Text, Email = FieldEmail.Text, Parola = Hash(FieldPass.Text), NrTelefon = FieldNrTel.Text ,DepartamentId=7,FunctieId=5};
                FormInregistrareIntermediar Fii = new FormInregistrareIntermediar(a);
                Fii.Show();
                this.Hide();
                //Email inregistrare 
               /*   MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("sebastian.andrei@totalsoft.ro");
                message.To.Add(new MailAddress("sebastian.andrei@totalsoft.ro"));
                message.Subject = "Email inregistrare StrangerThings Hr";
                message.Body = "Bun venit la strangerThingsHr";
                smtp.Port = 587;
                smtp.Host = "mailer14.totalsoft.local";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("sebastian.andrei@totalsoft.ro", "STats123rm");
                smtp.Send(message);*/
            }
            else
                MessageBox.Show("Parolele sunt diferite");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPhase lp = new LoginPhase();
            lp.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e )
        {
            this.Close();
            Environment.Exit(1);
            
        }

        private void FieldNume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FieldPrenume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FieldNrTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
