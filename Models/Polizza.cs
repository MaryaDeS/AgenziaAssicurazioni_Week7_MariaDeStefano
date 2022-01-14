using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaAssicurazioni_Week7_MariaDeStefano.Models
{
    public class Polizza
    {
        [Key]
        public int NumeroPolizza { get; set; }
        public DateTime DataStipula { get; set; }
        public float ImportoAssicurazione { get; set; }
        public float RataMensile { get; set; }

        //relazione uno a molti tra polizza e cliente
        public string? CodiceFiscale { get; set; }
        public Cliente? Cliente { get; set; }


    }
}
