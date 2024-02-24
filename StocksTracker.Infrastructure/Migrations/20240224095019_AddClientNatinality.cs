using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StocksTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddClientNatinality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Clients");
        }
    }
}
