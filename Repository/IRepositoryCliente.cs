using AgenziaAssicurazioni_Week7_MariaDeStefano.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaAssicurazioni_Week7_MariaDeStefano.Repository
{
    public interface IRepositoryCliente:IRepository<Cliente>
    {
        public Cliente GetCliente(string codice);
    }
}
