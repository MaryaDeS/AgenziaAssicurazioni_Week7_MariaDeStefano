using AgenziaAssicurazioni_Week7_MariaDeStefano.Configuration;
using AgenziaAssicurazioni_Week7_MariaDeStefano.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaAssicurazioni_Week7_MariaDeStefano
{
    internal class AgenziaAssicurazioniContext : DbContext
    {
        public DbSet<Polizza>? Polizze { get; set; }
        public DbSet<Cliente>? Clienti { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AgenziaAssicurazioniDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Polizza>(new PolizzaConfiguration());
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
        }
    }
}
