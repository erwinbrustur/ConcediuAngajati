using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcediuAngajati
{
    public class StareConcediu
    {
        int id;
        string nume;
        string cod;

        public StareConcediu(int id, string nume, string cod)
        {
            this.id = id;
            this.nume = nume;
            this.cod = cod;
        }

        public int Id {
            get { return this.id; }
        }
        public string Nume
        {
            get { return this.nume; }
            set { if (value != null) this.nume = value; }
        }
        public string Cod
        {
            get { return this.cod; }
            set { if (value != null) this.cod = value; }
        }
    }
}
