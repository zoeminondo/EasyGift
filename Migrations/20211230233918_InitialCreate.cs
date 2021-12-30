using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyGift.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    prenom = table.Column<string>(type: "TEXT", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ville = table.Column<string>(type: "TEXT", nullable: false),
                    cp = table.Column<int>(type: "INTEGER", nullable: false),
                    nomUtilisateur = table.Column<string>(type: "TEXT", nullable: false),
                    mdp = table.Column<string>(type: "TEXT", nullable: false),
                    mail = table.Column<string>(type: "TEXT", nullable: true),
                    numero = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Liste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomListe = table.Column<string>(type: "TEXT", nullable: false),
                    createurId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Liste_Utilisateur_createurId",
                        column: x => x.createurId,
                        principalTable: "Utilisateur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cadeau",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    titre = table.Column<string>(type: "TEXT", nullable: false),
                    commentaire = table.Column<string>(type: "TEXT", nullable: false),
                    marque = table.Column<string>(type: "TEXT", nullable: false),
                    prix = table.Column<double>(type: "REAL", nullable: false),
                    lien = table.Column<string>(type: "TEXT", nullable: true),
                    photo = table.Column<string>(type: "TEXT", nullable: true),
                    dejaAchete = table.Column<string>(type: "TEXT", nullable: true),
                    listeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadeau", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cadeau_Liste_listeId",
                        column: x => x.listeId,
                        principalTable: "Liste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cadeau_listeId",
                table: "Cadeau",
                column: "listeId");

            migrationBuilder.CreateIndex(
                name: "IX_Liste_createurId",
                table: "Liste",
                column: "createurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadeau");

            migrationBuilder.DropTable(
                name: "Liste");

            migrationBuilder.DropTable(
                name: "Utilisateur");
        }
    }
}
