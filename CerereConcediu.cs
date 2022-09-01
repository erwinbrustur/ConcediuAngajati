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
        List<string> listaInlocuitori;
        int idInlocuitor;
        Angajat userCurent;
        
        public CerereConcediu(Angajat a)
        {
            
            InitializeComponent();
            userCurent = a;

            MessageBox.Show("User: " + userCurent.Nume + userCurent.Prenume + userCurent.Email + userCurent.ManagerId);
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";
            list = extragereTipConcediiDB();
            foreach (string s in list)
            {
                cbTipConcediu.Items.Add(s);
            }
            
            cbTipConcediu.SelectedIndex = 0;
            
            listaInlocuitori = extragereInlocuitoriEchipaDB();
            foreach(string inlocuitor in listaInlocuitori)
            {
                string[] str = inlocuitor.Split(',');
                cbInlocuitor.Items.Add(str[1]);

            }

            cbInlocuitor.SelectedIndex = 0;
           

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

        public List<string> extragereInlocuitoriEchipaDB()
        {
            List<string> strings = new List<string>();
            string selectSQL = "SELECT * FROM Angajat WHERE managerId =  " + userCurent.ManagerId + "and id <> " + userCurent.Id;
            MessageBox.Show(userCurent.ManagerId + "Vacanta");
            SqlConnection conexiune = new SqlConnection(connectionString);
            SqlCommand querySelect = new SqlCommand(selectSQL);
            try
            {
                conexiune.Open();
                querySelect.Connection = conexiune;
                SqlDataReader reader = querySelect.ExecuteReader();

                while (reader.Read())
                {
                    strings.Add(reader[0].ToString() + ", " + reader[1].ToString() + " "  + reader[2].ToString());

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
            DateTime outTime = Convert.ToDateTime(dateTimePicker3.Value);

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
            int zileConcediu = span.Days + 1;
            int fullWeekCount = zileConcediu / 7;
            if (zileConcediu > fullWeekCount * 7)
            {
                int firstDayOfWeek = (int)firstDay.DayOfWeek;
                int lastDayOfWeek = (int)lastDay.DayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {

                    if (lastDayOfWeek >= 7)
                        zileConcediu -= 2; // Altfel scadem doar sambata si duminica
                    else if (lastDayOfWeek >= 6)
                        zileConcediu -= 1; // Trebuie sa scadem sambata
                    else if (lastDayOfWeek <= 5) // Trebuie sa scadem doar duminica
                        zileConcediu -= 1;
                }
               else if (firstDayOfWeek <= 7 &&  lastDayOfWeek >= 7 ) // Scadem doar duminica
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
                DateTime dataSfarsit = Convert.ToDateTime(dateTimePicker3.Value);

                SqlConnection conexiune = new SqlConnection(connectionString);
                MessageBox.Show((cbTipConcediu.SelectedIndex + 1).ToString());
                string insertSQL = "INSERT INTO Concediu(tipConcediuId, dataInceput, dataSfarsit, inlocuitorId, comentarii, stareConcediuId, angajatId) VALUES('" + (cbTipConcediu.SelectedIndex + 1) + "', '" + dataInceput + "', '" + dataSfarsit + "', '" + idInlocuitor + "', '" + rtbComentarii.Text + "', '1', " + userCurent.Id + ")";  

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

    

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbInlocuitor_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            
            foreach(string str in listaInlocuitori)
            {
                 string[] s = str.Split(',');
                if (s[1].CompareTo(cbInlocuitor.Text) == 0)
                {
                    idInlocuitor = Convert.ToInt32(s[0]);
                   
                }
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            DateTime inTime = Convert.ToDateTime(dateTimePicker1.Value);
            DateTime outTime = Convert.ToDateTime(dateTimePicker3.Value);
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

