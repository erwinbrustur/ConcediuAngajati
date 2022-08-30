using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcediuAngajati
{
    public partial class LoginPhase : Form
    {
        String userId, userPass;
        public LoginPhase()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Logare_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                File.WriteAllText("credentials.txt", userId.ToString());
            }
            PaginaMea rg = new PaginaMea();
            rg.Show();
            this.Visible = false;
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void Inregistrare_Click(object sender, EventArgs e)
        {
            ConcediuAngajati.Inregistrare inreg = new Inregistrare();
            inreg.Show();
            this.Hide();
        }

        private void LoginPhase_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string possibleUserId = File.ReadAllText("credentials.txt");
            }
            userId = Username.Text;
            userPass = Parola.Text;
        }
    }
}
