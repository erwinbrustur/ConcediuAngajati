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
        int nrConcediiDeAfisare = 10;
        int nrTotalInregistrari;
        List<Concediu> listaConcedii;

        public ConcediuAngajati(Angajat a)
        {
            InitializeComponent();
            angajat = a;
            extragereTipConcediu();
            extragereStareConcediuDB();
            
        }

        private void ReIncaracareDGV(int paginaselectata = 0)
        {

            extragereConcedii(null, null, null, null, paginaselectata * nrConcediiDeAfisare, nrConcediiDeAfisare,(bool)angajat.EsteAdmin,(int)angajat.Id);
            //int totalPagini = (int)Math.Ceiling(decimal.Parse(nrTotalInregistrari.ToString()) / decimal.Parse(nrConcediiDeAfisate.ToString()));
            //obtinerePagini(totalPagini);

        }
        private void ConcediuAngajati_Load(object sender, EventArgs e)
        {
            extragereCountInregistrari(null, null, null,null,(bool)angajat.EsteAdmin,angajat.Id);
            extragereConcedii(null, null, null, null, 0, nrConcediiDeAfisare,(bool)angajat.EsteAdmin,(int)angajat.Id);
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
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Transparent;
                btn.Click += btn_click;
                panel1.Controls.Add(btn);
                x += 30;
            }
        }

        private void btnInainte_click(object sender, EventArgs e)
        {
            extragereConcedii(null, null, null, null, 0, nrConcediiDeAfisare,(bool)angajat.EsteAdmin,angajat.Id);
        }

        private void btnInapoi_click(object sender, EventArgs e)
        {
            extragereConcedii(null, null, null, null, 0, nrConcediiDeAfisare, (bool)angajat.EsteAdmin, angajat.Id);
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
            if (cbTipConcediu.SelectedValue != null)
            {
                idTipConcediuSelectat = Convert.ToInt32(cbTipConcediu.SelectedValue);
            }
            else
            {
                idTipConcediuSelectat = null;
            }

            int? idStareConcediuSelectat;
            if (cbStareConcediu.SelectedValue != null)
            {
                idStareConcediuSelectat = Convert.ToInt32(cbStareConcediu.SelectedValue);
            }
            else
            {
                idStareConcediuSelectat = null;
            }
            extragereConcedii(nume, prenume, idTipConcediuSelectat, idStareConcediuSelectat, (paginaS - 1) * nrConcediiDeAfisare, nrConcediiDeAfisare, (bool)angajat.EsteAdmin, angajat.Id);
        }

        private void getNrTotalConcedii()
        {

        }

        private  void extragereCountInregistrari(string? nume, string? prenume, int? idTipConcediu, int? idStareConcediu,bool EsteAdmin, int idManager)
        {
            HttpResponseMessage response = Globals.client.GetAsync(String.Format("{0}Concediu/GetNrTotalConcedii?nume={1}&prenume={2}&idTipConcediu={3}&idStareConcediu={4}&EsteAdmin={5}&idManager={6}", Globals.apiUrl, nume, prenume, idTipConcediu, idStareConcediu,EsteAdmin,idManager)).Result;
           
            string responseBody2 =  response.Content.ReadAsStringAsync().Result;
            nrTotalInregistrari = JsonConvert.DeserializeObject<int>(responseBody2);

            int totalPagini = (int)Math.Ceiling(decimal.Parse(nrTotalInregistrari.ToString()) / decimal.Parse(nrConcediiDeAfisare.ToString()));
            obtinerePagini(totalPagini);

        }

        private async void extragereConcedii(string? nume, string? prenume, int? idTipConcediu, int? idStareConcediu, int? nrInceputInregistrari, int? nrTotalDeAfisat,bool EsteAdmin, int idManager)
        {
            HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}Concediu/GetConcediiAngajatiFiltrati?nume={1}&prenume={2}&idTipConcediu={3}&idStareConcediu={4}&nrInceputInregistrari={5}&nrTotalInregistrariDeAdus={6}&EsteAdmin={7}&idManager={8}", Globals.apiUrl, nume, prenume, idTipConcediu, idStareConcediu, nrInceputInregistrari, nrTotalDeAfisat,EsteAdmin,idManager));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            listaConcedii = JsonConvert.DeserializeObject<List<Concediu>>(responseBody);


           populareDataGridView(listaConcedii);

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
            cbTipConcediu.SelectedItem = null;

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
                cbStareConcediu.SelectedItem = null;

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

                

                //if (bool.Parse(responseBody))
                //{

                //    extragereConcedii(null, null, null, null, 0, nrConcediiDeAfisare);
                //}
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
            if (cbTipConcediu.SelectedValue != null)
            {
                idTipConcediuSelectat = Convert.ToInt32(cbTipConcediu.SelectedValue);
            }
            else
            {
                idTipConcediuSelectat = null;
            }

            int? idStareConcediuSelectat;
            if (cbStareConcediu.SelectedValue != null)
            {
                idStareConcediuSelectat = Convert.ToInt32(cbStareConcediu.SelectedValue);
            }
            else
            {
                idStareConcediuSelectat = null;
            }
            extragereCountInregistrari(nume, prenume, idTipConcediuSelectat, idStareConcediuSelectat,(bool)angajat.EsteAdmin,angajat.Id);
            extragereConcedii(nume, prenume, idTipConcediuSelectat, idStareConcediuSelectat, 0, nrConcediiDeAfisare, (bool)angajat.EsteAdmin, angajat.Id);

        }

        private void btnInapoi_Click(object sender, EventArgs e)
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
            if (cbTipConcediu.SelectedValue != null)
            {
                idTipConcediuSelectat = Convert.ToInt32(cbTipConcediu.SelectedValue);
            }
            else
            {
                idTipConcediuSelectat = null;
            }

            int? idStareConcediuSelectat;
            if (cbStareConcediu.SelectedValue != null)
            {
                idStareConcediuSelectat = Convert.ToInt32(cbStareConcediu.SelectedValue);
            }
            else
            {
                idStareConcediuSelectat = null;
            }
            extragereCountInregistrari(nume, prenume, idTipConcediuSelectat, idStareConcediuSelectat,(bool)angajat.EsteAdmin,angajat.Id);
            extragereConcedii(nume, prenume, idTipConcediuSelectat, idStareConcediuSelectat, 0, nrConcediiDeAfisare, (bool)angajat.EsteAdmin, angajat.Id);
        }

       
    }

}
