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
        }

        public List<Concediu> extragereTipConcediiDB()
        {
            List<Concediu> listaConcedii = new List<Concediu>();
            string selectSQL = "SELECT * from Concediu";
            SqlConnection conexiune = new SqlConnection(connectionString);
            SqlCommand querySelect = new SqlCommand(selectSQL);
            try
            {
                conexiune.Open();
                querySelect.Connection = conexiune;
                SqlDataReader reader = querySelect.ExecuteReader();

                while (reader.Read())
                {
                    Concediu c = new Concediu(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()), Convert.ToDateTime(reader[2].ToString()), Convert.ToDateTime(reader[3].ToString()), Convert.ToInt32(reader[4].ToString()), reader[5].ToString(), Convert.ToInt32(reader[6].ToString()), Convert.ToInt32(reader[7].ToString()));
                    listaConcedii.Add(c);
                }


                return listaConcedii;
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
    }
}
