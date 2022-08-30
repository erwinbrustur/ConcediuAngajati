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
            if (FieldPass.Text != null
                    && FieldEmail != null
                    && FieldNrTel != null
                    && FieldNume != null
                    && FieldPrenume != null)
            {
                if (FieldPass.Text == FieldConfirmPass.Text)
                {

                }
                else
                    MessageBox.Show("Parolele sunt diferite");
            }
            else
                MessageBox.Show("Toate campurile sunt obligatorii");
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPhase lp = new LoginPhase();
            lp.Show();
            this.Hide();
        }

      
    }
}
