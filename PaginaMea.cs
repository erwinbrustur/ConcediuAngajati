using ConcediuAngajati.PaginaPrincipala;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace ConcediuAngajati
{
    public partial class PaginaMea : Form
    {
        Angajat angajat;
        string connectionString;
        string numeComplet;
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
            DateTime dt = DateTime.ParseExact(a.DataNastarii.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            string s = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
            tbDataNastere.Text = s;
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

            dt = DateTime.ParseExact(a.DataNastarii.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            s = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);

            tbDataAngajare.Text = a.DataAngajare.ToString();
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
                    numeComplet =  reader[0].ToString() + "," + reader[1].ToString();
                    MessageBox.Show(numeComplet);
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
    }
}