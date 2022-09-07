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
    public partial class ConcediuManager : Form
    {
        static readonly HttpClient client = new HttpClient();
        string connectionString;
        List<string> listaStare;
        List<string> managerstring;
        int idAngajatSelectat;
        int stareConcediuId;
        int idConcediu;
        Angajat angajat;
        public ConcediuManager(Angajat a)
        {
            InitializeComponent();
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";
            angajat = a;
            extragereConcediiDBAsync();
            extragereStareConcediuDB();


            listaStare = new List<string>();

            //foreach (string s in listaStare)
            //{
            //   string[] str = s.Split(',');
            //    cbStareConcediu.Items.Add(str[1]);

            //}
            //cbStareConcediu.SelectedIndex = 0;


           managerstring = extragereManageriDB();
        }

        public async Task extragereConcediiDBAsync()
        {

            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:5096/Concediu/GetAllConcediuManager");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Concediu> listaConcedii = JsonConvert.DeserializeObject<List<Concediu>>(responseBody);

                foreach (Concediu c in listaConcedii)
                {
                    if (c.StareConcediu.Nume.Equals("In asteptare"))
                    {
                        DataGridViewRow row = (DataGridViewRow)dgvConcediuManager.Rows[0].Clone();
                        row.Cells[0].Value = c.Angajat.Nume + " " + c.Angajat.Prenume;

                        DateTime dataInceput = Convert.ToDateTime(c.DataInceput.ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
                        string dataI = dataInceput.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        row.Cells[1].Value = dataI;

                        DateTime dataSfarsit = Convert.ToDateTime(c.DataSfarsit.ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
                        string dataS = dataSfarsit.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        row.Cells[2].Value = dataS;

                        row.Cells[3].Value = c.Inlocuitor.Nume + " " + c.Inlocuitor.Prenume;
                        row.Cells[4].Value = c.Comentarii;
                        (row.Cells[5] as DataGridViewComboBoxCell).Value = c.StareConcediu.Id;
                        row.Tag = c.Id;
                        dgvConcediuManager.Rows.Add(row);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        public async void extragereStareConcediuDB()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:5096/GetAllStareConcediu");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                List<StareConcediu> listaStareConcedii = JsonConvert.DeserializeObject<List<StareConcediu>>(responseBody);


                (dgvConcediuManager.Columns[5] as DataGridViewComboBoxColumn).DataSource = listaStareConcedii;
                (dgvConcediuManager.Columns[5] as DataGridViewComboBoxColumn).DisplayMember = "Nume";
                (dgvConcediuManager.Columns[5] as DataGridViewComboBoxColumn).ValueMember = "Id";

                foreach (StareConcediu sc in listaStareConcedii)
                {
                    if (!sc.Nume.Equals("In asteptare"))
                    {
                        //(dgvConcedii.Columns[5] as DataGridViewComboBoxColumn).Items.Add(new {Text = sc.Nume, Value = sc});
                        cbStareConcediu.Items.Add(sc.Nume);
                        listaStare.Add(sc.Id + ", " + sc.Nume);

                    }
                }

                //foreach (StareConcediu sc in listaStareConcedii)
                //{
                //    if (!sc.Nume.Equals("In asteptare"))
                //    {
                //        //(dgvConcedii.Columns[5] as DataGridViewComboBoxColumn).Items.Add(new {Text = sc.Nume, Value = sc});
                //        (dgvConcedii.Columns[5] as DataGridViewComboBoxColumn).Items.Add(sc.Nume);

                //    }
                //}
                //ComboBox cb = new ComboBox();
                //cbStareConcediu.Select
                //(dgvConcedii.Columns[5] as DataGridViewComboBoxColumn).
                //.DisplayMember = listaStareConcedii.ToString();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void cbStareConcediu_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string str in listaStare)
            {
                string[] s = str.Split(',');
                if (s[1].CompareTo(cbStareConcediu.Text) == 0)
                {
                    stareConcediuId = Convert.ToInt32(s[0]);

                }
            }
        }

        private void Actualizare_Click(object sender, EventArgs e)
        {
            
            string message = "Sigur vrei sa actualizezi lista de concedii?";
            string title = "Actualizare stare concedii";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {

                string message2 = "Lista a fost actualizata";


                SqlConnection conexiune = new SqlConnection(connectionString);

                MessageBox.Show(idConcediu.ToString() + ' ' + stareConcediuId.ToString());

                string updateSQL = "UPDATE c SET stareConcediuId = @stareConcediuId FROM Concediu c JOIN StareConcediu sc ON sc.id = c.stareConcediuId WHERE stareConcediuId = 1 and c.id = " + idConcediu;

                SqlCommand queryUpdate = new SqlCommand(updateSQL);
                try
                {
                    conexiune.Open();
                    queryUpdate.Connection = conexiune;
                    queryUpdate.Parameters.AddWithValue("@stareConcediuId", stareConcediuId);
                    queryUpdate.ExecuteNonQuery();
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

        public List<string> extragereManageriDB()
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

                MessageBox.Show(extrageAngajati[1].ToString());
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

        private void dgvConcediuManager_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvConcediuManager.SelectedRows)
            {
                string nume_prenume = row.Cells[0].ToString();
                idConcediu = Convert.ToInt32(row.Tag);

                foreach (string s in managerstring)
                {
                    string[] t = s.Split(',');
                    if (nume_prenume.Equals(t[1]))
                    {
                        idAngajatSelectat = Convert.ToInt32(t[0]);
                    }
                }

            }

        }
        private void dgvConcediuManager_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected)
                return;

        }

       /* private void btnInchidereCM_Click(object sender, EventArgs e)
        {
            
        }*/

        private void btnInchidereCM_Click_1(object sender, EventArgs e)
        {
            PaginaPrincipala.PaginaPrincipala paginap = new PaginaPrincipala.PaginaPrincipala(angajat);
            paginap.Show();
            this.Close();
        }
    }
}
