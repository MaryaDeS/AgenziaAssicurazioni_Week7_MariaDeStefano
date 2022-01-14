using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaAssicurazioni_Week7_MariaDeStefano.Models
{
    public class RCAuto:Polizza
    {
        public string? Targa { get; set; }
        public int Cilindrata { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Targa: {Targa} - Cilindrata:  {Cilindrata}";
        }
    }
}
