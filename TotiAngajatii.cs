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
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";
            angajat = a;

            ExtragereAngajatAsync();
            angajatistring = ExtragereAngajati();
        }

        public async Task ExtragereAngajatAsync()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:5096/GetAllStareConcediu");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();



            List<Angajat> listaAngajati = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);
            try
            {
                

                foreach(Angajat a in listaAngajati)
                {
                    ListViewItem item = new ListViewItem(a.Nume.ToString());//Nume

                    
                    item.SubItems.Add(a.Prenume.ToString());//Prenume
                    item.SubItems.Add(a.Email.ToString());//Email
                    item.SubItems.Add((a.Manager.Nume+ ' ' + a.Manager.Prenume).ToString());//Manager
                    item.SubItems.Add(a.Departament.Denumire);//Departament
                   
                    listView1.Items.Add(item);
                    
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            

        }
        public List<string> ExtragereAngajati()
        {
            List<string> extrageAngajati = new List<string>();
            string selectSQL = "SELECT id, nume, prenume FROM Angajat ";

            SqlConnection conexiune = new SqlConnection(connectionString);
            SqlCommand querySelect = new SqlCommand(selectSQL);
            try
            {
                conexiune.Open();
                querySelect.Connection = conexiune;
                SqlDataReader reader = querySelect.ExecuteReader();

                while (reader.Read())
                {
                    extrageAngajati.Add(reader[0].ToString() + ", " + reader[1].ToString() + " " + reader[2].ToString());

                }


                return extrageAngajati;
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


        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
