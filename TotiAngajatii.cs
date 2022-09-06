using ProiectASP.Models;
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
    public partial class TotiAngajatii : Form
    {
        string connectionString;
        List<string> listaStare;
        List<string> angajatistring;
        int idAngajatSelectat;
        int stareConcediuId;
        int idConcediu;
        Angajat angajat;

        public TotiAngajatii(Angajat a)
        {
            InitializeComponent();
            connectionString = @"Data Source=ts2112\SQLEXPRESS;Initial Catalog=StrangerThings;User ID=internship2022;Password=int";
            angajat = a;

            ExtragereAngajat();
            angajatistring = ExtragereAngajati();
        }

        public void ExtragereAngajat()
        {
            string selectSQL = "select a.nume,a.prenume,a.email,a2.nume+' '+a2.prenume as manager,d.Denumire from Angajat a join Angajat a2 on a.managerId=a2.id join Departament d on d.id=a.departamentId WHERE a.id != 30";

            SqlConnection conexiune = new SqlConnection(connectionString);
            SqlCommand querySelect = new SqlCommand(selectSQL);
            try
            {
                conexiune.Open();
                querySelect.Connection = conexiune;

                SqlDataReader reader = querySelect.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader[0].ToString());

                    
                    item.SubItems.Add(reader[1].ToString());// Nume
                    item.SubItems.Add(reader[2].ToString());//Prenume
                    item.SubItems.Add(reader[3].ToString());//Email
                    item.SubItems.Add(reader[4].ToString());//Manager
                   
                    listView1.Items.Add(item);
                    
                }



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
        public List<string> ExtragereAngajati()
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


        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
