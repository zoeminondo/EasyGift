using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyGift.Migrations
{
    public partial class AjoutCadeau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadeau",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cadeau = table.Column<string>(type: "TEXT", nullable: false),
                    commentaire = table.Column<string>(type: "TEXT", nullable: false),
                    marque = table.Column<string>(type: "TEXT", nullable: false),
                    prix = table.Column<decimal>(type: "TEXT", nullable: false),
                    lien = table.Column<decimal>(type: "TEXT", nullable: false),
                    photo = table.Column<string>(type: "TEXT", nullable: false),
                    dejaAchete = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadeau", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadeau");
        }
    }
}
