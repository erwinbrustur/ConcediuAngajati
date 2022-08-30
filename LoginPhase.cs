using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ConcediuAngajati
{
    public partial class LoginPhase : Form
    {
        public LoginPhase()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Logare_Click(object sender, EventArgs e)
        {
            PaginaMea rg = new PaginaMea();
            rg.Show();
            this.Visible = false;
        }

        private void LoginPhase_Load(object sender, EventArgs e)
        {

        }
    }
}
