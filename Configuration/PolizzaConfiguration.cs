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
    public class PolizzaConfiguration : IEntityTypeConfiguration<Polizza>
    {
        public void Configure(EntityTypeBuilder<Polizza> builder)
        {
            builder.ToTable("Polizza");
            builder.HasKey(k => k.NumeroPolizza);
            builder.Property(n => n.NumeroPolizza)
                   .IsFixedLength()
                   .IsRequired();

            builder.Property(d => d.DataStipula)
                   .HasColumnType("DateTime")
                   .IsRequired();
            builder.Property(i => i.ImportoAssicurazione)
                   .HasColumnType("float")
                   .IsRequired();
            builder.Property(r => r.RataMensile)
                   .HasColumnType("float")
                   .IsRequired();

            builder.HasOne(c=>c.Cliente).WithMany(p=>p.Polizze).HasForeignKey(k=>k.CodiceFiscale);

            //gerarchia
            builder.HasDiscriminator<string>("Tipo_Polizza")
                   .HasValue<Polizza>("Polizza")
                   .HasValue<RCAuto>("RCAuto Polizza")
                   .HasValue<Furto>("Furto Polizza")
                   .HasValue<Vita>("Vita Polizza");
                   
        }
    }
}
