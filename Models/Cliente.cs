using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaAssicurazioni_Week7_MariaDeStefano.Models
{
    public class Cliente
    {
        [Key]
        public string? CodiceFiscale { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string Indirizzo { get; set; }

        //relazione 1 a molti tra cliente e polizza 
        public ICollection<Polizza>? Polizze { get; set; }=new List<Polizza>();

        public float GetSpesaTotale()
        {
            return Polizze.Sum(p=>p.RataMensile);
        }


        public override string ToString()
        {
            return $"Nome: {Nome} - Cognome: {Cognome} - Indirizzo: {Indirizzo}";
        }
    }
}
