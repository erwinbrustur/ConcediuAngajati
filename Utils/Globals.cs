using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcediuAngajati.Utils
{
    public static class Globals
    {
        public static readonly HttpClient client = new HttpClient();
        public static readonly string apiUrl = "http://localhost:5096/";
    }
}
