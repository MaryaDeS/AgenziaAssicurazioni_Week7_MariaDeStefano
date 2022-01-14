using AgenziaAssicurazioni_Week7_MariaDeStefano.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaAssicurazioni_Week7_MariaDeStefano.Repository
{
    public class RepositoryCliente : IRepositoryCliente
    {
        public Cliente Create(Cliente item)
        {
            using (var ctx =new AgenziaAssicurazioniContext())
            {
                ctx.Clienti?.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public ICollection<Cliente> GetAll()
        {
            using (var ctx=new AgenziaAssicurazioniContext())
            {
                return ctx.Clienti.ToList();
            }
        }

        public Cliente GetCliente(string codice)
        {
            return GetAll().FirstOrDefault(c=>c.CodiceFiscale==codice);
        }
    }
}
