using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyGift.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cadeau",
                table: "Cadeau",
                newName: "titre");

            migrationBuilder.AlterColumn<string>(
                name: "lien",
                table: "Cadeau",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "titre",
                table: "Cadeau",
                newName: "cadeau");

            migrationBuilder.AlterColumn<decimal>(
                name: "lien",
                table: "Cadeau",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
