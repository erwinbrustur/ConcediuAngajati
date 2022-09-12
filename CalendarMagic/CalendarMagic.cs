using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcediuAngajati.CalendarMagic
{
    public partial class CalendarMagic : Form
    {
        int luna, an;
        public CalendarMagic()
        {
            InitializeComponent();
        }

        private void CalendarMagic_Load(object sender, EventArgs e)
        {
            displayDays();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            //curatam containerul
            zi.Controls.Clear();

            // scadem luna la luna precedenta
            luna--;
            if (luna < 1)
            {
                an--;
                luna = 12;
            }



            String numeLuna = DateTimeFormatInfo.CurrentInfo.GetMonthName(luna);
            lunaAfis.Text = numeLuna + " " + an;

            DateTime ineputLuna = new DateTime(an, luna, 1);

            // numarul zilelor din luna

            int days = DateTime.DaysInMonth(an, luna);

            // convertim inceputul lunii in int

            int dayoftheweek = Convert.ToInt32(ineputLuna.DayOfWeek.ToString("d")) + 1;

            // user control

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControl1 user1 = new UserControl1();
                zi.Controls.Add(user1);
            }

            // user control for days

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);
                zi.Controls.Add(ucDays);
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            //curatam containerul
            zi.Controls.Clear();

            // crestem luna
            luna++;
            if (luna == 13)
            {
                an++;
                luna = 1;
            }

            String numeLuna = DateTimeFormatInfo.CurrentInfo.GetMonthName(luna);
            lunaAfis.Text = numeLuna + " " + an;


            DateTime ineputLuna = new DateTime(an, luna, 1);

            // numarul zilelor din luna
            int days = DateTime.DaysInMonth(an, luna);

            // convertim inceputul lunii in int

            int dayoftheweek = Convert.ToInt32(ineputLuna.DayOfWeek.ToString("d")) + 1;

            // user control

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControl1 user1 = new UserControl1();
                zi.Controls.Add(user1);
            }

            // user control for days

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);
                zi.Controls.Add(ucDays);
            }
        }

        private void panel45_Paint(object sender, PaintEventArgs e)
        {

        }

        private void displayDays()
        {
            DateTime now = DateTime.Now;
            luna = now.Month;
            an = now.Year;

            String numeLuna = DateTimeFormatInfo.CurrentInfo.GetMonthName(luna);
            lunaAfis.Text = numeLuna + " " + an;

            // prima zi din luna
            DateTime ineputLuna = new DateTime(an, luna, 1);

            // numarul zilelor din luna

            int days = DateTime.DaysInMonth(an, luna);

            // convertim inceputul lunii in int

            int dayoftheweek = Convert.ToInt32(ineputLuna.DayOfWeek.ToString("d")) + 1;

            // user control blank

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControl1 user1 = new UserControl1();
                zi.Controls.Add(user1);

            }

            // user control for days

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);
                zi.Controls.Add(ucDays);
            }




        }

    }
}
