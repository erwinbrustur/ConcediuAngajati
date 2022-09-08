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
        Angajat angajat;

        public ConcediuAngajati(Angajat a)
        {
            InitializeComponent();
            angajat = a;
            extragereAngajati();
            extragereTipConcediu();
            extragereConcediiDBAsync();
            extragereStareConcediuDB();

            // BindingNavigator 
        }

        public async void extragereAngajati()
        {
            HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}Angajat/GetAllAngajatiNumeConcatenat", Globals.apiUrl));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<Angajat> listaAngajati = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);

            //cbAngajati.DataSource = listaAngajati;
            //cbAngajati.DisplayMember = "Nume";
            //cbAngajati.ValueMember = "Id";
            //cbAngajati.SelectedIndex = angajat.Id;

        }

        public async void extragereTipConcediu()
        {
            HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}TipConcediu/GetAllTipConcediu", Globals.apiUrl));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<TipConcediu> listaTipConcediu = JsonConvert.DeserializeObject<List<TipConcediu>>(responseBody);

            cbTipConcediu.DataSource = listaTipConcediu;
            cbTipConcediu.DisplayMember = "Nume";
            cbTipConcediu.ValueMember = "Id";

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

                cbStareConcediu.DataSource = listaStareConcedii;
                cbStareConcediu.DisplayMember = "Nume";
                cbStareConcediu.ValueMember = "Id";

            }
            catch (HttpRequestException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void populareDataGridView(List<Concediu> concedii)
        {
            dgvConcedii.Rows.Clear();
            foreach (Concediu c in concedii)
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
        public async Task extragereConcediiDBAsync()
        {
            
            try
            {
                HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}Concediu/GetAllConcediuAngajati", Globals.apiUrl));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Concediu> listaConcedii = JsonConvert.DeserializeObject<List<Concediu>>(responseBody);

                populareDataGridView(listaConcedii);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Close();
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

                HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}Concediu/UpdateStareConcediu?idConcediu={1}&idStareConcediu={2}", Globals.apiUrl, idConcediu, stareConcediuId));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                

                if (bool.Parse(responseBody))
                {
                    extragereConcediiDBAsync();
                }
            }
            else
            {
                return;
            }
        }

        private async void btnCauta_Click(object sender, EventArgs e)
        {
            string nume;
            if (!tbNume.Text.Equals(""))
            {
                nume = tbNume.Text;
            }
            else
            {
                nume = "";
            }

            string prenume;
            if (!tbNume.Text.Equals(""))
            {
                prenume = tbPrenume.Text;
            }
            else
            {
                prenume = "";
            }

            int idTipConcediuSelectat = Convert.ToInt32(cbTipConcediu.SelectedValue);
            int idStareConcediuSelectat = Convert.ToInt32(cbStareConcediu.SelectedValue);

            HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}Concediu/GetConcediiAngajatiFiltrati?nume={1}&prenume={2}&idTipConcediu={3}&idStareConcediu={4}", Globals.apiUrl, nume, prenume, idTipConcediuSelectat, idStareConcediuSelectat));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Concediu> listaConcedii = JsonConvert.DeserializeObject<List<Concediu>>(responseBody);
            MessageBox.Show(listaConcedii.Count.ToString());

            populareDataGridView(listaConcedii);

        }

    }

}
