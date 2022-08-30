using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcediuAngajati
{
    public partial class FormInregistrareIntermediar : Form
    {
        public string connectionString;
        public FormInregistrareIntermediar()
        {
            InitializeComponent();
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdaugaPoza_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.PNG) | *.PNG";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbImagineProfil.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void tbCNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbNumar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbCNP_Validating(object sender, CancelEventArgs e)
        {
            string cnp = ((TextBox)sender).Text;
            if(cnp.Length != 13)
            {
                errorProvider1.SetError(tbCNP, "CNP invalid! CNP-ul trebuie sa contina 13 cifre!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void tbSerie_Validating(object sender, CancelEventArgs e)
        {
            string serie = ((TextBox)sender).Text;
            if (serie.Length != 2)
            {
                errorProvider1.SetError(tbSerie, "Serie invalida! Seria trebuie sa contina 2 caractere!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void tbNumar_Validating(object sender, CancelEventArgs e)
        {
            string serie = ((TextBox)sender).Text;
            if (serie.Length != 6)
            {
                errorProvider1.SetError(tbNumar, "Numar invalid! Numarul trebuie sa contina 6 cifre!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void btnInregistrare_Click(object sender, EventArgs e)
        {
            string cnp = tbCNP.Text;
            string numar = tbNumar.Text;
            string serie = tbSerie.Text;
            string dataNastere;

            if (cnp.IndexOf('1') == 0 || cnp.IndexOf('2') == 0) {
                dataNastere = "19" + cnp.Substring(1, 6);
            }
            else
            {
                dataNastere = "20" + cnp.Substring(1, 6);
            } 
            
           

            SqlConnection conexiune = new SqlConnection(connectionString);
            string insertSQL = "INSERT INTO Angajat(nume, prenume, email, parola, dataAngajare, dataNasterii, cnp, serie, no, nrTelefon) VALUES ('Dorel', 'Popescu', 'popescu.dorel@totalsoft.ro', 'ddoru34', getdate(), +" + dataNastere + ", '" + cnp + "', '" +  serie + "', '" + numar + "', '0767896595')" ;
            SqlCommand queryInsert = new SqlCommand(insertSQL);
            try
            {
                conexiune.Open();
                queryInsert.Connection = conexiune;
                queryInsert.ExecuteNonQuery();


                MessageBox.Show("Inserare realizata cu succes!");
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
}