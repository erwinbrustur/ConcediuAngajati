using ConcediuAngajati.PaginaPrincipala;
using ConcediuAngajati.Utils;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using ProiectASP.Models;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ConcediuAngajati
{
    public partial class PaginaMea : Form
    {
        Angajat angajat;
        string numeComplet;
        Angajat angajatSelectat;


        public PaginaMea(Angajat a, int? idAngajatSelectat)
        {
            InitializeComponent();

            angajat = a;
            extragereFunctieAsyncDB();
            if(idAngajatSelectat != null)
            {
                extragereAngajatSelectat(idAngajatSelectat);
            }
            else
            {
                populareControale(angajat);
            }

            if(idAngajatSelectat != null)
            {
                concediileMeleToolStripMenuItem.Visible = false;
                btnActualizareDate.Hide();
                tbNrTelefon.Enabled = false;
               
            }
            
        }

        private async void extragereAngajatSelectat(int? id)
        {
            HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}Angajat/GetAngajatById?id={1}", Globals.apiUrl, id));
            response.EnsureSuccessStatusCode();
            string responsivebody = await response.Content.ReadAsStringAsync();
            angajatSelectat = JsonConvert.DeserializeObject<Angajat>(responsivebody);

            populareControale(angajatSelectat);
        } 

        private void populareControale(Angajat a)
        {
            tbNume.Text = a.Nume;
            tbPrenume.Text = a.Prenume;
            tbEmail.Text = a.Email;

            DateTime dataNastere = Convert.ToDateTime(a.DataNasterii.ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
            string dataS = dataNastere.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            tbDataNastere.Text = dataS;
            tbCNP.Text = a.Cnp;
            tbSerie.Text = a.Serie;
            tbNumar.Text = a.No;

            if (a.Cnp.IndexOf('1') == 0 || a.Cnp.IndexOf('5') == 0)
            {
                tbGen.Text = "M";
            }
            else
            {
                tbGen.Text = "F";
            }

            tbNrTelefon.Text = a.NrTelefon;

            if(a.Functie != null)
            {
                tbFunctie.Text = a.Functie.Denumire;
            }
            if (a.Functie != null)
            {
                tbDepartament.Text = a.Departament.Denumire;
            }


            DateTime dataAngajare = Convert.ToDateTime(a.DataAngajare.ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
            dataS = dataAngajare.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            tbDataAngajare.Text = dataS;

            MemoryStream ms = new MemoryStream(a.Poza);
            pbImagineProfil.Image = Image.FromStream(ms);


        }

        private async void extragereFunctieAsyncDB()
        {
            //MessageBox.Show(angajat.DepartamentId.ToString());
            if (angajat.FunctieId != null && angajat.DepartamentId != null)
            {
                try
                {

                    HttpResponseMessage response = await Globals.client.GetAsync(String.Format("{0}DepartamentSiFunctie/GetFunctieDepartament?angajatId={1}", Globals.apiUrl, angajat.Id));
                    response.EnsureSuccessStatusCode();
                    string responsivebody = await response.Content.ReadAsStringAsync();

                    List<Angajat> angajatul = JsonConvert.DeserializeObject<List<Angajat>>(responsivebody);
                    
                    foreach (Angajat a in angajatul)
                    {
                        tbDepartament.Text = a.Departament.Denumire;
                        tbFunctie.Text = a.Functie.Denumire;
                    }


                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void meniuToolStripMenuItemAcasa_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void concediileMeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IstoricConcedii iconcediu = new IstoricConcedii(angajat);
            iconcediu.Show();
            this.Close();
        }

        private void ActualizeazaDate(object sender, EventArgs e)
        {
               
            string nrTel = tbNrTelefon.Text;

            MemoryStream ms = new MemoryStream();
            pbImagineProfil.Image.Save(ms, ImageFormat.Jpeg);
            byte[] image_array = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(image_array, 0, image_array.Length);

            angajat.Poza = image_array;
            angajat.NrTelefon = nrTel;
            if (tbNrTelefon.Text.Length == 10)
            {

                try
                {
                    string message = "Sigur vrei sa iti actualizezi datele?";
                    string message2 = "Datele au fost actualizate";
                    string title = "Actualizare date";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {

                        string jsonString = JsonConvert.SerializeObject(angajat);
                        StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                        var response = Globals.client.PutAsync(String.Format("{0}Angajat/UpdateDateleMele", Globals.apiUrl), stringContent).Result;
                        MessageBox.Show(message2, title);
                    }
                    else
                    {
                        MessageBox.Show("hehe");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                errorProvider1.SetError(tbNrTelefon, "Numar de telefon invalid! Numarul de telefon trebuie sa contina 10 cifre!");
                MessageBox.Show("Numarul nu are 10 cifre");
            }
        }

        private void pbImagineProfil_Click(object sender, EventArgs e)
        {
            if(angajatSelectat == null)
            {
                string message = "Doriti sa modificati imaginea de profil?";
                string title = "Close Window";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.Yes)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.PNG, *.JPEG)| *.BMP; *.JPG; *.PNG, *.JPEG | All files(*.*) | *.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pbImagineProfil.Image = new Bitmap(openFileDialog.FileName);
                    }
                }
            }
           
        }

        private void tbNrTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbNrTelefon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string serie = ((TextBox)sender).Text;
            if (serie.Length != 10)
            {
                errorProvider1.SetError(tbNrTelefon, "Numar de telefon invalid! Numarul de telefon trebuie sa contina 10 cifre!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}