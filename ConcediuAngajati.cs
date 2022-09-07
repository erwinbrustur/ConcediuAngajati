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
    public partial class ConcediuAngajati : Form
    {
     
        string connectionString;
        List<string> listaStare;
        List<string> angajatistring;
        int idAngajatSelectat;
        int stareConcediuId;
        int idConcediu;
        Angajat angajat;
        public ConcediuAngajati(Angajat a)
        {
            InitializeComponent();
            angajat = a;
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";
            extragereConcediiDBAsync();
            extragereStareConcediuDB();


            listaStare = new List<string>();

            //foreach (string s in listaStare)
            //{
            //    string[] str = s.Trim().Split(',');
            //    if (!str[1].Trim().Equals("In asteptare"))
            //    {
            //        //MessageBox.Show(str[1]);
            //        //MessageBox.Show("In asteptare");
            //        cbStareConcediu.Items.Add(str[1]);
            //    }

            //}
            //cbStareConcediu.SelectedIndex = 0;

            //foreach (string s in listaStare)
            //{
            //    string[] str = s.Split(',');
            //    if(!str[1].Trim().Equals("In asteptare"))
            //    {
            //        (dgvConcedii.Columns[5] as DataGridViewComboBoxColumn).Items.Add(str[1]);
            //    }

            //}

            DataGridViewButtonCell btn = new DataGridViewButtonCell();


            angajatistring = extragereAngajatiDB();
        }

        public async void extragereStareConcediuDB()
        {
            try
            {
                HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}StareConcediu/GetAllStareConcediu", Globals.apiUrl));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                List<StareConcediu> listaStareConcedii = JsonConvert.DeserializeObject<List<StareConcediu>>(responseBody);


                (dgvConcedii.Columns[6] as DataGridViewComboBoxColumn).DataSource = listaStareConcedii;
                (dgvConcedii.Columns[6] as DataGridViewComboBoxColumn).DisplayMember = "Nume";
                (dgvConcedii.Columns[6] as DataGridViewComboBoxColumn).ValueMember = "Id";

                foreach (StareConcediu sc in listaStareConcedii)
                {
                    if (!sc.Nume.Equals("In asteptare"))
                    {
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

        public async Task extragereConcediiDBAsync()
        {

            try
            {
                HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}Concediu/GetAllConcediuAngajati", Globals.apiUrl));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Concediu> listaConcedii = JsonConvert.DeserializeObject<List<Concediu>>(responseBody);

                foreach (Concediu c in listaConcedii)
                {
                    if (c.StareConcediu.Nume.Equals("In asteptare"))
                    {
                        DataGridViewRow row = (DataGridViewRow)dgvConcedii.Rows[0].Clone();
                        row.Cells[0].Value = c.Angajat.Nume + " " + c.Angajat.Prenume;

                        DateTime dataInceput = Convert.ToDateTime(c.DataInceput.ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
                        string dataI = dataInceput.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        row.Cells[1].Value = dataI;

                        DateTime dataSfarsit = Convert.ToDateTime(c.DataSfarsit.ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
                        string dataS = dataSfarsit.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        row.Cells[2].Value = dataS;

                        row.Cells[3].Value = c.Inlocuitor.Nume + " " + c.Inlocuitor.Prenume;
                        row.Cells[4].Value = c.TipConcediu.Nume;
                        row.Cells[5].Value = c.Comentarii;
                        (row.Cells[6] as DataGridViewComboBoxCell).Value = c.StareConcediu.Id;
                        row.Tag = c.Id;
                        dgvConcedii.Rows.Add(row);
                    }

                }
            }
            catch (Exception ex)
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

        private void dgvConcedii_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //if (e.StateChanged != DataGridViewElementStates.Selected)
            //    MessageBox.Show("click");
            //return;
            //foreach(DataGridViewCell cell in dgvConcedii.SelectedCells)
            //{
            //    if(cell.RowIndex == 5)
            //    {
            //        MessageBox.Show("click");
            //    }
            //}

        }




        private void dgvConcedii_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvConcedii.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvConcedii.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvConcedii.Rows[selectedRowIndex];
                //MessageBox.Show(selectedRow.Tag.ToString()+"tg");
                // DataGridViewComboBoxColumn comboStareConcediu = selectedRow.Cells[5].Value as DataGridViewComboBoxColumn;
                //DataGridViewColumnButton 
                //Console.WriteLine(selectedRowIndex);

                //dgvConcedii.CellClick += CellButton_click;



            }

        }

        //public async void updateConcediu()
        //{
        //    HttpResponseMessage response = await client.GetAsync("http://localhost:5096/PutConcediu?idConcediu=" + idConcediu +"&idStareConcediu=1");
        //    response.EnsureSuccessStatusCode();
        //    string responseBody = await response.Content.ReadAsStringAsync();

        //    List<StareConcediu> listaStareConcedii = JsonConvert.DeserializeObject<List<StareConcediu>>(responseBody);

        //    //
        //}

        public void CellButton_click(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            //MessageBox.Show("tyuio");

            //if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            //{
            //    int selectedRowIndex = dgvConcedii.SelectedCells[0].RowIndex;
            //    DataGridViewRow selectedRow = dgvConcedii.Rows[selectedRowIndex];
            //    MessageBox.Show(selectedRowIndex.ToString());

            //    //HttpResponseMessage response = await client.GetAsync("http://localhost:5096/PutConcediu?idConcediu=" + selectedRow.Tag + "&idStareConcediu=" + );
            //    //response.EnsureSuccessStatusCode();
            //    //string responseBody = await response.Content.ReadAsStringAsync();

            //    //List<StareConcediu> listaStareConcedii = JsonConvert.DeserializeObject<List<StareConcediu>>(responseBody);





            //}
            //else
            //{
            //    return;
            //}
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


        private void btnX_Click(object sender, EventArgs e)
        {
            Close();
        }


        private async void dgvConcedii_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private async void dgvConcedii_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                int selectedRowIndex = dgvConcedii.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvConcedii.Rows[selectedRowIndex];
                DataGridViewComboBoxCell combobox = dgvConcedii.Rows[selectedRowIndex].Cells[6] as DataGridViewComboBoxCell;

                int stareConcediuId = Convert.ToInt32((selectedRow.Cells[6] as DataGridViewComboBoxCell).Value);
                int idConcediu = Convert.ToInt32(selectedRow.Tag);

                MessageBox.Show(stareConcediuId + " " + idConcediu);

                //string urlUpdate=

                HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}Concediu/UpdateStareConcediu?idConcediu={1}&idStareConcediu={2}", Globals.apiUrl, idConcediu, stareConcediuId));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                MessageBox.Show(responseBody);
            }
            else
            {
                return;
            }
        }
    }

}
