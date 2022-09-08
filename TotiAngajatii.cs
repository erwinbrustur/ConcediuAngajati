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
                    if ((bool)!a.EsteAdmin && (bool)!a.concediat)
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
                        if(a.Departament != null)
                        {
                            item.SubItems.Add(a.Departament.Denumire);//Departament
                        }
                        else
                        {
                            item.SubItems.Add("Administrator");//Departament
                        }
                        
                        
                        

                        listView1.Items.Add(item);
                    }
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
    }
}
