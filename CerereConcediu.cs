using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            foreach (string s in list)
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
            DateTime inTime = Convert.ToDateTime(dateTimePicker1.Value);
            DateTime outTime = Convert.ToDateTime(dateTimePicker2.Value);

            if (inTime > outTime)
            {
                textBox1.Text = "0";
                MessageBox.Show("zile de concediu negative");

            }
            else
            {
                textBox1.Text = ZileConcediu(inTime, outTime).ToString();

            }



        }

        public static int ZileConcediu(DateTime firstDay, DateTime lastDay )
        {
            int year = 2022;
            List<DateTime> holidays = new List<DateTime>();
            holidays.Add(new DateTime(year, 1, 1));   // Anul nou
            holidays.Add(new DateTime(year, 1, 2));   // Anul nou
            holidays.Add(new DateTime(year, 1, 24));  // Unirea principatelor
            holidays.Add(new DateTime(year, 5, 1));   // Ziua muncii
            holidays.Add(new DateTime(year, 6, 1));   // Ziua copilului
            holidays.Add(new DateTime(year, 8, 15));  // Adormirea Maicii Domnului
            holidays.Add(new DateTime(year, 11, 30)); // Sfantul Andrei
            holidays.Add(new DateTime(year, 12, 1));  // Ziua Nationala a Romaniei
            holidays.Add(new DateTime(year, 12, 25)); // Prima zi de Craciun
            holidays.Add(new DateTime(year, 12, 26)); // A doua zi de Craciun

            
            firstDay = firstDay.Date;
            lastDay = lastDay.Date;
            TimeSpan span = lastDay - firstDay;
            int zileConcediu = span.Days;
            int fullWeekCount = zileConcediu / 7;
            if (zileConcediu > fullWeekCount * 7)
            {
                int firstDayOfWeek = (int)firstDay.DayOfWeek;
                int lastDayOfWeek = (int)lastDay.DayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 6)
                        zileConcediu -= 1; // Trebuie sa scadem sambata
                    else if (lastDayOfWeek >= 7)
                        zileConcediu -= 2; // Altfel scadem doar sambata si uminica
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7) // Scadem doar duminica
                    zileConcediu -= 1;
            }
            zileConcediu -= fullWeekCount + fullWeekCount;
            
            foreach(DateTime bankHoliday in holidays)
            {
                DateTime bh = bankHoliday.Date;
                if (firstDay <= bh && bh <= lastDay)
                    zileConcediu--;
            }
            return zileConcediu;
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
            if (inTime > outTime)
            {
                textBox1.Text = "0";
                MessageBox.Show("zile de concediu negative");
                
            }
            else
            {
                textBox1.Text = ZileConcediu(inTime, outTime).ToString();

            }

        }

        
    }
}
