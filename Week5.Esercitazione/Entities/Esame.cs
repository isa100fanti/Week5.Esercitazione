using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5.Esercitazione.Entities
{
    public class Esame
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Cfu { get; set; }
        public DateTime DataEsame { get; set; }
        public float Votazione { get; set; }
        public int Passato { get; set; }
        public int IDstudente { get; set; }

    }
}
