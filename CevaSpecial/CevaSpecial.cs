using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcediuAngajati.CevaSpecial
{
    public partial class CevaSpecial : Form
    {
        public CevaSpecial()
        {
            InitializeComponent();
        }
        Button dynamicButton = new Button();
       
        private void Create_Click(object sender, EventArgs e)
        {
            this.Controls.Add(dynamicButton);
        } 
        private void CevaSpecial_Load(object sender, EventArgs e)
        {
            dynamicButton.Location = new Point(200, 150);
            dynamicButton.Height = 23;
            dynamicButton.Width = 75;
        }
    }
}
