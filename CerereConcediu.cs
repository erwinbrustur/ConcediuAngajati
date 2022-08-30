using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        List<string> list;
        string connectionString;
        public CerereConcediu()
        {
            InitializeComponent();
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";
            list = extragereTipConcediiDB();
            foreach(string s in list)
            {
                cbTipConcediu.Items.Add(s);
            }
            //cbTipConcediu.SelectedItem = cbTipConcediu.Items.IndexOf(0);
            cbTipConcediu.SelectedIndex = 0;

        }

        public List<string> extragereTipConcediiDB()
        {
            List<string> strings = new List<string>();
            string selectSQL = "SELECT * from TipConcediu";
            SqlConnection conexiune = new SqlConnection(connectionString);
            SqlCommand querySelect = new SqlCommand(selectSQL);
            try
            {
                conexiune.Open();
                querySelect.Connection = conexiune;
                SqlDataReader reader = querySelect.ExecuteReader();

                while (reader.Read())
                {
                    strings.Add(reader[1].ToString());
                   
                }


                return strings;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conexiune.Close();
                
                
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime inTime = Convert.ToDateTime(dateTimePicker1.Value) ;
            DateTime outTime = Convert.ToDateTime(dateTimePicker2.Value);
            
           
            if (outTime >= inTime)
            {
                textBox1.Text = (outTime.Date - inTime.Date).Days.ToString();
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
                
           
                DateTime dataInceput = Convert.ToDateTime(dateTimePicker1.Value);
                DateTime dataSfarsit = Convert.ToDateTime(dateTimePicker2.Value);

                SqlConnection conexiune = new SqlConnection(connectionString);
                MessageBox.Show((cbTipConcediu.SelectedIndex + 1).ToString());
                string insertSQL = "INSERT INTO Concediu(tipConcediuId, dataInceput, dataSfarsit) VALUES('" + (cbTipConcediu.SelectedIndex + 1) + "', '" + dataInceput + "', '" + dataSfarsit + "')";

                SqlCommand queryInsert = new SqlCommand(insertSQL);
                try
                {
                    conexiune.Open();
                    queryInsert.Connection = conexiune;
                    
                    queryInsert.ExecuteNonQuery();
                    MessageBox.Show("da");

                    DialogResult result2 = MessageBox.Show(message2, title);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexiune.Close();
                }
              

            }
         
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {    
            cbTipConcediu.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime inTime = Convert.ToDateTime(dateTimePicker1.Value);
            DateTime outTime = Convert.ToDateTime(dateTimePicker2.Value);
            if (outTime >= inTime)
            {
                textBox1.Text = (outTime.Date - inTime.Date).Days.ToString();
            }
        }

        
    }
}
