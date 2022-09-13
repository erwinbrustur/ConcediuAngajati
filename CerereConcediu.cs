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
        
        List<string> listaInlocuitori;
        int idInlocuitor;
        Angajat userCurent;
        TipConcediu tpc;
        
        public CerereConcediu(Angajat a)
        {
            
            InitializeComponent();
            userCurent = a;

            extragereTipConcediuDB();
            extragereInlocuitorAsyncDB();  

        }

        public async void extragereTipConcediuDB()
        {
            try
            {
                HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}TipConcediu/GetAllTipConcediu", Globals.apiUrl));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                List<TipConcediu> listaTipConcedii = JsonConvert.DeserializeObject<List<TipConcediu>>(responseBody);

                cbTipConcediu.DataSource = listaTipConcedii;
                cbTipConcediu.DisplayMember = "Nume";
                cbTipConcediu.ValueMember = "Id";

                cbTipConcediu.SelectedItem = null;
                
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

                cbInlocuitor.SelectedItem = null;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);

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
            
         
                this.Close();
                PaginaPrincipala.PaginaPrincipala pagprin = new PaginaPrincipala.PaginaPrincipala(userCurent);
                pagprin.ShowDialog();
           
         
        }

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
                string message5 = "Nu ai suficiente zile pentru a-ti lua concediu";
                string message6 = "Zile de concediu negative";
                string message7 = "Concediu in trecut";

                Concediu con = new Concediu();
                con.TipConcediuId = (int)cbTipConcediu.SelectedValue;
                con.DataInceput = dataInceput;
                con.DataSfarsit = dataSfarsit;
                con.InlocuitorId = (int)cbInlocuitor.SelectedValue;
                con.Comentarii = rtbComentarii.Text;
                con.StareConcediuId = 1;
                con.AngajatId = userCurent.Id;
                con.ZileConcediu = Convert.ToInt32(textBox1.Text);

                HttpResponseMessage responseDate = await Globals.client.GetAsync(String.Format("{0}Concediu/GetAllIstoricConcediiVerificareDate?angajatId={1}", Globals.apiUrl, userCurent.Id));
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

                    if (concediu.DataInceput.Date <= con.DataInceput.Date && concediu.DataSfarsit.Date >= con.DataInceput.Date)
                    { //Data inceput in interval sfarsit in afara
                        mergeInserat = false;
                        break;
                    }
                    else if (concediu.DataInceput.Date >= con.DataInceput.Date && concediu.DataSfarsit.Date <= con.DataSfarsit.Date)//In afara interval
                    {
                        mergeInserat = false;
                        break;
                    }
                    else if (concediu.DataSfarsit.Date >= con.DataSfarsit && concediu.DataInceput.Date <= con.DataSfarsit.Date)//Data sfarsit in interval si inceput in afara intervalului
                    {
                        mergeInserat = false;
                        break;
                    }
                 
                }

                bool InlocuitorNeocupat = true;
                HttpResponseMessage responseDate2 = await Globals.client.GetAsync(String.Format("{0}Concediu/GetConcediiInlocuitori?angajatId={1}", Globals.apiUrl, userCurent.Id));
                responseDate.EnsureSuccessStatusCode();
                string responsivebody2 = await responseDate2.Content.ReadAsStringAsync();

                List<Concediu> concediiInlocuitori = JsonConvert.DeserializeObject<List<Concediu>>(responsivebody2);
                foreach (Concediu coninloc in concediiInlocuitori)
                {
                    if (cbInlocuitor.SelectedValue.Equals(coninloc.Angajat.Id))
                    {
                        if (coninloc.DataInceput.Date <= con.DataInceput.Date && coninloc.DataSfarsit.Date >= con.DataInceput.Date)
                        { //Data inceput in interval sfarsit in afara
                            InlocuitorNeocupat = false;
                            break;
                        }
                        else if (coninloc.DataInceput.Date >= con.DataInceput.Date && coninloc.DataSfarsit.Date <= con.DataSfarsit.Date)//In afara interval
                        {
                            InlocuitorNeocupat = false;
                            break;
                        }
                        else if (coninloc.DataSfarsit.Date >= con.DataSfarsit && coninloc.DataInceput.Date <= con.DataSfarsit.Date)//Data sfarsit in interval si inceput in afara intervalului
                        {
                            InlocuitorNeocupat = false;
                            break;
                        }

                    }
                }

                bool zileNegative = false;
                bool zileRamase = true;   
                if (Convert.ToInt32(textBoxZileRamase.Text) < Convert.ToInt32(textBox1.Text))
                    zileRamase = false;
                if (Convert.ToInt32(textBox1.Text) == 0)
                    zileNegative = true;

                if (mergeInserat == true && InlocuitorNeocupat == true && zileRamase == true && esteInTrecut == false && zileNegative == false)
                { 
                    string jsonString = JsonConvert.SerializeObject(con);
                    StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    string linkF = String.Format("{0}Concediu/InserareConcediu", Globals.apiUrl);
                    var response = Globals.client.PutAsync(linkF, stringContent).Result;
                    DialogResult result2 = MessageBox.Show(message2, title);
                }
                else if(mergeInserat == false)
                {
                    
                    DialogResult result2 = MessageBox.Show(message3, title);
                    
                }
                else if (InlocuitorNeocupat == false)
                {
                    DialogResult result3 = MessageBox.Show(message4, title);
                }

                else if (zileRamase == false)
                {
                 
                    DialogResult result4 = MessageBox.Show(message5, title);
                }
                else if(zileNegative == true)
                {
                    DialogResult result5 = MessageBox.Show(message6, title);
                }
                else if (esteInTrecut == true)
                {
                    DialogResult result6 = MessageBox.Show(message7, title);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {    
            cbTipConcediu.DropDownStyle = ComboBoxStyle.DropDown;
            //MessageBox.Show("cbTipConcediu selected index changed");
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

        private void btnInchidereCC_Click(object sender, EventArgs e)
        {
            PaginaPrincipala.PaginaPrincipala paginap = new PaginaPrincipala.PaginaPrincipala(userCurent);
            paginap.Show();
            this.Close();
        }


        private async void cbTipConcediu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //MessageBox.Show("cbTipConcediu");
            int tipConcediuId = Convert.ToInt32(cbTipConcediu.SelectedValue);
            HttpResponseMessage responseDate = await Globals.client.GetAsync(String.Format("{0}Concediu/GetNumarZileConcediuRamase?tipConcediuId={1}&angajatId={2}", Globals.apiUrl, tipConcediuId, userCurent.Id));
            responseDate.EnsureSuccessStatusCode();
            string responsivebody = await responseDate.Content.ReadAsStringAsync();

            //MessageBox.Show(responsivebody);
            textBoxZileRamase.Text = responsivebody;     

        }
    }
}

