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
    public partial class ConcediuAngajati : Form
    {
        string connectionString;
        List<string> listaStare;
        List<string> angajatistring;
        int idAngajatSelectat;
        int StareConcediuId;

        public ConcediuAngajati()
        {
            InitializeComponent();
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";
            extragereConcediiDB();


            listaStare = extragereStareConcediuDB();
         
            foreach (string s in listaStare)
            {
                string[] str = s.Split(',');
                cbStareConcediu.Items.Add(str[1]);

            }
            cbStareConcediu.SelectedIndex = 0;
            listaStare = extragereStareConcediuDB();


            cbStareConcediu.SelectedIndex = 0;

            angajatistring = extragereAngajatiDB();


        }

        public void extragereConcediiDB()
        {
            List<Concediu> listaConcedii = new List<Concediu>();
            string selectSQL = "SELECT a.nume + ' ' + a.prenume as Nume, Convert(date, c.dataInceput) as 'Data Inceput', Convert(date, c.dataSfarsit) as 'Data Sfarsit', a2.nume + ' ' + a2.prenume as Inlocuitor, c.comentarii as 'Comentarii' FROM Angajat a JOIN Concediu c ON a.id = c.angajatId JOIN Angajat a2 ON a2.id = c.inlocuitorId";
            SqlConnection conexiune = new SqlConnection(connectionString);
            SqlCommand querySelect = new SqlCommand(selectSQL);
            try
            {
                conexiune.Open();
                querySelect.Connection = conexiune;
                //SqlDataReader reader = querySelect.ExecuteReader();

                //while (reader.Read())
                //{
                //    Concediu c = new Concediu(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()), Convert.ToDateTime(reader[2].ToString()), Convert.ToDateTime(reader[3].ToString()), Convert.ToInt32(reader[4].ToString()), reader[5].ToString(), Convert.ToInt32(reader[6].ToString()), Convert.ToInt32(reader[7].ToString()));
                //    listaConcedii.Add(c);
                //}

                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter(selectSQL, conexiune);
                adapt.Fill(dt);
                dgvConcedii.DataSource = dt;



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

        private void lblConcediuManageri_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public List<string> extragereStareConcediuDB()
        {
            List<string> stareConcediu = new List<string>();
            string selectSQL = "SELECT * from StareConcediu";
            SqlConnection conexiune = new SqlConnection(connectionString);
            SqlCommand querySelect = new SqlCommand(selectSQL);
            try
            {
                conexiune.Open();
                querySelect.Connection = conexiune;
                SqlDataReader reader = querySelect.ExecuteReader();

                while (reader.Read())
                {
                    stareConcediu.Add(reader[0] + ", "  + reader[1].ToString());

                }


                return stareConcediu;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                conexiune.Close();


            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string str in listaStare)
            {
                string[] s = str.Split(',');
                if (s[1].CompareTo(cbStareConcediu.Text) == 0)
                {
                    StareConcediuId = Convert.ToInt32(s[0]);

                }
            }
        }

        private void Actualizare_Click(object sender, EventArgs e)
        {
            string message = "Sigur vrei sa actualizezi lista de concedii?";
            string title = "Actualizare stare concedii";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {

                string message2 = "Lista a fost actualizata";


                SqlConnection conexiune = new SqlConnection(connectionString);
            
                string insertSQL = "UPDATE c SET stareConcediuId = FROM Concediu c JOIN StareConcediu sc ON sc.id = c.stareConcediuId WHERE stareConcediuId = 1)";

                SqlCommand queryInsert = new SqlCommand(insertSQL);
                try
                {
                    conexiune.Open();
                    queryInsert.Connection = conexiune;

                    queryInsert.ExecuteNonQuery();
                    MessageBox.Show("da");

                    DialogResult result2 = MessageBox.Show(message2, title);
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

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) 
                return;

        }

       
        private void dgvConcedii_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvConcedii_SelectionChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvConcedii.SelectedRows)
            {
                string nume_prenume = row.Cells[0].ToString();

                foreach(string s in angajatistring)
                {
                    string[] t = s.Split(',');
                    if(nume_prenume.Equals(t[1]))
                    {
                        idAngajatSelectat = Convert.ToInt32(t[0]);
                    }
                }
                
            }
           
        }

        public List<string> extragereAngajatiDB()
        {
            List<string> extrageAngajati = new List<string>();
            string selectSQL = "SELECT id, nume, prenume FROM Angajat ";
            
            SqlConnection conexiune = new SqlConnection(connectionString);
            SqlCommand querySelect = new SqlCommand(selectSQL);
            try
            {
                conexiune.Open();
                querySelect.Connection = conexiune;
                SqlDataReader reader = querySelect.ExecuteReader();

                while (reader.Read())
                {
                    extrageAngajati.Add(reader[0].ToString() + ", " + reader[1].ToString() + " " + reader[2].ToString());

                }


                return extrageAngajati;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conexiune.Close();


            }

        }
    }
      
}
