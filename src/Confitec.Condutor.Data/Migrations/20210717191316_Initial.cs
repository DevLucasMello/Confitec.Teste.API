using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Confitec.Condutor.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimeiroNome = table.Column<string>(type: "varchar(50)", nullable: true),
                    UltimoNome = table.Column<string>(type: "varchar(50)", nullable: true),
                    CPF = table.Column<string>(type: "varchar(20)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    CNH = table.Column<string>(type: "varchar(20)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condutor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Condutor");
        }
    }
}
