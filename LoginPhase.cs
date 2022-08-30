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
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LoginPhase
            // 
            this.ClientSize = new System.Drawing.Size(612, 310);
            this.Name = "LoginPhase";
            this.ResumeLayout(false);

        }
        /* String userId, userPass;
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

private void InitializeComponent()
{
    this.SuspendLayout();
    // 
    // LoginPhase
    // 
    this.ClientSize = new System.Drawing.Size(280, 261);
    this.Name = "LoginPhase";
    this.ResumeLayout(false);

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
*/
    }
       
}
