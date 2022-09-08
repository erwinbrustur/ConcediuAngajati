﻿using System;
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
using ProiectASP.Models;
using Newtonsoft.Json;
using Google.Protobuf.WellKnownTypes;

namespace ConcediuAngajati
{
    public partial class AdministrareAngajati : Form
    {
        static readonly HttpClient client = new HttpClient();
        int idManager;
        int idManager2;
        int idAngajat;
        int idManagerEN;
        int idManagerSE;
        int idAngajatConcediat;
        int concedManagId;
        int idManagerDepartament;
        int idManagerFunctie;
        int idManagerFunct;
        int idDepartament;
        int idFunctie;
        int idAngajatDepartament;
        int idAngajatFunctie;
        string numeManager;
        string cnx;
        Angajat angajatCurent;
        List<Angajat> moveGetEmployee = new List<Angajat>();
        List<Angajat> managerActualMutare = new List<Angajat>();
        List<Angajat> angajatMutare = new List<Angajat>();
        List<Angajat> managerNouMutare = new List<Angajat>();
        List<Angajat> viitorManager = new List<Angajat>();
        List<Angajat> angajatiiManagerului = new List<Angajat>();
        public List<Functie> GetFunctie()
        {
            List<Functie> Functii = new List<Functie>();
            GetFuncts();

            async Task GetFuncts()
            {

                HttpResponseMessage response =  client.GetAsync("http://localhost:5096/GetAllFuncties").Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                Functii = JsonConvert.DeserializeObject<List<Functie>>(responseBody);

            }
       
     
          
            return Functii;
        }
        public List<Departament> GetDepartaments()
        {
            List<Departament> departaments = new List<Departament>();
            GetDeparts();
         
            async Task GetDeparts()
            {
                HttpResponseMessage response =client.GetAsync("http://localhost:5096/GetAllDepartaments").Result;
                 response.EnsureSuccessStatusCode();
                string responseBody =response.Content.ReadAsStringAsync().Result;
               departaments = JsonConvert.DeserializeObject<List<Departament>>(responseBody);
                
            }


          
            return departaments;
        }


          public  List<Angajat> GetManagerEmployee(int idManager)
            {
                HttpResponseMessage response = client.GetAsync(" http://localhost:5096/GetManagersAngajat?idManag=" + idManager).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                List<Angajat> ManagersEmployees = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);
            return ManagersEmployees;

            }

        
        List<Angajat> EmployeesExtraction()
        {
            HttpResponseMessage response = client.GetAsync("http://localhost:5096/GetAllManagers").Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;
            List<Angajat> managerActualMutare = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);


            return managerActualMutare;
        }
        public AdministrareAngajati(Angajat a)
        {

            InitializeComponent();
            this.panelAdaugareAngajat.BackColor = Color.FromArgb(99, 127, 124, 127);
            this.panelModificareManageri.BackColor = Color.FromArgb(99, 127, 124, 127);
            this.panelConcediere.BackColor = Color.FromArgb(99, 127, 124, 127);
          
            angajatCurent = a;
            ExtragereAngajati();
            managerActualMutare=EmployeesExtraction();
         

            panelAdaugareAngajat.Hide();
            panelConcediere.Hide();
            panelModificareManageri.Hide();
            buttonModificareManageri.Hide();
            concediereManager.Hide();
            Stergere.Hide();
            label20.Hide();
            if ((bool)!angajatCurent.EsteAdmin)
            {
                concedManagId = angajatCurent.Id;


                angajatiiManagerului=GetManagerEmployee(concedManagId);
                angajatConcediat.Items.Clear();
                foreach (Angajat p in angajatiiManagerului)
                {
                   
                    angajatConcediat.Items.Add(p.Nume+' '+p.Prenume);
                }
           }
            if ((bool)angajatCurent.EsteAdmin)
            {
                buttonModificareManageri.Show();
                concediereManager.Show();
                Stergere.Show();
                groupBox3.Show();
            }
           List<Angajat> ExtragereListaAngajati()
            {
               
                List<Angajat> tempAngajatii = new List<Angajat>();
                EmployeesExtraction();
                async Task EmployeesExtraction()
                {
                    HttpResponseMessage response = await client.GetAsync("http://localhost:5096/GetAllManagers");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Angajat> managerActualMutare = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);
                    tempAngajatii = managerActualMutare;
                  
               
                }
                
             
                return tempAngajatii;
            
            }
           
            async Task ExtragereAngajati() {
                HttpResponseMessage response = await client.GetAsync("http://localhost:5096/GetAllManagers");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Angajat> managerActualMutare = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);
            
                foreach (Angajat x in managerActualMutare)
                {

                    comboBox1.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                    comboBox4.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                    comboBox6.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                    DepartamentManager.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                    FunctieManager.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                }
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
            {
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
            
            if ((bool)angajatCurent.EsteAdmin)
            {
                
                foreach (Angajat s in managerActualMutare)
                {
               
                    if (numeManager == s.Nume+' '+s.Prenume)
                    {
                     
                        idManager = s.Id;
                    }


                }
            }
            else
            {
                idManager = angajatCurent.Id;
                
            }
           
            angajatMutare = GetManagerEmployee(idManager);
        
            foreach (Angajat p in angajatMutare)
            {
                comboBox2.Items.Add(p.Nume+' '+p.Prenume);

            }

            comboBox3.Items.Clear();
            foreach ( Angajat s in managerActualMutare)
            {
                if (comboBox1.Text != s.Nume+' '+s.Prenume)
                    comboBox3.Items.Add(s.Nume+' '+s.Prenume);

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
            MessageBox.Show(comboBox2.Text + " a fost transferat in echipa lui " + comboBox3.Text + "!");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


            string numeAngajat = comboBox2.Text;

            foreach (Angajat s in angajatMutare)
            {

                if (numeAngajat == s.Nume+' '+s.Prenume)
                {
                    idAngajat = s.Id;

                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (Angajat s in managerActualMutare)
            {

                if (comboBox3.Text == s.Nume+' '+s.Prenume)
                    idManager2 = s.Id;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numeManagerEN = comboBox4.Text;
            foreach (Angajat s in managerActualMutare)
            {
                if (numeManagerEN == s.Nume+' '+s.Prenume)
                {
                    idManagerEN = s.Id;
                }
                moveGetEmployee = GetManagerEmployee(idManagerEN);
                comboBox5.Items.Clear();
            
                foreach (Angajat p in moveGetEmployee)
                {

                    comboBox5.Items.Add(p.Nume + ' '+p.Prenume) ;

                }
            }
        }

        private void panelModificareManageri_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numeManagerSE = comboBox6.Text;

            foreach (Angajat s in managerActualMutare)
            {

                if (numeManagerSE == s.Nume+' ' + s.Prenume)
                {
                    idManagerSE = s.Id;

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
            int idVManager = 0;
            foreach (Angajat p in viitorManager)
            {
                if (comboBox5.Text == p.Nume+' '+p.Prenume)
                {
                    idVManager = p.Id;
                }
            }
            string echipaNoua = "update Angajat set managerId=" + 26 + " where id=" + idVManager;
            
    
            MessageBox.Show("Ati creat o noua echipa manageriata de " + comboBox5.Text + "!");
        }

        private void btnConcedPanel_Click(object sender, EventArgs e)
        {
            if (panelConcediere.Visible)
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
            foreach (Angajat p in managerActualMutare)
            {
                concediereManager.Items.Add(p.Nume+' '+p.Prenume);
            }
        }

        private void concediereManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            foreach (Angajat p in managerActualMutare)
            {
                if (p.Nume+' '+p.Prenume== concediereManager.Text)
                    concedManagId = p.Id;
            }

          

            angajatiiManagerului = GetManagerEmployee(concedManagId);

            angajatConcediat.Items.Clear();
            foreach (Angajat p in angajatiiManagerului)
            {   
                
                angajatConcediat.Items.Add(p.Nume+' ' +p.Prenume);
            }


        }
        private void btnConcediereAngajat_Click(object sender, EventArgs e)
        {
            foreach (Angajat p in angajatiiManagerului)
            {
                if (p.Nume+' '+p.Prenume== angajatConcediat.Text)
                {

                    idAngajatConcediat = p.Id;
                }

            }

            string responseString = "http://localhost:5096/PutConcediat?idAngajat=" + idAngajatConcediat;
            HttpResponseMessage response = client.GetAsync(responseString).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;
            List<Angajat> managerActualMutare = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);
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

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            numeManager = DepartamentManager.Text;
            foreach (Angajat s in managerActualMutare)
            {


                if (numeManager == s.Nume+' '+s.Prenume)
                {
                    idManagerDepartament = s.Id;
                }

            }
            
            List<Angajat> departAngaj = GetManagerEmployee(idManagerDepartament);

            DepartamentAngajat.Items.Clear();
            foreach (Angajat a in departAngaj)
            {
                DepartamentAngajat.Items.Add(a.Nume+' '+a.Prenume);
            }

            List<Departament> departamente = GetDepartaments();
            DepartamentDepartament.Items.Clear();
            foreach (Departament d in departamente)
            {
                DepartamentDepartament.Items.Add(d.Denumire);
            }
            foreach (Departament p in departamente)
            {
                if (p.Denumire == DepartamentDepartament.Text)
                    idDepartament =p.Id;
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            numeManager = FunctieManager.Text;
            foreach (Angajat s in managerActualMutare)
            {


                if (numeManager == s.Nume+' '+s.Prenume)
                {
                    idManagerFunct=s.Id;
                }

            }
           
            List<Angajat> FunctAngaj = GetManagerEmployee(idManagerFunct);

            FunctieAngajat.Items.Clear();
            foreach (Angajat a in FunctAngaj)
            {
                FunctieAngajat.Items.Add(a.Nume+' '+a.Prenume);
            }
          
            List<Functie> functii = GetFunctie();
            Functiefunctie.Items.Clear();
            foreach (Functie f in functii)
            {
                Functiefunctie.Items.Add(f.Denumire);
            }
            foreach (Functie f in functii)
            {
                if (f.Denumire == Functiefunctie.Text)
                    idFunctie = f.Id;
            }
            

        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnDepart_Click(object sender, EventArgs e)
        {
  
        }

        private void BtnFunct_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
 


}
