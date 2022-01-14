using AgenziaAssicurazioni_Week7_MariaDeStefano.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaAssicurazioni_Week7_MariaDeStefano.Configuration
{
    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(k=>k.CodiceFiscale);
            builder.Property(c => c.CodiceFiscale)
                   .HasMaxLength(16)
                   .IsFixedLength()
                   .IsRequired();
            builder.Property(n => n.Nome)
                   .HasMaxLength(20)
                   .IsRequired();
            builder.Property(s => s.Cognome)
                   .HasMaxLength(20)
                   .IsRequired();
            builder.Property(i => i.Indirizzo)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasMany(p => p.Polizze).WithOne(p => p.Cliente);
        }
    }
}
