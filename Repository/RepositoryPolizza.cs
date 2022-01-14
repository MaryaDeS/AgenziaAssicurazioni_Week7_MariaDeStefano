using AgenziaAssicurazioni_Week7_MariaDeStefano.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaAssicurazioni_Week7_MariaDeStefano.Repository
{
    internal class RepositoryPolizza : IRepositoryPolizza
    {
        public Polizza Create(Polizza item)
        {
            using (var ctx = new AgenziaAssicurazioniContext())
            {
                ctx.Polizze?.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public ICollection<Polizza> GetAll()
        {

            using (var ctx = new AgenziaAssicurazioniContext())
            {
                return ctx.Polizze.ToList();
            }
        }

        public Polizza? GetByNumero(int numero)
        {
            return GetAll().FirstOrDefault(n=>n.NumeroPolizza == numero);
        }
    }
}
