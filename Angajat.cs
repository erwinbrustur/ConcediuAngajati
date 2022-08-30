using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcediuAngajati
{
    internal class Angajat
    {
        int id;
        string nume;
        string prenume;
        string email;
        string parola;
        DateTime dataAngajare;
        DateTime dataNasterii;
        string cnp;
        string serie;
        string no;
        string nrTelefon;
        byte[] poza;
        bool esteAdmin;
        int managerId;

        public Angajat(string nume, string prenume, string email, string parola, DateTime dataAngajare, DateTime dataNasterii, string cnp, string serie, string no, string nrTelefon, byte[] poza)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.email = email;
            this.parola = parola;
            this.dataAngajare = dataAngajare;
            this.dataNasterii = dataNasterii;
            this.cnp = cnp;
            this.serie = serie;
            this.no = no;
            this.nrTelefon = nrTelefon;
            this.poza = poza;
        }

        public Angajat(string nume, string prenume, string email, string parola, string nrTelefon)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.email = email;
            this.parola = parola;
            this.nrTelefon = nrTelefon;
        }

        public int Id {
            get{return this.id;}    
        }
        public string Nume
        {
            get{return this.nume;}  
            set{if(value != null) this.nume = value;}
        }
        public string Prenume
        {
            get {return this.prenume;}
            set { if (value != null) this.prenume = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { if (value != null) this.email = value; }
        }
        public string Parola
        {
            get { return this.parola; }
            set { if (value != null) this.parola = value; }
        }
        public string NrTelefon
        {
            get { return this.nrTelefon; }
            set { if (value != null) this.nrTelefon = value; }
        }
        public DateTime DataAngajare
        {
            get { return this.dataAngajare; }
            set { this.dataAngajare = value; }
        }
        public DateTime DataNastarii
        {
            get { return this.dataNasterii; }
            set { this.dataNasterii = value; }
        }
        public string CNP
        {
            get { return this.cnp; }
            set { this.cnp = value; }
        }
        public string Serie
        {
            get { return this.serie; }
            set { this.serie = value; }
        }
        public string Numar
        {
            get { return this.no; }
            set { this.no = value; }
        }
        public byte[] Poza
        {
            get { return this.poza; }
            set { this.poza = value; }
        }
        public bool EsteAdmin
        {
            get { return this.esteAdmin; }
            set { this.esteAdmin = value; }
        }
        public int ManagerId
        {
            get { return this.managerId; }
            set { this.managerId = value; }
        }
    }
}
