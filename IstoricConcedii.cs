using ConcediuAngajati.PaginaPrincipala;
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

    
    public partial class IstoricConcedii : Form      
    {
        string connectionString;
        List<string> listaStare;
        List<string> angajatistring;
        int idAngajatSelectat;
        int stareConcediuId;
        int idConcediu;
        public IstoricConcedii(Angajat a)
        {
            InitializeComponent();
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";
            listaStare = extragereStareConcediuDB();

            extragereConcediiDB();
     

            angajatistring = extragereAngajatiDB();
        }

        public void extragereConcediiDB()
        {
            List<Concediu> listaConcedii = new List<Concediu>();
            string selectSQL = "SELECT c.id, a.nume + ' ' + a.prenume as Nume, Convert(date, c.dataInceput) as 'Data Inceput', Convert(date, c.dataSfarsit) as 'Data Sfarsit', a2.nume + ' ' + a2.prenume as Inlocuitor, c.comentarii as 'Comentarii', sc.nume FROM Angajat a JOIN Concediu c ON a.id = c.angajatId JOIN Angajat a2 ON a2.id = c.inlocuitorId JOIN StareConcediu sc ON sc.id = c.stareConcediuId";
            SqlConnection conexiune = new SqlConnection(connectionString);
            SqlCommand querySelect = new SqlCommand(selectSQL);
            try
            {
                conexiune.Open();
                querySelect.Connection = conexiune;
                SqlDataReader reader = querySelect.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader[1].ToString());
                  
                    string[] s1 = reader[2].ToString().Split(' ');
                    string[] s2 = reader[3].ToString().Split(' ');
                    item.SubItems.Add(s1[0].ToString());
                    item.SubItems.Add(s2[0].ToString());
                    item.SubItems.Add(reader[4].ToString());
                    item.SubItems.Add(reader[5].ToString());
                    item.SubItems.Add(reader[6].ToString());

                    listView1.Items.Add(item);
                    //Concediu c = new Concediu(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()), Convert.ToDateTime(reader[2].ToString()), Convert.ToDateTime(reader[3].ToString()), Convert.ToInt32(reader[4].ToString()), reader[5].ToString(), Convert.ToInt32(reader[6].ToString()), Convert.ToInt32(reader[7].ToString()));
                    //listaConcedii.Add(c);
                }

                //DataTable dt = new DataTable();
                //SqlDataAdapter adapt = new SqlDataAdapter(selectSQL, conexiune);
                //adapt.Fill(dt);
                //dgvConcedii.DataSource = dt;



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


        private void btnInchidere_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
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
                        stareConcediu.Add(reader[0] + ", " + reader[1].ToString());

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


        }
}
