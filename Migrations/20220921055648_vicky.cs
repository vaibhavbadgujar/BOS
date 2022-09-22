using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankOfSuccess.Migrations
{
    public partial class vicky : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ActivateEmail",
                table: "account",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActivateSMS",
                table: "account",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivateEmail",
                table: "account");

            migrationBuilder.DropColumn(
                name: "ActivateSMS",
                table: "account");
        }
    }
}
