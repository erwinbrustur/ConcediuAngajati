using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Drawing.Imaging;

namespace ConcediuAngajati
{
    public partial class AdministrareAngajati : Form
    {
       
        public AdministrareAngajati()
        {
            InitializeComponent();
            this.panelAdaugareAngajat.BackColor = Color.FromArgb(99, 127, 124, 127);

           
        }

        public static string Hash(string Value)
        {
            using var hash = SHA256.Create();
            var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(Value));
            return Convert.ToHexString(byteArray);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (panelAdaugareAngajat.Visible == true)
                panelAdaugareAngajat.Hide();
            else
                panelAdaugareAngajat.Show();   
  
        }

        private void buttonModificareManageri_Click(object sender, EventArgs e)
        {
            if (panelModificareManageri.Visible == true)
                panelModificareManageri.Hide();
            else
                panelModificareManageri.Show();
        }

        private void panelAdaugareAngajat_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdministrareAngajati_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Poza.Image = new Bitmap(openFileDialog.FileName);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string dataNastere;
            if (CNP.Text.IndexOf('1') == 0 || CNP.Text.IndexOf('2') == 0)
            {
                dataNastere = "19" + CNP.Text.Substring(1, 6);
            }
            else
            {
                dataNastere = "20" + CNP.Text.Substring(1, 6);
            }
            SqlConnection cnx = new SqlConnection(@"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int");
            cnx.Open();
            String Commandline1 = "Insert into Angajat(nume,prenume,email,parola,dataAngajare,dataNasterii,cnp,serie,no,nrTelefon,poza)";
            String Commandline2 = " values ('" + Nume.Text + "','" + Prenume.Text + "','" + Email.Text + "@totalsoft.ro','" + Hash(Parola.Text)
                + "',getDate(),'" + dataNastere + "','" + CNP.Text + "','" + Serie.Text + "','" + Nr.Text + "','" + NrTel.Text + "',@poza)";
            MemoryStream ms = new MemoryStream();
            Poza.Image.Save(ms, ImageFormat.Jpeg);
            byte[] image_array = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(image_array, 0, image_array.Length);
            SqlCommand queryInsert = new SqlCommand(Commandline1 + Commandline2, cnx);
            queryInsert.Parameters.Add("@poza", SqlDbType.VarBinary).Value = image_array;

            queryInsert.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("Angajat adaugat");
            Nume.Text = "";
            Prenume.Text = "";
            Email.Text = "";
            Parola.Text = "";
            CNP.Text = "";
            Serie.Text = "";
            Nr.Text = "";
            NrTel.Text = "";
            Poza.Image.Dispose();


        }

    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Prenume_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblPrenume_Click(object sender, EventArgs e)
        {

        }
    }
}
