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
        public ConcediuAngajati()
        {
            InitializeComponent();
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";
            extragereConcediiDB();
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
                checkAccept.DataSource = dt;
          

                
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkRespins_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
