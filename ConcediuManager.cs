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
        int nrTotalInregistrari;
        int nrConcediiDeAfisare = 10;
        List<Concediu> listaConcedii;
        public ConcediuManager(Angajat a)
        {
            InitializeComponent();
            angajat = a;
            extragereTipConcediu();
            extragereStareConcediuDB();
            extragereManageri();
            
        }

        private void ConcediuAngajati_Load(object sender, EventArgs e)
        {
            extragereCountInregistrari(null, null, null, null, (bool)angajat.EsteAdmin, angajat.Id);
            extragereConcedii(null, null, null, null, 0, nrConcediiDeAfisare, (bool)angajat.EsteAdmin, (int)angajat.Id);
            //ReIncaracareDGV();
        }

        private void obtinerePagini(int nrTotalPagini)
        {
            int x = 10;
            //Button btnInapoi = new Button();
            //btnInapoi.Text = "<";
            //btnInapoi.Location = new Point(x + 5);
            //btnInapoi.Width = 30;
            //btnInapoi.Height = 30;
            //btnInapoi.Click += btnInapoi_click;
            //panel1.Controls.Add(btnInapoi);
            panel1.Controls.Clear();

            for (int i = 0; i < nrTotalPagini; i++)
            {
                Button btn = new Button();
                btn.Text = (i + 1).ToString();
                btn.Location = new Point(x + 50);
                btn.Width = 30;
                btn.Height = 30;
                btn.Click += btn_click;
                panel1.Controls.Add(btn);
                x += 30;
            }
        }

        private void btn_click(object sender, EventArgs e)
        {
            int paginaS = Convert.ToInt32(((Button)sender).Text);
            // ReIncaracareDGV(paginaS - 1);
            string nume;
            if (!tbNume.Text.Equals(""))
            {
                nume = tbNume.Text;
            }
            else
            {
                nume = null;
            }

            string prenume;
            if (!tbPrenume.Text.Equals(""))
            {
                prenume = tbPrenume.Text;
            }
            else
            {
                prenume = null;
            }

            int? idTipConcediuSelectat;
            if (cbTip.SelectedValue != null)
            {
                idTipConcediuSelectat = Convert.ToInt32(cbTip.SelectedValue);
            }
            else
            {
                idTipConcediuSelectat = null;
            }

            int? idStareConcediuSelectat;
            if (cbStare.SelectedValue != null)
            {
                idStareConcediuSelectat = Convert.ToInt32(cbStare.SelectedValue);
            }
            else
            {
                idStareConcediuSelectat = null;
            }
            extragereConcedii(nume, prenume, idTipConcediuSelectat, idStareConcediuSelectat, (paginaS - 1) * nrConcediiDeAfisare, nrConcediiDeAfisare, (bool)angajat.EsteAdmin, angajat.Id);
        }

        public void populareDataGridView(List<Concediu> concedii)
        {
            dgvConcediuManager.Rows.Clear();
            foreach (Concediu c in concedii)
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

        private void extragereCountInregistrari(string? nume, string? prenume, int? idTipConcediu, int? idStareConcediu, bool EsteAdmin, int idManager)
        {
            HttpResponseMessage response = Globals.client.GetAsync(String.Format("{0}Concediu/GetNrTotalConcedii?nume={1}&prenume={2}&idTipConcediu={3}&idStareConcediu={4}&EsteAdmin=false&idManager=26", Globals.apiUrl, nume, prenume, idTipConcediu, idStareConcediu, EsteAdmin, idManager)).Result;

            string responseBody2 = response.Content.ReadAsStringAsync().Result;
            nrTotalInregistrari = JsonConvert.DeserializeObject<int>(responseBody2);

            int totalPagini = (int)Math.Ceiling(decimal.Parse(nrTotalInregistrari.ToString()) / decimal.Parse(nrConcediiDeAfisare.ToString()));
            obtinerePagini(totalPagini);

        }

        private async void extragereConcedii(string? nume, string? prenume, int? idTipConcediu, int? idStareConcediu, int? nrInceputInregistrari, int? nrTotalDeAfisat, bool EsteAdmin, int idManager)
        {
            HttpResponseMessage response = Globals.client.GetAsync(String.Format("{0}Concediu/GetConcediiAngajatiFiltrati?nume={1}&prenume={2}&idTipConcediu={3}&idStareConcediu={4}&nrInceputInregistrari={5}&nrTotalInregistrariDeAdus={6}&EsteAdmin=false&idManager=26", Globals.apiUrl, nume, prenume, idTipConcediu, idStareConcediu, nrInceputInregistrari, nrTotalDeAfisat)).Result;
            response.EnsureSuccessStatusCode();
            string responseBody =  response.Content.ReadAsStringAsync().Result;
            listaConcedii = JsonConvert.DeserializeObject<List<Concediu>>(responseBody);


            populareDataGridView(listaConcedii);

        }

        public async void extragereTipConcediu()
        {
            HttpResponseMessage response =  Globals.client.GetAsync(String.Format("{0}TipConcediu/GetAllTipConcediu", Globals.apiUrl)).Result;
            response.EnsureSuccessStatusCode();
            string responseBody =  response.Content.ReadAsStringAsync().Result;

            List<TipConcediu> listaTipConcediu = JsonConvert.DeserializeObject<List<TipConcediu>>(responseBody);

            cbTip.DataSource = listaTipConcediu;
            cbTip.DisplayMember = "Nume";
            cbTip.ValueMember = "Id";
            cbTip.SelectedItem = null;

        }

        public async void extragereStareConcediuDB()
        {
            try
            {
                HttpResponseMessage response =  client.GetAsync("http://localhost:5096/StareConcediu/GetAllStareConcediu").Result;
                response.EnsureSuccessStatusCode();
                string responseBody =  response.Content.ReadAsStringAsync().Result;

                List<StareConcediu> listaStareConcedii = JsonConvert.DeserializeObject<List<StareConcediu>>(responseBody);


                (dgvConcediuManager.Columns[6] as DataGridViewComboBoxColumn).DataSource = listaStareConcedii;
                (dgvConcediuManager.Columns[6] as DataGridViewComboBoxColumn).DisplayMember = "Nume";
                (dgvConcediuManager.Columns[6] as DataGridViewComboBoxColumn).ValueMember = "Id";


                cbStare.DataSource = listaStareConcedii;
                cbStare.DisplayMember = "Nume";
                cbStare.ValueMember = "Id";
                cbStare.SelectedItem = null;


            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

     

        public async void extragereManageri()
        {
            HttpResponseMessage response =  Globals.client.GetAsync(String.Format("{0}Angajat/GetAllAngajatiNumeConcatenat", Globals.apiUrl)).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;

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

                HttpResponseMessage response =  Globals.client.GetAsync(String.Format("{0}Concediu/UpdateStareConcediu?idConcediu={1}&idStareConcediu={2}", Globals.apiUrl, idConcediu, stareConcediuId)).Result;
                response.EnsureSuccessStatusCode();
                string responseBody =  response.Content.ReadAsStringAsync().Result;



                
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
            Environment.Exit(1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblNume_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nume;
            if (!tbNume.Text.Equals(""))
            {
                nume = tbNume.Text;
            }
            else
            {
                nume = null;
            }

            string prenume;
            if (!tbPrenume.Text.Equals(""))
            {
                prenume = tbPrenume.Text;
            }
            else
            {
                prenume = null;
            }

            int? idTipConcediuSelectat;
            if (cbTip.SelectedValue != null)
            {
                idTipConcediuSelectat = Convert.ToInt32(cbTip.SelectedValue);
            }
            else
            {
                idTipConcediuSelectat = null;
            }

            int? idStareConcediuSelectat;
            if (cbStare.SelectedValue != null)
            {
                idStareConcediuSelectat = Convert.ToInt32(cbStare.SelectedValue);
            }
            else
            {
                idStareConcediuSelectat = null;
            }
            extragereCountInregistrari(nume, prenume, idTipConcediuSelectat, idStareConcediuSelectat, (bool)angajat.EsteAdmin, angajat.Id);
            extragereConcedii(nume, prenume, idTipConcediuSelectat, idStareConcediuSelectat, 0, nrConcediiDeAfisare, (bool)angajat.EsteAdmin, angajat.Id);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PaginaPrincipala.PaginaPrincipala pp = new PaginaPrincipala.PaginaPrincipala(angajat);
            pp.Show();
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            extragereCountInregistrari(null, null, null, null, (bool)angajat.EsteAdmin, angajat.Id);
            extragereConcedii(null, null, null, null, 0, nrConcediiDeAfisare, (bool)angajat.EsteAdmin, (int)angajat.Id);
            tbNume.Clear();
            tbPrenume.Clear();
            cbTip.SelectedItem = null;
            cbStare.SelectedItem = null;
        }
    }

    
}
