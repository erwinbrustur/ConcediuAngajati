using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcediuAngajati
{
    public class Concediu
    {
        int id;
        int tipConcediuId;
        DateTime dataInceput;
        DateTime dataSfarsit;
        int inlocuitorId;
        string comentarii;
        int stareConcediuId;
        int angajatId;

        public Concediu(int id, int tipConcediuId, DateTime dataInceput, DateTime dataSfarsit, int inlocuitorId, string comentarii, int stareConcediuId, int angajatId)
        {
            this.id = id;
            this.tipConcediuId = tipConcediuId;
            this.dataInceput = dataInceput;
            this.dataSfarsit = dataSfarsit;
            this.inlocuitorId = inlocuitorId;
            this.comentarii = comentarii;
            this.stareConcediuId = stareConcediuId;
            this.angajatId = angajatId;
        }

        public Concediu(int id, int tipConcediuId, DateTime dataInceput, DateTime dataSfarsit, int inlocuitorId, int angajatId)
        {
            this.id = id;
            this.tipConcediuId = tipConcediuId;
            this.dataInceput = dataInceput;
            this.dataSfarsit = dataSfarsit;
            this.inlocuitorId = inlocuitorId;
            this.angajatId = angajatId;
        }

        public int Id
        {
            get { return this.id; }
        }
        public int TipConcediu
        {
            get { return this.tipConcediuId; }
            set { if (value != 0) this.tipConcediuId = value; }
        }
        public DateTime DataInceput
        {
            get { return this.dataInceput; }
            set { this.dataInceput = value; }
        }
        public DateTime DataSfarsit
        {
            get { return this.dataSfarsit; }
            set { this.dataSfarsit = value; }
        }
        public int InlocuitorId
        {
            get { return this.inlocuitorId; }
        }
        public string Comentarii
        {
            get { return this.comentarii; }
            set { this.comentarii = value; }
        }
        public int StareConcediuId
        {
            get { return this.stareConcediuId; }
            set { if (value != 0) this.stareConcediuId = value; }
        }
        public int AngajatId
        {
            get { return this.angajatId; }
            set { if (value != 0) this.angajatId = value; }
        }
    }
}
