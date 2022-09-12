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
using ProiectASP.Models;
using Newtonsoft.Json;
using ConcediuAngajati.Utils;
using System.Text.RegularExpressions;

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
        List<Angajat> managerActualMutare2 = new List<Angajat>();
     
        List<Departament> departamente = new List<Departament>();
        List<Angajat> departAngaj = new List<Angajat>();
        List<Angajat> FunctAngaj = new List<Angajat>();
        List<Angajat> moveGetEmployee = new List<Angajat>();
        List<Angajat> managerActualMutare = new List<Angajat>();
        List<Angajat> angajatMutare = new List<Angajat>();
        List<Angajat> managerNouMutare = new List<Angajat>();
        List<Angajat> viitorManager = new List<Angajat>();
        List<Angajat> angajatiiManagerului = new List<Angajat>();

        public List<Functie> GetFunctie()
        {

                HttpResponseMessage response =  Globals.client.GetAsync(String.Format("{0}DepartamentSiFunctie/GetAllFuncties",Globals.apiUrl)).Result;
               string responseBody = response.Content.ReadAsStringAsync().Result;
                List<Functie>Functii = JsonConvert.DeserializeObject<List<Functie>>(responseBody);

            return Functii;
        }
        public List<Departament> GetDepartaments()
        {

                HttpResponseMessage response =Globals.client.GetAsync(String.Format("{0}DepartamentSiFunctie/GetAllDepartaments", Globals.apiUrl)).Result;
              string responseBody =response.Content.ReadAsStringAsync().Result;
               List<Departament>departaments = JsonConvert.DeserializeObject<List<Departament>>(responseBody);
         
            return departaments;
        }


          public  List<Angajat> GetManagerEmployee(int idManager)
            {
                HttpResponseMessage response = Globals.client.GetAsync(String.Format("{0}Angajat/GetManagersAngajat?idManag={1}",Globals.apiUrl,idManager)).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                List<Angajat> ManagersEmployees = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);
            return ManagersEmployees;

            }

        public List<Angajat> ExtragereAngajati()
                    {
                        HttpResponseMessage response = Globals.client.GetAsync(String.Format("{0}Angajat/GetAllManagers", Globals.apiUrl)).Result;

                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        List<Angajat> manageri = JsonConvert.DeserializeObject<List<Angajat>>(responseBody);


                        return manageri;
                    }

        public AdministrareAngajati(Angajat a)
        {

            InitializeComponent();
            this.panelAdaugareAngajat.BackColor = Color.FromArgb(99, 127, 124, 127);
            this.panelModificareManageri.BackColor = Color.FromArgb(99, 127, 124, 127);
            this.panelConcediere.BackColor = Color.FromArgb(99, 127, 124, 127);
          
            angajatCurent = a;

          

            managerActualMutare = ExtragereAngajati();
           

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
                label20.Show();
            }
        
               
              
            
            
        
            foreach (Angajat x in managerActualMutare)
            {

                comboBox1.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                comboBox4.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                comboBox6.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
            
            }
            managerActualMutare2 = managerActualMutare;
            managerActualMutare2.Add(angajatCurent);
            foreach (Angajat x in managerActualMutare2)
            {
                DepartamentManager.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                FunctieManager.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
            }

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
            string strRegex = "^[1256]\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])(0[1-9]|[1-4]\\d|5[0-2]|99)(00[1-9]|0[1-9]\\d|[1-9]\\d\\d)\\d$";
            string nrtlfRegex = "^(\\+4|)?(07[0-8]{1}[0-9]{1}|02[0-9]{2}|03[0-9]{2}){1}?(\\s|\\.|\\-)?([0-9]{3}(\\s|\\.|\\-|)){2}$";
            Regex regexTlf = new Regex(nrtlfRegex);
            Regex regexCNP = new Regex(strRegex);
            if (Nume.Text == "")
            {
                MessageBox.Show("Numele este obligatoriu!");
            }
            else if (Prenume.Text =="")
            {
                MessageBox.Show("Prenumele este obligatoriu!");
            }
            else if (Email.Text == "")
            {
                MessageBox.Show("Numele de utilizator este obligatoriu!");
            }
         
            else if (Parola.Text == "")
            {
                MessageBox.Show("Parola este obligatorie!");
            }
            else if (Parola.Text.Length <= 8)
            {
                MessageBox.Show("Parola este prea scurta!");
            }
            else if (CNP.Text.Length !=13)
            {
                MessageBox.Show("Cnp-ul trebuie sa aiba 13 cifre dar are " + CNP.Text.Length.ToString() + " cifre!");
            }
            else if (!regexCNP.IsMatch(CNP.Text))
            {
                MessageBox.Show("CNP invalid");
            }
            else if(NrTel.Text.Length != 10)
            {
                MessageBox.Show("Numarul de telefon trebuie sa aiba 10 cifre dar are " + NrTel.Text.Length + " cifre!");
            }
            else if (!regexTlf.IsMatch(NrTel.Text))
            {
                MessageBox.Show("Numar de telefon invalid");
            }
            else if(Serie.Text.Length != 2)
            {
                MessageBox.Show("Seria trebuie sa aiba 2 caractere!");
            }
            else if (Nr.Text.Length != 6)
            {
                MessageBox.Show("Numarul CI trebuie sa aiba 6 caractere!");
            }
            else if (Parola.Text != ConfParola.Text)
            {
                MessageBox.Show("Parolele trebuie sa fie identice!");
            }
            else {
                string dataNastere;
                if (CNP.Text.IndexOf('1') == 0 || CNP.Text.IndexOf('2') == 0)
                {
                    dataNastere = "19" + CNP.Text.Substring(1, 6);
                }
                else
                {
                    dataNastere = "20" + CNP.Text.Substring(1, 6);
                }
                Angajat AngajatNou = new Angajat();
                AngajatNou.Nume = Nume.Text;
                AngajatNou.Prenume = Prenume.Text;
                String totalsoftRo = "@totalsoft.ro";
                AngajatNou.Email = String.Format("{0}{1}", Email.Text, totalsoftRo);
                AngajatNou.Parola = Hash(Parola.Text);
                AngajatNou.DataAngajare = DateTime.Now;
                string dataNormala = (dataNastere.Substring(4, 2) + "/" + dataNastere.Substring(6, 2) + "/" + dataNastere.Substring(0, 4));
                AngajatNou.DataNasterii = Convert.ToDateTime(dataNormala);
                AngajatNou.Cnp = CNP.Text;
                AngajatNou.Serie = Serie.Text;
                AngajatNou.No = Nr.Text;
                AngajatNou.NrTelefon = NrTel.Text;
                if ((bool)angajatCurent.EsteAdmin)
                {
                    AngajatNou.ManagerId = 30;
                }
                else
                {
                    AngajatNou.ManagerId = angajatCurent.Id;
                }
                if (Poza.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    Poza.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] image_array = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(image_array, 0, image_array.Length);


                    AngajatNou.Poza = image_array;
                }
                AngajatNou.FunctieId = 5;
                AngajatNou.DepartamentId = 7;
                AngajatNou.concediat = false;

                AngajatNou.EsteAdmin = false;


                string jsonString = JsonConvert.SerializeObject(AngajatNou);
                StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                string linkF = String.Format("{0}Orice/PutNewAngajat", Globals.apiUrl);
                var response = Globals.client.PutAsync(linkF, stringContent).Result;
                MessageBox.Show("Angajat adaugat");
                Nume.Text = "";
                Prenume.Text = "";
                Email.Text = "";
                Parola.Text = "";
                ConfParola.Text = "";
                CNP.Text = "";
                Serie.Text = "";
                Nr.Text = "";
                NrTel.Text = "";
                if (Poza.Image != null)
                    Poza.Image.Dispose();
            }

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
                if (!(bool)p.concediat)
                {
                    comboBox2.Items.Add(p.Nume + ' ' + p.Prenume);
                }

            }

            comboBox3.Items.Clear();
            foreach ( Angajat s in managerActualMutare)
            {   if (!(bool)s.EsteAdmin && comboBox1.Text != s.Nume+' '+s.Prenume)
                    comboBox3.Items.Add(s.Nume+' '+s.Prenume);

            }

        }

        private void BtnTransfer_Click_2(object sender, EventArgs e)
        { StringContent stringContent = new StringContent(" ");
            var response = Globals.client.PostAsync(String.Format("{0}Angajat/PostTransfer?AngajatId={1}&managerId={2}", Globals.apiUrl, idAngajat, idManager2),stringContent).Result;
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

            StringContent stringContent = new StringContent(" ");
            var response = Globals.client.PostAsync(String.Format("{0}Angajat/PostStergereEchipa?angajatId={1}", Globals.apiUrl, idManagerSE), stringContent).Result;
            MessageBox.Show("Echipa lui " + comboBox6.Text + " a fost stearsa!");

            managerActualMutare = ExtragereAngajati();
            comboBox1.Items.Clear();
            comboBox4.Items.Clear();
            comboBox6.Items.Clear();
            DepartamentManager.Items.Clear();
            FunctieManager.Items.Clear();
            foreach (Angajat x in managerActualMutare)
            {

                comboBox1.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                comboBox4.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                comboBox6.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
           
                
            }
            managerActualMutare2 = managerActualMutare;
            managerActualMutare2.Add(angajatCurent);
            foreach (Angajat x in managerActualMutare2)
            {
                DepartamentManager.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                FunctieManager.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
            }

        }

        private void BtnEchipaNoua_Click(object sender, EventArgs e)
        {
            int idVManager = 0;
            viitorManager = GetManagerEmployee(idManagerEN);
            foreach (Angajat p in viitorManager)
            {
                if (comboBox5.Text == p.Nume+' '+p.Prenume)
                {
                    idVManager = p.Id;
                }
            }
            StringContent stringContent = new StringContent(" ");
            var response = Globals.client.PostAsync(String.Format("{0}Angajat/PostTransfer?AngajatId={1}&managerId=26", Globals.apiUrl, idVManager), stringContent).Result;

            MessageBox.Show("Ati creat o noua echipa manageriata de " + comboBox5.Text + "!");

            managerActualMutare = ExtragereAngajati();
            comboBox1.Items.Clear();
            comboBox4.Items.Clear();
            comboBox6.Items.Clear();
            DepartamentManager.Items.Clear();
            FunctieManager.Items.Clear();

            foreach (Angajat x in managerActualMutare)
            {

                comboBox1.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                comboBox4.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                comboBox6.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
             
            }
            managerActualMutare2 = managerActualMutare;
            managerActualMutare2.Add(angajatCurent);
            foreach(Angajat x in managerActualMutare2)
            {
                DepartamentManager.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
                FunctieManager.Items.Add(x.Nume.ToString() + ' ' + x.Prenume.ToString());
            }

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
            Angajat angajatulConcediat = new Angajat();
            foreach (Angajat p in angajatiiManagerului)
            {
                if (p.Nume+' '+p.Prenume== angajatConcediat.Text)
                {

                    angajatulConcediat = p;
               
                }

            }
            string jsonString = JsonConvert.SerializeObject(angajatulConcediat);
            StringContent stringContent = new StringContent(jsonString,Encoding.UTF8, "application/json");
            var response = Globals.client.PostAsync(String.Format("{0}Angajat/PostConcediat", Globals.apiUrl),stringContent).Result;
        

        }

        private void Stergere_Enter(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void BtnPaginaPrincipala_Click(object sender, EventArgs e)
        {
            PaginaPrincipala.PaginaPrincipala pp = new PaginaPrincipala.PaginaPrincipala(angajatCurent);
            pp.Show();
            this.Hide();

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            numeManager = DepartamentManager.Text;
            
            foreach (Angajat s in managerActualMutare2)
            {


                if (numeManager == s.Nume+' '+s.Prenume)
                {
                    idManagerDepartament = s.Id;
                }

            }
            
            departAngaj = GetManagerEmployee(idManagerDepartament);

            DepartamentAngajat.Items.Clear();
            foreach (Angajat a in departAngaj)
            {
                DepartamentAngajat.Items.Add(a.Nume+' '+a.Prenume);
            }

                 departamente = GetDepartaments();
            DepartamentDepartament.Items.Clear();
            foreach (Departament d in departamente)
            {
                DepartamentDepartament.Items.Add(d.Denumire);
            }
     
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            numeManager = FunctieManager.Text;
           
            foreach (Angajat s in managerActualMutare2)
            {


                if (numeManager == s.Nume+' '+s.Prenume)
                {
                    idManagerFunct=s.Id;
                }

            }

           
             FunctAngaj = GetManagerEmployee(idManagerFunct);

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
            Angajat angajatAlesdep=new Angajat();
            foreach(Angajat a in departAngaj)
            {
                if ((a.Nume + ' ' + a.Prenume) == DepartamentAngajat.Text)
                    angajatAlesdep = a;
            }
            foreach (Departament p in departamente)
            {
                if (p.Denumire == DepartamentDepartament.Text)
                    idDepartament = p.Id;
            }
            StringContent stringContent = new StringContent(" ");
            var response = Globals.client.PostAsync(String.Format("{0}DepartamentSiFunctie/PostDepartament?AngajatId={1}&DepartamentID={2}", Globals.apiUrl, angajatAlesdep.Id, idDepartament), stringContent).Result;
        }

        private void BtnFunct_Click(object sender, EventArgs e)
        {
            Angajat angajatAles=new Angajat();
            foreach (Angajat a in FunctAngaj)
            {
                if ((a.Nume + ' ' + a.Prenume) == FunctieAngajat.Text)
                    angajatAles = a;
            }
            StringContent stringContent = new StringContent(" ");
            var response = Globals.client.PostAsync(String.Format("{0}DepartamentSiFunctie/PostFunctie?AngajatId={1}&functieID={2}", Globals.apiUrl, angajatAles.Id,idFunctie), stringContent).Result;

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
 


}
