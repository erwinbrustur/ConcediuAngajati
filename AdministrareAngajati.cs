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
using Microsoft.VisualBasic;

namespace ConcediuAngajati
{
    public partial class AdministrareAngajati : Form
    {
        int idManager;
        int idManager2;
        int idAngajat;
        string cnx;
        List<string> managerActualMutare = new List<string>();
        List<string> angajatMutare = new List<string>();
        List<string> managerNouMutare = new List<string>();
        public AdministrareAngajati()
        {
            InitializeComponent();
            this.panelAdaugareAngajat.BackColor = Color.FromArgb(99, 127, 124, 127);
            this.panelModificareManageri.BackColor = Color.FromArgb(99, 127, 124, 127);
            cnx = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";

            string moveGetActualManager = "select id,nume,prenume from Angajat where managerId=26 and esteAdmin=0";
            managerActualMutare = datePersoana(moveGetActualManager, cnx);
            comboBox1.Items.Clear();
            foreach (string s in managerActualMutare)
            {
                comboBox1.Items.Add(s.Substring(3));
            }



        }
        public List<string> datePersoana(string CmdLine, string conex)
        {
            List<string> date = new List<string>();
            SqlConnection cnx = new SqlConnection(conex);
            cnx.Open();
            SqlCommand cmd = new SqlCommand(CmdLine, cnx);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                date.Add(reader[0].ToString() + ", " + reader[1].ToString() + " " + reader[2].ToString());
            }
            cnx.Close();
            return date;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string numeManager = comboBox1.Text;
       
            foreach (string s in managerActualMutare)
            {
                
                if (numeManager == s.Substring(3))
                {
                    idManager = Convert.ToInt32(s.Substring(0, 2));
                }



            }
            string moveGetEmployee = "select id,nume,prenume from Angajat where managerId=" + idManager + "and managerId!=id";
            angajatMutare = datePersoana(moveGetEmployee, cnx);
            comboBox2.Items.Clear();
            foreach (string p in angajatMutare)
            {
                comboBox2.Items.Add(p.Substring(3));

            }
           
            comboBox3.Items.Clear();
            foreach (string s in managerActualMutare)
            {
                if (comboBox1.Text != s.Substring(3))
                    comboBox3.Items.Add(s.Substring(3));

            }
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string transfercmd = "update Angajat set managerId=" + idManager2 + " where id=" + idAngajat;
        
            SqlConnection con = new SqlConnection(cnx);
            con.Open();
            SqlCommand transfer = new SqlCommand(transfercmd, con);
            transfer.ExecuteNonQuery();

            con.Close();
            MessageBox.Show(comboBox2.Text+" a fost transferat in echipa lui "+comboBox3.Text+"!");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


            string numeAngajat = comboBox2.Text;

            foreach (string s in angajatMutare)
            {

                if (numeAngajat == s.Substring(3))
                {
                    idAngajat = Convert.ToInt32(s.Substring(0, 2));

                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            foreach (string s in managerActualMutare)
            {
               
                if (comboBox3.Text == s.Substring(3))
                    idManager2 = Convert.ToInt32(s.Substring(0, 2));
            }
        }
    }
}
