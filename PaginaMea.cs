using ConcediuAngajati.PaginaPrincipala;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;

namespace ConcediuAngajati
{
    public partial class PaginaMea : Form
    {
        Angajat angajat;
        string connectionString;
        string numeComplet;
        bool isReadOnly = true;
        public PaginaMea(Angajat a)
        {
            InitializeComponent();
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";

            angajat = a;
            extractFunctieDepartament();
            pupulareControale(angajat);
        }

        private void pupulareControale(Angajat a)
        {
            tbNume.Text = a.Nume;
            tbPrenume.Text = a.Prenume;
            tbEmail.Text = a.Email;

            DateTime dataNastere = Convert.ToDateTime(a.DataNastarii.ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
            string dataS = dataNastere.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            tbDataNastere.Text = dataS;
            tbCNP.Text = a.CNP;
            tbSerie.Text = a.Serie;
            tbNumar.Text = a.Numar;

            if (a.CNP.IndexOf('1') == 0 || a.CNP.IndexOf('5') == 0)
            {
                tbGen.Text = "M";
            }
            else
            {
                tbGen.Text = "F";
            }

            tbNrTelefon.Text = a.NrTelefon;
            string[] tokens = numeComplet.Split(',');
            tbFunctie.Text = tokens[1];
            tbDepartament.Text = tokens[0];

            DateTime dataAngajare = Convert.ToDateTime(a.DataAngajare.ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
            dataS = dataAngajare.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            tbDataAngajare.Text = dataS;
            byte[] image_array = a.Poza;

            MemoryStream ms = new MemoryStream(a.Poza);
            pbImagineProfil.Image = Image.FromStream(ms);


        }

        private void extractFunctieDepartament()
        {
            string selectSQL = "SELECT d.Denumire AS Departament, f.Denumire AS Functie, a.departamentId, a.functieId FROM Angajat a JOIN Departament d ON d.id = a.departamentId JOIN Functie f ON f.id = a.functieId WHERE a.id = " + angajat.Id;
            SqlConnection conexiune = new SqlConnection(connectionString);
            SqlCommand querySelect = new SqlCommand(selectSQL);
            try
            {
                conexiune.Open();
                querySelect.Connection = conexiune;
                SqlDataReader reader = querySelect.ExecuteReader();

                while (reader.Read())
                {
                    numeComplet = reader[0].ToString() + "," + reader[1].ToString();
                    angajat.DepartamentId = Convert.ToInt32(reader[2]);
                    angajat.FunctieId = Convert.ToInt32(reader[3]);
                }
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


        private void btnX_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void meniuToolStripMenuItemAcasa_Click(object sender, EventArgs e)
        {
            PaginaPrincipala.PaginaPrincipala pagprin = new PaginaPrincipala.PaginaPrincipala(angajat);
            pagprin.ShowDialog();
        }

        private void concediileMeleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizareDate_Click(object sender, EventArgs e)
        {
            if (!isReadOnly && btnActualizareDate.Text.Equals("Actualizeaza")){
                string nrTel = tbNrTelefon.Text;

                MemoryStream ms = new MemoryStream();
                pbImagineProfil.Image.Save(ms, ImageFormat.Jpeg);
                byte[] image_array = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(image_array, 0, image_array.Length);

                SqlConnection conexiune = new SqlConnection(connectionString);

                MessageBox.Show(nrTel + " " + image_array);

                string updateSQL = "UPDATE Angajat SET nrTelefon = '" + nrTel + "', poza = @poza WHERE id = " + angajat.Id;

                SqlCommand queryUpdate = new SqlCommand(updateSQL, conexiune);
                try
                {
                    conexiune.Open();
                    queryUpdate.Parameters.Add("@poza", SqlDbType.VarBinary).Value = image_array;
                    queryUpdate.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexiune.Close();
                    MessageBox.Show("Actualizare realizata cu succes!");
                    btnActualizareDate.Text = "Actualizare date";
                    tbNrTelefon.ReadOnly = true;
                    isReadOnly = true;
                }
            }
            else
            {
                tbNrTelefon.ReadOnly = false;
                isReadOnly = false;
                btnActualizareDate.Text = "Actualizeaza";
            }

            //btnActualizareDate.Visible = false;

        }

        private void pbImagineProfil_Click(object sender, EventArgs e)
        {
            if (isReadOnly)
            {
                return;
            }
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
    }
}