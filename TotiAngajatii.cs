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

        public TotiAngajatii(Angajat a)
        {
            InitializeComponent();
            angajat = a;
            //ExtragereAngajatAsync(a);
            extragereIdDepartament();
            extragereIdManager();
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
        
        


        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

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

            AfisareAngajati(nume,prenume,IdDepartamentSelectat,IdManagerSelectat);
        }

        public void AfisareAngajati(string? nume, string? prenume, int? IdDepartamentSelectat, int? IdManagerSelectat)
        {
            HttpResponseMessage response = Globals.client.GetAsync(String.Format("{0}Orice/GetAngajatiFiltrat?nume={1}&prenume={2}&IdDepartamentSelectat={3}&IdManagerSelectat={4}", Globals.apiUrl, nume, prenume, IdDepartamentSelectat, IdManagerSelectat)).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            List<Angajat> listaAngajati = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);
            listView1.Items.Clear();
            MessageBox.Show(listaAngajati.Count().ToString());
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
            AfisareAngajati(null, null, null, null);
        }
    }
}
