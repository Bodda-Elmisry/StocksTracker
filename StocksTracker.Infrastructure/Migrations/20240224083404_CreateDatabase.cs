using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StocksTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stoks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    V = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    O = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    C = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    H = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    L = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    T = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    N = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GettingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_EmailAddress",
                table: "Clients",
                column: "EmailAddress",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Stoks");
        }
    }
}
