using ConcediuAngajati.PaginaPrincipala;
using ConcediuAngajati.Utils;
using Newtonsoft.Json;
using ProiectASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcediuAngajati
{


    public partial class IstoricConcedii : Form
    {
        static readonly HttpClient client = new HttpClient();
        string connectionString;
        List<string> listaStare;
        List<string> angajatistring;
        int idAngajatSelectat;
        int stareConcediuId;
        int idConcediu;
        Angajat angajat;
        public IstoricConcedii(Angajat a)
        {
            InitializeComponent();
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";
            angajat = a;
            //listaStare = extragereStareConcediuDB();

            extragereConcediiAsyncDB();


            //angajatistring = extragereAngajatiDB();
        }

        //public void extragereConcediiDB()
        //{
        //    List<Concediu> listaConcedii = new List<Concediu>();
        //    string selectSQL = "SELECT c.id, a.nume + ' ' + a.prenume as Nume, Convert(date, c.dataInceput) as 'Data Inceput', Convert(date, c.dataSfarsit) as 'Data Sfarsit',tc.nume as TipConcediu, a2.nume + ' ' + a2.prenume as Inlocuitor, c.comentarii as 'Comentarii', sc.nume as Stare, t.ZileConcediuRamas FROM Angajat a JOIN Concediu c ON a.id = c.angajatId JOIN Angajat a2 ON a2.id = c.inlocuitorId JOIN StareConcediu sc ON sc.id = c.stareConcediuId JOIN(SELECT angajatId, 21 - isnull(Sum(ZileConcediu),0) as ZileConcediuRamas from Concediu group by angajatId ) t on t.angajatId = a.id JOIN  TipConcediu tc ON tc.id = c.tipConcediuId";

        //    SqlConnection conexiune = new SqlConnection(connectionString);
        //    SqlCommand querySelect = new SqlCommand(selectSQL);
        //    try
        //    {
        //        conexiune.Open();
        //        querySelect.Connection = conexiune;

        //        SqlDataReader reader = querySelect.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            ListViewItem item = new ListViewItem(reader[1].ToString());

        //            string[] s1 = reader[2].ToString().Split(' ');
        //            string[] s2 = reader[3].ToString().Split(' ');
        //            item.SubItems.Add(s1[0].ToString());
        //            item.SubItems.Add(s2[0].ToString());
        //            item.SubItems.Add(reader[4].ToString());
        //            item.SubItems.Add(reader[5].ToString());
        //            item.SubItems.Add(reader[6].ToString());
        //            item.SubItems.Add(reader[7].ToString());
        //            item.SubItems.Add(reader[8].ToString());

        //            listView1.Items.Add(item);
        //            //Concediu c = new Concediu(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()), Convert.ToDateTime(reader[2].ToString()), Convert.ToDateTime(reader[3].ToString()), Convert.ToInt32(reader[4].ToString()), reader[5].ToString(), Convert.ToInt32(reader[6].ToString()), Convert.ToInt32(reader[7].ToString()));
        //            //listaConcedii.Add(c);
        //        }


        //        //DataTable dt = new DataTable();
        //        //SqlDataAdapter adapt = new SqlDataAdapter(selectSQL, conexiune);
        //        //adapt.Fill(dt);
        //        //dgvConcedii.DataSource = dt;



        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);

        //    }
        //    finally
        //    {
        //        conexiune.Close();


        //    }


        //}


        private void btnInchidere_Click(object sender, EventArgs e)
        {
            PaginaPrincipala.PaginaPrincipala paginap = new PaginaPrincipala.PaginaPrincipala(angajat);
            paginap.Show();
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        public List<string> extragereAngajatiDB()
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

        public List<string> extragereStareConcediuDB()
        {
            List<string> stareConcediu = new List<string>();
            string selectSQL = "SELECT * from StareConcediu";
            SqlConnection conexiune = new SqlConnection(connectionString);
            SqlCommand querySelect = new SqlCommand(selectSQL);
            try
            {
                conexiune.Open();
                querySelect.Connection = conexiune;
                SqlDataReader reader = querySelect.ExecuteReader();

                while (reader.Read())
                {
                    stareConcediu.Add(reader[0] + ", " + reader[1].ToString());

                }


                return stareConcediu;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                conexiune.Close();


            }

        }

        public async void extragereConcediiAsyncDB()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(String.Format("{0}Concediu/GetAllIstoricConcedii?angajatId={1}", Globals.apiUrl, angajat.Id));
                response.EnsureSuccessStatusCode();
                string responsivebody = await response.Content.ReadAsStringAsync();

                List<Concediu> concedii = JsonConvert.DeserializeObject<List<Concediu>>(responsivebody);

                foreach(Concediu c in concedii)
                {
                    ListViewItem item = new ListViewItem(c.Angajat.Nume + " " + c.Angajat.Prenume);
                    DateTime DataInceput = Convert.ToDateTime(c.DataInceput.ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
                    string dataI = DataInceput.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    item.SubItems.Add(dataI);

                    DateTime DataSfarsit = Convert.ToDateTime(c.DataSfarsit.ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
                    string dataSf = DataSfarsit.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    item.SubItems.Add(dataSf);
                    item.SubItems.Add(c.TipConcediu.Nume.ToString());
                    item.SubItems.Add(c.Inlocuitor.Nume + " " + c.Inlocuitor.Prenume);
                    item.SubItems.Add(c.Comentarii.ToString());
                    item.SubItems.Add(c.StareConcediu.Nume.ToString());
                    item.SubItems.Add(c.ZileConcediu.ToString());
                    listView1.Items.Add(item);

                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void lblIstoric_Click(object sender, EventArgs e)
        {

        }
    }
}