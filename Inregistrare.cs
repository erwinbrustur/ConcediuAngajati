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


namespace ConcediuAngajati
{
    public partial class Inregistrare : Form
    {
        public Inregistrare()
        {
            InitializeComponent();
            
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

            if (FieldPass.Text == "")
            {
                MessageBox.Show("Parola este obligatorie!");
            }
            else if (FieldPass.TextLength < 8)
            {
                MessageBox.Show("Parola este prea scurta");
            }
            else if (FieldEmail.Text == "")
            {
                MessageBox.Show("Mailul este obligatoriu!");
            }
            else if (FieldEmail.Text.IndexOf("@totalsoft.ro")==-1 )
            {
                MessageBox.Show("Format mail incorect");
            }
            else if (FieldNrTel.Text == "")
            {
                MessageBox.Show("Numarul de telefon este obligatoriu");
            }
            else if (FieldNrTel.TextLength != 10)
            {
                MessageBox.Show("Numarul de telefon trebuie sa aiba 10 cifre");
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
                Angajat a = new Angajat(FieldNume.Text, FieldPrenume.Text, FieldEmail.Text, Hash(FieldPass.Text), FieldNrTel.Text);
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

      
    }
}
