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
            ExtragereAngajatAsync(a);
           
        }

        public async Task ExtragereAngajatAsync(Angajat ang)
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



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            

        }
        
        


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
        }
        public async void extragereIdDepartament()
        {
            HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}DepartamentSiFunctie/GetAllDepartaments", Globals.apiUrl));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<Angajat> ListaDepartament = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);

            CBDepartament.DataSource = ListaDepartament;
            CBDepartament.DisplayMember = "Nume";
            CBDepartament.ValueMember = "Id";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string nume;
            if (!TBNume.Text.Equals(""))
            {
                nume = TBNume.Text;
            }
            else
            {
                nume = "";
            }

            string prenume;
            if (!TBPrenume.Text.Equals(""))
            {
                prenume = TBPrenume.Text;
            }
            else
            {
                prenume = "";
            }

            int IdManagerSelectat = Convert.ToInt32(CBManager.SelectedValue);
            int IdDepartamentSelectat = Convert.ToInt32(CBDepartament.SelectedValue);

            HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}Orice/GetAngajatiFiltrat?nume={1}&prenume={2}&IdDepartamentSelectat={3}&IdManagerSelectat={4}", Globals.apiUrl, nume, prenume, IdDepartamentSelectat, IdManagerSelectat));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Concediu> listaConcedii = JsonConvert.DeserializeObject<List<Concediu>>(responseBody);

        }
    }
}
