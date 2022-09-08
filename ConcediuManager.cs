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
    public partial class ConcediuManager : Form
    {
        static readonly HttpClient client = new HttpClient();
      
        List<string> listaStare;
        int idAngajatSelectat;
        Angajat angajat;
        public ConcediuManager(Angajat a)
        {
            InitializeComponent();
            angajat = a;
            extragereConcediiDBAsync();
            extragereStareConcediuDB();
            extragereManageri();
            DataGridViewButtonCell btn = new DataGridViewButtonCell();
        }

        
        public async Task extragereConcediiDBAsync()
        {
            dgvConcediuManager.Rows.Clear();
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
                        row.Cells[4].Value = c.TipConcediu.Nume;
                        row.Cells[5].Value = c.Comentarii;
                        (row.Cells[6] as DataGridViewComboBoxCell).Value = c.StareConcediu.Id;
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
                HttpResponseMessage response = await client.GetAsync("http://localhost:5096/StareConcediu/GetAllStareConcediu");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                List<StareConcediu> listaStareConcedii = JsonConvert.DeserializeObject<List<StareConcediu>>(responseBody);


                (dgvConcediuManager.Columns[6] as DataGridViewComboBoxColumn).DataSource = listaStareConcedii;
                (dgvConcediuManager.Columns[6] as DataGridViewComboBoxColumn).DisplayMember = "Nume";
                (dgvConcediuManager.Columns[6] as DataGridViewComboBoxColumn).ValueMember = "Id";

                foreach (StareConcediu sc in listaStareConcedii)
                {
                    if (!sc.Nume.Equals("In asteptare"))
                    {
                        cbStareConcediu.Items.Add(sc.Nume);
                    }

                }

                
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

     

        public async void extragereManageri()
        {
            HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}Angajat/GetAllAngajatiNumeConcatenat", Globals.apiUrl));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<Angajat> listaAngajati = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);

            

        }

        private async void dgvConcedii_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                int selectedRowIndex = dgvConcediuManager.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvConcediuManager.Rows[selectedRowIndex];
                DataGridViewComboBoxCell combobox = dgvConcediuManager.Rows[selectedRowIndex].Cells[6] as DataGridViewComboBoxCell;

                int stareConcediuId = Convert.ToInt32((selectedRow.Cells[6] as DataGridViewComboBoxCell).Value);
                int idConcediu = Convert.ToInt32(selectedRow.Tag);

                HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}Concediu/UpdateStareConcediu?idConcediu={1}&idStareConcediu={2}", Globals.apiUrl, idConcediu, stareConcediuId));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();



                if (bool.Parse(responseBody))
                {
                    extragereConcediiDBAsync();
                    //MessageBox.Show("Concediu actualizat!");
                }
            }
            else
            {
                return;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
