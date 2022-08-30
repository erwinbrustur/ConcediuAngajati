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
                MessageBox.Show("parola este obligatorie");
            }
            else if(FieldEmail.Text == "")
                        {
                MessageBox.Show("parola este obligatorie");
            }
                        else if(FieldNrTel.Text == "")
                            {
                MessageBox.Show("parola este obligatorie");
            }    
                            else if( FieldNume.Text == "") 
                                 {
                MessageBox.Show("parola este obligatorie");
            }
                                 else if(FieldPrenume.Text == "") 
                                     {
                MessageBox.Show("parola este obligatorie");
            }
                                else if (FieldPass.Text == FieldConfirmPass.Text)
               {
                    Angajat a = new Angajat(FieldNume.Text, FieldPrenume.Text, FieldEmail.Text, Hash(FieldPass.Text), FieldNrTel.Text);
                MessageBox.Show(a.Nume + " " + a.Prenume + " " + a.Email + " " + a.Parola + " " + a.NrTelefon);
                    FormInregistrareIntermediar Fii = new FormInregistrareIntermediar(a);
                    Fii.Show();
                    this.Hide();
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
