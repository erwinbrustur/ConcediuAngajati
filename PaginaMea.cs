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
        static readonly HttpClient client = new HttpClient();
        Angajat angajat;
        string connectionString;
        string numeComplet;
        
        public PaginaMea(Angajat a)
        {
            InitializeComponent();
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";

            angajat = a;
            extragereFunctieAsyncDB();
            pupulareControale(angajat);
        }

        private void pupulareControale(Angajat a)
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
            //  string[] tokens = numeComplet.Split(',');
            //tbFunctie.Text = a.Functie.Denumire;
            //tbDepartament.Text = a.Departament.Denumire;

            DateTime dataAngajare = Convert.ToDateTime(a.DataAngajare.ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
            dataS = dataAngajare.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            tbDataAngajare.Text = dataS;
            byte[] image_array = a.Poza;

            MemoryStream ms = new MemoryStream(a.Poza);
            pbImagineProfil.Image = Image.FromStream(ms);


        }

        //private void extractFunctieDepartament()
        //{
        //    string selectSQL = "SELECT d.Denumire AS Departament, f.Denumire AS Functie, a.departamentId, a.functieId FROM Angajat a JOIN Departament d ON d.id = a.departamentId JOIN Functie f ON f.id = a.functieId WHERE a.id = " + angajat.Id;
        //    SqlConnection conexiune = new SqlConnection(connectionString);
        //    SqlCommand querySelect = new SqlCommand(selectSQL);
        //    try
        //    {
        //        conexiune.Open();
        //        querySelect.Connection = conexiune;
        //        SqlDataReader reader = querySelect.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            numeComplet = reader[0].ToString() + "," + reader[1].ToString();
        //            angajat.DepartamentId = Convert.ToInt32(reader[2]);
        //            angajat.FunctieId = Convert.ToInt32(reader[3]);
        //        }
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

        private async void extragereFunctieAsyncDB()
        {
            try
            {

                HttpResponseMessage response = await client.GetAsync(String.Format("{0}DepartamentSiFunctie/GetFunctieDepartament?angajatId={1}", Globals.apiUrl, angajat.Id));
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

        private void btnX_Click(object sender, EventArgs e)
        {
            PaginaPrincipala.PaginaPrincipala ang = new PaginaPrincipala.PaginaPrincipala(angajat);
            ang.Show();
            this.Close();
        }

        private void meniuToolStripMenuItemAcasa_Click(object sender, EventArgs e)
        {
            PaginaPrincipala.PaginaPrincipala pagprin = new PaginaPrincipala.PaginaPrincipala(angajat);
            pagprin.Show();
            this.Close();
        }

        private void concediileMeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IstoricConcedii iconcediu = new IstoricConcedii(angajat);
            iconcediu.Show();
            this.Close();
        }

        //private void btnActualizareDate_Click(object sender, EventArgs e)
        //{
        //    if (!isReadOnly && btnActualizareDate.Text.Equals("Actualizeaza")){
        //        string nrTel = tbNrTelefon.Text;

        //        MemoryStream ms = new MemoryStream();
        //        pbImagineProfil.Image.Save(ms, ImageFormat.Jpeg);
        //        byte[] image_array = new byte[ms.Length];
        //        ms.Position = 0;
        //        ms.Read(image_array, 0, image_array.Length);

        //        SqlConnection conexiune = new SqlConnection(connectionString);
        //        string updateSQL = "UPDATE Angajat SET nrTelefon = '" + nrTel + "', poza = @poza WHERE id = " + angajat.Id;

        //        SqlCommand queryUpdate = new SqlCommand(updateSQL, conexiune);
        //        try
        //        {
        //            conexiune.Open();
        //            queryUpdate.Parameters.Add("@poza", SqlDbType.VarBinary).Value = image_array;
        //            queryUpdate.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //        finally
        //        {
        //            conexiune.Close();
        //            MessageBox.Show("Actualizare realizata cu succes!");
        //            btnActualizareDate.Text = "Actualizare date";
        //            tbNrTelefon.ReadOnly = true;
        //            isReadOnly = true;
        //        }
        //    }
        //    else
        //    {
        //        tbNrTelefon.ReadOnly = false;
        //        isReadOnly = false;
        //        btnActualizareDate.Text = "Actualizeaza";
        //    }

        //}

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
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
            
            
        }

        private void pbImagineProfil_Click(object sender, EventArgs e)
        {
            
            string message = "Doriti sa modificati imaginea de profil?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            
            if(result == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.PNG, *.JPEG)| *.BMP; *.JPG; *.PNG, *.JPEG | All files(*.*) | *.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbImagineProfil.Image = new Bitmap(openFileDialog.FileName);
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