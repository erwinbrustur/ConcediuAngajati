using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace ConcediuAngajati
{
    public partial class CerereConcediu : Form
    {
        

        public CerereConcediu()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime inTime = Convert.ToDateTime(dateTimePicker1.Value) ;
            DateTime outTime = Convert.ToDateTime(dateTimePicker2.Value);
            if (outTime >= inTime)
            {
                textBox1.Text = outTime.Subtract(inTime).Days.ToString();
            }
        }


      

        private void PaginaMea_Click_1(object sender, EventArgs e)
        {
            
            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                // Do something  
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PaginaMea_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Trimite_Click(object sender, EventArgs e)
        {
            string message = "Sigur vrei sa trimiti cererea de concediu?";
            string title = "Cerere concediu";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
       
                string message2 = "Cerere de concediu trimisa";
                DialogResult result2 = MessageBox.Show(message2, title);
               
            }
         
        }

      
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {    
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime inTime = Convert.ToDateTime(dateTimePicker1.Value);
            DateTime outTime = Convert.ToDateTime(dateTimePicker2.Value);
            if (outTime >= inTime)
            {
                textBox1.Text = outTime.Subtract(inTime).Days.ToString();
            }
        }

        
    }
}
