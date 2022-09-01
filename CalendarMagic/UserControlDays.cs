using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcediuAngajati.CalendarMagic
{
    public partial class UserControlDays : UserControl
    {
        //public event EventHandler LabelsTextChanged;
        public UserControlDays()
        {
            InitializeComponent();
        }
       /* private void HandleLabelTextChanged(object sender, EventArgs e)
        {
                // we'll explain this in a minute
                this.OnLabelsTextChanged(EventArgs.Empty);
        }
        protected virtual void OnLabelsTextChanged(EventArgs e)
        {
            EventHandler handler = this.LabelsTextChanged;

            if (handler != null)
            {
                handler('a', e);
            }
        }*/

       /* private void UserControlDays_Load(object sender, EventArgs e)
        {
            NumePers.Text += this.HandleLabelTextChanged;
        }*/
        public void days(int numday)
        {
            zi.Text = numday + "";
        }

        private void NumePers_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
