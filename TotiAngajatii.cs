using ConcediuAngajati.Utils;
using MySql.Data.MySqlClient.Memcached;
using Newtonsoft.Json;
using ProiectASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConcediuAngajati
{
    public partial class TotiAngajatii : Form
    {
        static readonly HttpClient client = new HttpClient();
        string connectionString;
        List<string> listaStare;
        List<string> angajatistring;
        int idAngajatSelectat;
        int stareConcediuId;
        int idConcediu;
        Angajat angajat;
        int AngajatiAfisat = 17;
        int NumarInregistrari;

        public TotiAngajatii(Angajat a)
        {
            InitializeComponent();
            angajat = a;
            //ExtragereAngajatAsync(a);
            extragereIdDepartament();
            extragereIdManager();
        }
        private void obtinerePagini(int nrTotalPagini)
        {
            int x = 10;
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < nrTotalPagini; i++)
            {
                Button btn = new Button();
                btn.Text = (i + 1).ToString();
                btn.Location = new Point(x + 50);
                btn.Width = 30;
                btn.Height = 30;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Transparent;
                btn.Click += ButonClick;
                flowLayoutPanel1.Controls.Add(btn);
                x += 30;
            }
        }
        private void ButonClick(object sender, EventArgs e)
        {
            int paginaS = Convert.ToInt32(((Button)sender).Text);
            string? nume;
            if (!TBNume.Text.Equals(""))
            {
                nume = TBNume.Text;
            }
            else
            {
                nume = null;
            }

            string? prenume;
            if (!TBPrenume.Text.Equals(""))
            {
                prenume = TBPrenume.Text;
            }
            else
            {
                prenume = null;
            }

            int? IdManagerSelectat;
            if (CBManager.SelectedValue == null)
            {
                IdManagerSelectat = null;
            }
            else
            {
                IdManagerSelectat = Convert.ToInt32(CBManager.SelectedValue);
            }
            int? IdDepartamentSelectat;
            if (CBDepartament.SelectedValue == null)
            {
                IdDepartamentSelectat = null;
            }
            else
            {
                IdDepartamentSelectat = Convert.ToInt32(CBDepartament.SelectedValue);
            }
            AfisareAngajati(nume, prenume, IdDepartamentSelectat, IdManagerSelectat, (paginaS - 1) * AngajatiAfisat, AngajatiAfisat);

        }

        /* public async Task ExtragereAngajatAsync(Angajat ang)
         {
             HttpResponseMessage response = await client.GetAsync(String.Format("{0}Orice/TotiAngajatii", Globals.apiUrl));
             response.EnsureSuccessStatusCode();
             string responseBody = await response.Content.ReadAsStringAsync();



             List<Angajat> listaAngajati = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);
             try
             {

                 //MessageBox.Show(listaAngajati.Count().ToString());
                 foreach (Angajat a in listaAngajati)
                 {

                         ListViewItem item = new ListViewItem(a.Nume.ToString());//Nume

                         //MessageBox.Show(a.Nume);
                         item.SubItems.Add(a.Prenume.ToString());//Prenume
                         if (a.Email != null)
                         {
                             item.SubItems.Add(a.Email.ToString());//Email
                         }
                         else
                         {
                             item.SubItems.Add("Nu are adresa de email");
                         }
                         item.SubItems.Add((a.Manager.Nume + ' ' + a.Manager.Prenume).ToString());//Manager                                             
                         item.SubItems.Add(a.Departament.Denumire);//Departament




                         listView1.Items.Add(item);

                 }



             }*/
        /*   catch (Exception ex)
           {
               MessageBox.Show(ex.Message);

           }


       }*/

        private void extragereCountInregistrari(string? nume, string? prenume, int? IdDepartamentSelectat, int? IdManagerSelectat)
        {
            HttpResponseMessage response = Globals.client.GetAsync(String.Format("{0}Orice/NrTotalAngajati?nume={1}&prenume={2}&IdDepartamentSelectat={3}&IdManagerSelectat={4}", Globals.apiUrl, nume, prenume, IdDepartamentSelectat, IdManagerSelectat)).Result;

            string responseBody2 = response.Content.ReadAsStringAsync().Result;
            NumarInregistrari = JsonConvert.DeserializeObject<int>(responseBody2);

            int totalPagini = (int)Math.Ceiling(decimal.Parse(NumarInregistrari.ToString()) / decimal.Parse(AngajatiAfisat.ToString()));
            obtinerePagini(totalPagini);
        }


        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public async void extragereIdManager()
        {
            HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}Angajat/GetAllManagers", Globals.apiUrl));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<Angajat> ListaManageri = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);

            CBManager.DataSource = ListaManageri;
            CBManager.DisplayMember = "Nume";
            CBManager.ValueMember = "Id";
            CBManager.SelectedItem = null;
        }
        public  void extragereIdDepartament()
        {
            HttpResponseMessage response = Globals.client.GetAsync(String.Format("{0}DepartamentSiFunctie/GetAllDepartaments", Globals.apiUrl)).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            List<Departament> ListaDepartament = JsonConvert.DeserializeObject<List<Departament>>(responseBody);

            
      
            CBDepartament.DataSource = ListaDepartament;
            CBDepartament.DisplayMember = "Denumire";
            CBDepartament.ValueMember = "Id";
            CBDepartament.SelectedItem = null;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
           
            string? nume;
            if (!TBNume.Text.Equals(""))
            {
                nume = TBNume.Text;
            }
            else
            {
                nume = null;
            }

            string? prenume;
            if (!TBPrenume.Text.Equals(""))
            {
                prenume = TBPrenume.Text;
            }
            else
            {
                prenume = null;
            }

            int? IdManagerSelectat;
            if(CBManager.SelectedValue == null)
            {
                IdManagerSelectat = null;
            }
            else
            {
                IdManagerSelectat = Convert.ToInt32(CBManager.SelectedValue);
                IdManagerSelectat = Convert.ToInt32(CBManager.SelectedValue);
            }
            int? IdDepartamentSelectat;
            if (CBDepartament.SelectedValue == null)
            {
                IdDepartamentSelectat = null;
            }
            else
            {
                IdDepartamentSelectat = Convert.ToInt32(CBDepartament.SelectedValue);
            }
            extragereCountInregistrari(nume, prenume, IdDepartamentSelectat, IdManagerSelectat);
            AfisareAngajati(nume, prenume, IdDepartamentSelectat, IdManagerSelectat, 0, AngajatiAfisat);

        }

        public void AfisareAngajati(string? nume, string? prenume, int? IdDepartamentSelectat, int? IdManagerSelectat, int? NumarInregistrari, int? AngajatiAfisat)
        {
            HttpResponseMessage response = Globals.client.GetAsync(String.Format("{0}Orice/GetAngajatiFiltrat?nume={1}&prenume={2}&IdDepartamentSelectat={3}&IdManagerSelectat={4}&NrInregistrari={5}&NrTotalAdus={6}", Globals.apiUrl, nume, prenume, IdDepartamentSelectat, IdManagerSelectat, NumarInregistrari,AngajatiAfisat)).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            List<Angajat> listaAngajati = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);
            listView1.Items.Clear();
            //MessageBox.Show(listaAngajati.Count().ToString());
            foreach (Angajat a in listaAngajati)
            {
                ListViewItem item = new ListViewItem(a.Nume.ToString());//Nume

                //MessageBox.Show(a.Nume);
                item.SubItems.Add(a.Prenume.ToString());//Prenume
                if (a.Email != null)
                {
                    item.SubItems.Add(a.Email.ToString());//Email
                }
                else
                {
                    item.SubItems.Add("Nu are adresa de email");
                }
                item.SubItems.Add((a.Manager.Nume + ' ' + a.Manager.Prenume).ToString());//Manager                                             
                item.SubItems.Add(a.Departament.Denumire);//Departament




                listView1.Items.Add(item);
            }
        }

        private void TotiAngajatii_Load(object sender, EventArgs e)
        {
            extragereCountInregistrari(null,null,null,null);
            AfisareAngajati(null, null, null, null, 0, AngajatiAfisat);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Inapoi_Click(object sender, EventArgs e)
        {
            this.Close();
 
        }
    }
}
