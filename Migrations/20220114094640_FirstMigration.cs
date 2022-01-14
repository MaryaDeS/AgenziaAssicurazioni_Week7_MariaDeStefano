using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenziaAssicurazioni_Week7_MariaDeStefano.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CodiceFiscale = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CodiceFiscale);
                });

            migrationBuilder.CreateTable(
                name: "Polizza",
                columns: table => new
                {
                    NumeroPolizza = table.Column<int>(type: "int", fixedLength: true, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataStipula = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ImportoAssicurazione = table.Column<double>(type: "float", nullable: false),
                    RataMensile = table.Column<double>(type: "float", nullable: false),
                    CodiceFiscale = table.Column<string>(type: "nchar(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizza", x => x.NumeroPolizza);
                    table.ForeignKey(
                        name: "FK_Polizza_Cliente_CodiceFiscale",
                        column: x => x.CodiceFiscale,
                        principalTable: "Cliente",
                        principalColumn: "CodiceFiscale");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Polizza_CodiceFiscale",
                table: "Polizza",
                column: "CodiceFiscale");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polizza");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
