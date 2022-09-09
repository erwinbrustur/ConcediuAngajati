using ConcediuAngajati.PaginaPrincipala;
using ConcediuAngajati.Utils;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using ProiectASP.Models;
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
        static readonly HttpClient client = new HttpClient();
        
        string connectionString;
        List<string> listaInlocuitori;
        int idInlocuitor;
        Angajat userCurent;
        TipConcediu tpc;
        
        public CerereConcediu(Angajat a)
        {
            
            InitializeComponent();
            userCurent = a;

           
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";

            extragereTipConcediuDB();


            // cbTipConcediu.SelectedIndex = 0;

            //listaInlocuitori = extragereInlocuitoriEchipaDB();
            //foreach(string inlocuitor in listaInlocuitori)
            //{
            //    string[] str = inlocuitor.Split(',');
            //    cbInlocuitor.Items.Add(str[1]);

            //}

            //cbInlocuitor.SelectedIndex = 0;

            extragereInlocuitorAsyncDB();

          

        }

        //public List<string> extragereTipConcediiDB()
        //{
        //    List<string> strings = new List<string>();
        //    string selectSQL = "SELECT * from TipConcediu";
        //    SqlConnection conexiune = new SqlConnection(connectionString);
        //    SqlCommand querySelect = new SqlCommand(selectSQL);
        //    try
        //    {
        //        conexiune.Open();
        //        querySelect.Connection = conexiune;
        //        SqlDataReader reader = querySelect.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            strings.Add(reader[1].ToString());

        //        }


        //        return strings;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return null;
        //    }
        //    finally
        //    {
        //        conexiune.Close();


        //    }

        //}
        public async void extragereTipConcediuDB()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(String.Format("{0}TipConcediu/GetAllTipConcediu", Globals.apiUrl));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                List<TipConcediu> listaTipConcedii = JsonConvert.DeserializeObject<List<TipConcediu>>(responseBody);

                //MessageBox.Show(listaTipConcedii.Count.ToString());
                cbTipConcediu.DataSource = listaTipConcedii;
                cbTipConcediu.DisplayMember = "Nume";
                cbTipConcediu.ValueMember = "Id";
                
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public async void extragereInlocuitorAsyncDB()
        {
            try
            {
                HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}Angajat/GetAllInlocuitoriNumeConcatenat?angajatId={1}&managerId={2}", Globals.apiUrl,userCurent.Id, userCurent.ManagerId ));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                List<Angajat> listaInlocuitori = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);


                cbInlocuitor.DataSource = listaInlocuitori;
                cbInlocuitor.DisplayMember = "Nume";
                cbInlocuitor.ValueMember = "Id";
               // cbInlocuitor.SelectedIndex = userCurent.Id;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        //public List<string> extragereInlocuitoriEchipaDB()
        //{
        //    List<string> strings = new List<string>();
          
        //    string selectSQL = "SELECT * FROM Angajat WHERE managerId =  " + userCurent.ManagerId + "and id <> " + userCurent.Id;
           
        //    SqlConnection conexiune = new SqlConnection(connectionString);
        //    SqlCommand querySelect = new SqlCommand(selectSQL);
        //    try
        //    {
        //        conexiune.Open();
        //        querySelect.Connection = conexiune;
        //        SqlDataReader reader = querySelect.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            strings.Add(reader[0].ToString() + ", " + reader[1].ToString() + " "  + reader[2].ToString());

        //        }


        //        return strings;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return null;
        //    }
        //    finally
        //    {
        //        conexiune.Close();


        //    }

        //}


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
                firstDayOfWeek = firstDayOfWeek == 0 ? 7 : firstDayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {

                    if (lastDayOfWeek >= 7)
                        zileConcediu -= 2; // Altfel scadem doar sambata si duminica
                    else if (lastDayOfWeek >= 6)
                        zileConcediu -= 1;
               
                }
               else if (firstDayOfWeek <= 7 &&  lastDayOfWeek >= 7 ) // Scadem doar duminica
                    zileConcediu -= 1;
            }
            zileConcediu -= fullWeekCount + fullWeekCount;
            
            foreach(DateTime bankHoliday in holidays)
            {
                DateTime bh = bankHoliday.Date;
                var bhString = bh;
                if (firstDay <= bh && bh <= lastDay && (bhString.DayOfWeek != DayOfWeek.Sunday && bhString.DayOfWeek != DayOfWeek.Saturday))
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
                PaginaPrincipala.PaginaPrincipala pagprin = new PaginaPrincipala.PaginaPrincipala(userCurent);
                pagprin.ShowDialog();
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

        //private void Trimite_Click(object sender, EventArgs e)
        //{
        //    string message = "Sigur vrei sa trimiti cererea de concediu?";
        //    string title = "Cerere concediu";
        //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        //    DialogResult result = MessageBox.Show(message, title, buttons);
        //    if (result == DialogResult.Yes)
        //    {
       
        //        string message2 = "Cerere de concediu trimisa";


        //        DateTime dataInceput = Convert.ToDateTime(dateTimePicker1.Value);
        //        DateTime dataSfarsit = Convert.ToDateTime(dateTimePicker3.Value);

        //        SqlConnection conexiune = new SqlConnection(connectionString);
            
        //        string insertSQL = "INSERT INTO Concediu(tipConcediuId, dataInceput, dataSfarsit, inlocuitorId, comentarii, stareConcediuId, angajatId, ZileConcediu) VALUES('" + (cbTipConcediu.SelectedIndex + 1) + "', '" + dataInceput + "', '" + dataSfarsit + "', '" + idInlocuitor + "', '" + rtbComentarii.Text + "', '1', " + userCurent.Id + ", " + Convert.ToInt32(textBox1.Text) + ")";  

        //        SqlCommand queryInsert = new SqlCommand(insertSQL);
        //        try
        //        {
        //            conexiune.Open();
        //            queryInsert.Connection = conexiune;
                    
        //            queryInsert.ExecuteNonQuery();
               

        //            DialogResult result2 = MessageBox.Show(message2, title);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //        finally
        //        {
        //            conexiune.Close();
        //        }
              

        //    }
         
        //}

        public async void Trimitere(object sender, EventArgs e)
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
                string message3 = "Ai deja o cerere de concediu in asteptare/acceptata in acea perioada";
                string message4 = "Inlocuitor ocupat in aceasta perioada";

                Concediu con = new Concediu();
                con.TipConcediuId = (int)cbTipConcediu.SelectedValue;
                con.DataInceput = dataInceput;
                con.DataSfarsit = dataSfarsit;
                con.InlocuitorId = (int)cbInlocuitor.SelectedValue;
                con.Comentarii = rtbComentarii.Text;
                con.StareConcediuId = 1;
                con.AngajatId = userCurent.Id;
                con.ZileConcediu = Convert.ToInt32(textBox1.Text);

                HttpResponseMessage responseDate = await client.GetAsync(String.Format("{0}Concediu/GetAllIstoricConcediiVerificareDate?angajatId={1}", Globals.apiUrl, userCurent.Id));
                responseDate.EnsureSuccessStatusCode();
                string responsivebody = await responseDate.Content.ReadAsStringAsync();

                List<Concediu> concedii = JsonConvert.DeserializeObject<List<Concediu>>(responsivebody);
                bool mergeInserat = true;
                bool esteInTrecut = false;
                if (DateTime.Now.Date > con.DataInceput.Date)
                {
                    MessageBox.Show("Nu poti sa iti iei concediu in trecut");
                    esteInTrecut = true;
                }

                foreach (Concediu concediu in concedii)
                {

                    if (concediu.DataInceput <= con.DataInceput && concediu.DataSfarsit >= con.DataInceput)
                    { //Data inceput in interval sfarsit in afara
                        mergeInserat = false;
                        break;
                    }
                    else if (concediu.DataInceput >= con.DataInceput && concediu.DataSfarsit <= con.DataSfarsit)//In afara interval
                    {
                        mergeInserat = false;
                        break;
                    }
                    else if (concediu.DataInceput > con.DataInceput && concediu.DataSfarsit >= con.DataSfarsit)//Data sfarsit in interval si inceput in afara intervalului
                    {
                        mergeInserat = false;
                        break;
                    }
                    else if (concediu.DataInceput <= con.DataInceput && concediu.DataSfarsit >= con.DataSfarsit) // Ambele date in interval
                    {
                        mergeInserat = false;
                        break;
                    }
                }

                bool InlocuitorNeocupat = true;
                HttpResponseMessage responseDate2 = await client.GetAsync(String.Format("{0}Concediu/GetConcediiInlocuitori?angajatId={1}", Globals.apiUrl, userCurent.Id));
                responseDate.EnsureSuccessStatusCode();
                string responsivebody2 = await responseDate2.Content.ReadAsStringAsync();

                List<Concediu> concediiInlocuitori = JsonConvert.DeserializeObject<List<Concediu>>(responsivebody2);
                foreach (Concediu coninloc in concediiInlocuitori)
                {
                    if (cbInlocuitor.SelectedValue.Equals(coninloc.Angajat.Id))
                    {
                        if (coninloc.DataInceput <= con.DataInceput && coninloc.DataSfarsit >= con.DataInceput)
                        { //Data inceput in interval
                            InlocuitorNeocupat = false;
                            break;
                        }
                        else if (coninloc.DataInceput >= con.DataInceput && coninloc.DataSfarsit <= con.DataSfarsit)//In afara interval
                        {
                            InlocuitorNeocupat = false;
                            break;
                        }
                        else if (coninloc.DataInceput > con.DataInceput && coninloc.DataSfarsit >= con.DataSfarsit)//Data sfarsit in interval
                        {
                            InlocuitorNeocupat = false;
                            break;
                        }
                        else if (coninloc.DataInceput <= con.DataInceput && coninloc.DataSfarsit >= con.DataSfarsit) // Ambele date in interval
                        {
                            InlocuitorNeocupat = false;
                            break;
                        }
                    }
                }


                if (mergeInserat == true && InlocuitorNeocupat == true)
                { 
                    string jsonString = JsonConvert.SerializeObject(con);
                    StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    string linkF = String.Format("{0}Concediu/InserareConcediu", Globals.apiUrl);
                    var response = Globals.client.PutAsync(linkF, stringContent).Result;
                    DialogResult result2 = MessageBox.Show(message2, title);
                }
                else if(mergeInserat == false && InlocuitorNeocupat == true)
                {
                    if (esteInTrecut == false)
                    {
                        DialogResult result2 = MessageBox.Show(message3, title);
                    }
                }
                else if (mergeInserat == true && InlocuitorNeocupat == false)
                {
                    if (esteInTrecut == false)
                    {
                        DialogResult result2 = MessageBox.Show(message4, title);
                    }
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

        //private void cbInlocuitor_SelectedIndexChanged(object sender, EventArgs e)
        //{
             
            
        //    foreach(string str in listaInlocuitori)
        //    {
        //         string[] s = str.Split(',');
        //        if (s[1].CompareTo(cbInlocuitor.Text) == 0)
        //        {
        //            idInlocuitor = Convert.ToInt32(s[0]);
                   
        //        }
        //    }
        //}

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

        private void CerereConcediu_Load(object sender, EventArgs e)
        {

        }

        private void btnInchidereCC_Click(object sender, EventArgs e)
        {
            PaginaPrincipala.PaginaPrincipala paginap = new PaginaPrincipala.PaginaPrincipala(userCurent);
            paginap.Show();
            this.Close();
        }

        private void textBoxZileRamase_TextChanged(object sender, EventArgs e)
        {
            
        }

        
        private async void cbTipConcediu_SelectedValueChanged(object sender, EventArgs e)
        {
          
           
        }

        private async void cbTipConcediu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int tipConcediuId = Convert.ToInt32(cbTipConcediu.SelectedValue);
            HttpResponseMessage responseDate = await client.GetAsync(String.Format("{0}Concediu/GetNumarZileConcediuRamase?tipConcediuId={1}&angajatId={2}", Globals.apiUrl, tipConcediuId, userCurent.Id));
            responseDate.EnsureSuccessStatusCode();
            string responsivebody = await responseDate.Content.ReadAsStringAsync();


            textBoxZileRamase.Text = responsivebody;
        }
    }
}

