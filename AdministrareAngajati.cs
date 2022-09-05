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
        int idManagerEN;
        int idManagerSE;
        int idAngajatConcediat;
        int concedManagId;
        string cnx;
        Angajat angajatCurent;
        List<string> managerActualMutare = new List<string>();
        List<string> angajatMutare = new List<string>();
        List<string> managerNouMutare = new List<string>();
        List<string> viitorManager = new List<string>();
        List<String> angajatiiManagerului = new List<string>();
        public AdministrareAngajati(Angajat a)
        {
            InitializeComponent();
            this.panelAdaugareAngajat.BackColor = Color.FromArgb(99, 127, 124, 127);
            this.panelModificareManageri.BackColor = Color.FromArgb(99, 127, 124, 127);
            this.panelConcediere.BackColor = Color.FromArgb(99, 127, 124, 127);
            cnx = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";
            angajatCurent = a;
            string moveGetActualManager = "select id,nume,prenume from Angajat where managerId=26 and esteAdmin=0";
            managerActualMutare = datePersoana(moveGetActualManager, cnx);
            comboBox1.Items.Clear();
            panelAdaugareAngajat.Hide();
            panelConcediere.Hide();
            panelModificareManageri.Hide();
            buttonModificareManageri.Hide();
            concediereManager.Hide();
            Stergere.Hide();
            label20.Hide();
            if (!angajatCurent.EsteAdmin)
            {
                concedManagId = angajatCurent.Id;
                string concedGetEmployee = "select id,nume,prenume from Angajat where managerId=" + concedManagId + "and managerId!=id";
                SqlConnection con = new SqlConnection(cnx);
                con.Open();
                angajatiiManagerului = datePersoana(concedGetEmployee, cnx);
                con.Close();
                angajatConcediat.Items.Clear();
                foreach (string p in angajatiiManagerului)
                {
                    angajatConcediat.Items.Add(p.Substring(p.IndexOf(',') + 1));
                }
            }

            if (angajatCurent.EsteAdmin)
            {
                buttonModificareManageri.Show();
                concediereManager.Show();
                Stergere.Show();
                groupBox3.Show();
            }
            foreach (string s in managerActualMutare)
            {
                comboBox1.Items.Add(s.Substring(s.IndexOf(',')+1));
                comboBox4.Items.Add(s.Substring(s.IndexOf(',')+1));
                comboBox6.Items.Add(s.Substring(s.IndexOf(',')+1));
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

            if (panelAdaugareAngajat.Visible == true) { 
                panelAdaugareAngajat.Hide();
            }

            else
            {
                panelAdaugareAngajat.Show();
                panelModificareManageri.Hide();
                panelConcediere.Hide();
            }
             

        }

        private void buttonModificareManageri_Click(object sender, EventArgs e)
        {
            if (panelModificareManageri.Visible == true)
            {
                panelModificareManageri.Hide();
            }

            else
            {
                panelModificareManageri.Show();
                panelAdaugareAngajat.Hide();
                panelConcediere.Hide();
            }
             
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
            String Commandline1 = "Insert into Angajat(nume,prenume,email,parola,dataAngajare,dataNasterii,cnp,serie,no,nrTelefon,poza,managerId)";
            String Commandline2 = " values ('" + Nume.Text + "','" + Prenume.Text + "','" + Email.Text + "@totalsoft.ro','" + Hash(Parola.Text)
                + "',getDate(),'" + dataNastere + "','" + CNP.Text + "','" + Serie.Text + "','" + Nr.Text + "','" + NrTel.Text + "',@poza,30)";
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

            if (angajatCurent.EsteAdmin)
            {

                foreach (string s in managerActualMutare)
                {

                    if (numeManager == s.Substring(s.IndexOf(',') + 1))
                    {
                        idManager = Convert.ToInt32(s.Substring(0, s.IndexOf(',')));
                    }


                }
            }
            else
            {
                idManager = angajatCurent.Id;
            }
            string moveGetEmployee = "select id,nume,prenume from Angajat where managerId=" + idManager + "and managerId!=id";
            angajatMutare = datePersoana(moveGetEmployee, cnx);
            comboBox2.Items.Clear();
            foreach (string p in angajatMutare)
            {
                comboBox2.Items.Add(p.Substring(p.IndexOf(',') + 1));

            }
           
            comboBox3.Items.Clear();
            foreach (string s in managerActualMutare)
            {
                if (comboBox1.Text != s.Substring(s.IndexOf(',')+1))
                    comboBox3.Items.Add(s.IndexOf(',') + 1);

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

                if (numeAngajat == s.Substring(s.IndexOf(',') + 1))
                {
                    idAngajat = Convert.ToInt32(s.Substring(0, s.IndexOf(',') ));

                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            foreach (string s in managerActualMutare)
            {
               
                if (comboBox3.Text == s.Substring(s.IndexOf(',')+1))
                    idManager2 = Convert.ToInt32(s.Substring(0, s.IndexOf(',')));
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numeManagerEN=comboBox4.Text;
            foreach(string s in managerActualMutare)
            {
                if (numeManagerEN == s.Substring(s.IndexOf(',')))
                {
                    idManagerEN = Convert.ToInt32(s.Substring(0, s.IndexOf(',')));
                }
                string moveGetEmployee = "select id,nume,prenume from Angajat where managerId=" + idManagerEN + "and managerId!=id";
                viitorManager = datePersoana(moveGetEmployee, cnx);
                comboBox5.Items.Clear();
                foreach (string p in viitorManager)
                {
                    comboBox5.Items.Add(p.Substring(s.IndexOf(',') + 1));

                }
            }
        }

        private void panelModificareManageri_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numeManagerSE = comboBox6.Text;
      
            foreach (string s in managerActualMutare)
            {
                
                if (numeManagerSE == s.Substring(s.IndexOf(',') + 1))
                {
                    idManagerSE = Convert.ToInt32(s.Substring(0, s.IndexOf(',')));
                
                }
            }
        }

        private void BtnStergere_Click(object sender, EventArgs e)
        {

            string stergerecmd = "update Angajat set managerId=30 where managerId=" + idManagerSE;
            string stergerecmd2 = "update Angajat set managerId=30 where id=" + idManagerSE;


            SqlConnection con = new SqlConnection(cnx);
            con.Open();
            SqlCommand stergere = new SqlCommand(stergerecmd, con);
            SqlCommand stergere2 = new SqlCommand(stergerecmd2, con);
            stergere.ExecuteNonQuery();
            stergere2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Echipa lui " + comboBox6.Text + " a fost stearsa!");
        }

        private void BtnEchipaNoua_Click(object sender, EventArgs e)
        {
            int idVManager=0; 
            foreach (string p in viitorManager)
            {
                if (comboBox5.Text == p.Substring(p.IndexOf(',') + 1))
                {
                    idVManager = Convert.ToInt32(p.Substring(0, p.IndexOf(',') ));
                }
            }
            string echipaNoua = "update Angajat set managerId=" + 26 + " where id=" + idVManager;

            SqlConnection con = new SqlConnection(cnx);
            con.Open();
            SqlCommand cmden = new SqlCommand(echipaNoua, con);
            cmden.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Ati creat o noua echipa manageriata de "+comboBox5.Text+"!");
        }

        private void btnConcedPanel_Click(object sender, EventArgs e)
        {
            if(panelConcediere.Visible)
            {
                panelConcediere.Hide();
            }
            else
            {
                panelConcediere.Show();
                panelAdaugareAngajat.Hide();
                panelModificareManageri.Hide();
            }
            SqlConnection con = new SqlConnection(cnx);
          foreach(string p in managerActualMutare)
            {
                concediereManager.Items.Add(p.Substring(p.IndexOf(',')+1));
            }
        }

        private void concediereManager_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
                foreach (string p in managerActualMutare)
                {
                    if (p.Substring(p.IndexOf(',') + 1) == concediereManager.Text)
                        concedManagId = Convert.ToInt32(p.Substring(0, p.IndexOf(',')));
                }

                string concedGetEmployee = "select id,nume,prenume from Angajat where managerId=" + concedManagId + "and managerId!=id";
                SqlConnection con = new SqlConnection(cnx);
                con.Open();
                angajatiiManagerului = datePersoana(concedGetEmployee, cnx);
                con.Close();
                angajatConcediat.Items.Clear();
                foreach (string p in angajatiiManagerului)
                {
                    angajatConcediat.Items.Add(p.Substring(p.IndexOf(',') + 1));
                }
            
           
        }
        private void btnConcediereAngajat_Click(object sender, EventArgs e)
        {
            foreach (string p in angajatiiManagerului)
            {
                if (p.Substring(p.IndexOf(',') + 1) == angajatConcediat.Text)
                {

                    idAngajatConcediat = Convert.ToInt32(p.Substring(0, p.IndexOf(',')));
                }

            }
            MessageBox.Show(angajatConcediat.Text);
            SqlConnection con = new SqlConnection(cnx);
            con.Open();
            SqlCommand concediaza = new SqlCommand("Delete from Angajat where id=" + idAngajatConcediat.ToString(), con);
            concediaza.ExecuteNonQuery();
            MessageBox.Show("Angajat concediat");
        }

        private void Stergere_Enter(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void BtnPaginaPrincipala_Click(object sender, EventArgs e)
        {
       
            this.Hide();

        }
    }
}
