using ConcediuAngajati.Utils;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using ProiectASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcediuAngajati
{
    public partial class FormInregistrareIntermediar : Form
    {
        Angajat angajat;
        public FormInregistrareIntermediar(Angajat a)
        {
            InitializeComponent();
            angajat = a;

            pbImagineProfil.BackColor = Color.FromArgb(86, 127, 124, 127);
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            LoginPhase login = new LoginPhase();
            login.Show();
            this.Close(); 
        }

        private void btnAdaugaPoza_Click(object sender, EventArgs e)
        {
            Inregistrare inr = new Inregistrare();
            inr.Show();
            this.Close();
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
            var strRegex = "^[1256]\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])(0[1-9]|[1-4]\\d|5[0-2]|99)(00[1-9]|0[1-9]\\d|[1-9]\\d\\d)\\d$";
            Regex regex = new Regex(strRegex);
            if (!regex.IsMatch(cnp))
            {
                errorProvider1.SetError(tbCNP, "CNP invalid!");
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

        private  void btnInregistrare_Click(object sender, EventArgs e)
        {
            string cnp = tbCNP.Text;
            string numar = tbNumar.Text;
            string serie = tbSerie.Text;
            string dataNastere;

            MemoryStream ms = new MemoryStream();
            pbImagineProfil.Image.Save(ms, ImageFormat.Jpeg);
            byte[] image_array = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(image_array, 0, image_array.Length);

            

            if (cnp.IndexOf('1') == 0 || cnp.IndexOf('2') == 0) {
                dataNastere = "19" + cnp.Substring(1, 6);
            }
            else
            {
                dataNastere = "20" + cnp.Substring(1, 6);
            }


            Angajat angaj = new Angajat();
            angaj.DataAngajare = DateTime.Now;
            angaj.Nume = angajat.Nume;
            angaj.Prenume = angajat.Prenume;
            angaj.Cnp = cnp;
            angaj.Serie = serie.ToUpper();
            angaj.No = numar;
            angaj.Email = angajat.Email;
            angaj.Parola = angajat.Parola;
            angaj.NrTelefon = angajat.NrTelefon;
            angaj.ManagerId = 1;
            //angaj.DepartamentId = 7 ;
            //angaj.FunctieId = 5;
            angaj.concediat = false;
            angaj.Poza = image_array;
            angaj.EsteAdmin = false;
           
            
            string dataNormala = (dataNastere.Substring(4, 2) + "/" +dataNastere.Substring(6, 2) + "/" + dataNastere.Substring(0, 4));
            angaj.DataNasterii = Convert.ToDateTime(dataNormala);


            string jsonString = JsonConvert.SerializeObject(angaj);
            StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            string linkF = String.Format("{0}Orice/PutNewAngajat", Globals.apiUrl);
            var response = Globals.client.PutAsync(linkF, stringContent).Result;

            MessageBox.Show("Inregistrare realizata cu succes!");
            this.Close();
            LoginPhase lg = new LoginPhase();
            lg.Show();
        }

        private void btnInapoi_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbImagineProfil_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.PNG, *.JPEG)| *.BMP; *.JPG; *.PNG, *.JPEG | All files(*.*) | *.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbImagineProfil.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}