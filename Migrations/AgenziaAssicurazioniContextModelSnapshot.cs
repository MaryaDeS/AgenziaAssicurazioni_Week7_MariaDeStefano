﻿// <auto-generated />
using System;
using AgenziaAssicurazioni_Week7_MariaDeStefano;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgenziaAssicurazioni_Week7_MariaDeStefano.Migrations
{
    [DbContext(typeof(AgenziaAssicurazioniContext))]
    partial class AgenziaAssicurazioniContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AgenziaAssicurazioni_Week7_MariaDeStefano.Models.Cliente", b =>
                {
                    b.Property<string>("CodiceFiscale")
                        .HasMaxLength(16)
                        .HasColumnType("nchar(16)")
                        .IsFixedLength();

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CodiceFiscale");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("AgenziaAssicurazioni_Week7_MariaDeStefano.Models.Polizza", b =>
                {
                    b.Property<int>("NumeroPolizza")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .IsFixedLength();

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumeroPolizza"), 1L, 1);

                    b.Property<string>("CodiceFiscale")
                        .HasColumnType("nchar(16)");

                    b.Property<DateTime>("DataStipula")
                        .HasColumnType("DateTime");

                    b.Property<double>("ImportoAssicurazione")
                        .HasColumnType("float");

                    b.Property<double>("RataMensile")
                        .HasColumnType("float");

                    b.HasKey("NumeroPolizza");

                    b.HasIndex("CodiceFiscale");

                    b.ToTable("Polizza", (string)null);
                });

            modelBuilder.Entity("AgenziaAssicurazioni_Week7_MariaDeStefano.Models.Polizza", b =>
                {
                    b.HasOne("AgenziaAssicurazioni_Week7_MariaDeStefano.Models.Cliente", "Cliente")
                        .WithMany("Polizze")
                        .HasForeignKey("CodiceFiscale");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("AgenziaAssicurazioni_Week7_MariaDeStefano.Models.Cliente", b =>
                {
                    b.Navigation("Polizze");
                });
#pragma warning restore 612, 618
        }
    }
}