﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyGift.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadeau",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    titre = table.Column<string>(type: "TEXT", nullable: false),
                    commentaire = table.Column<string>(type: "TEXT", nullable: false),
                    marque = table.Column<string>(type: "TEXT", nullable: false),
                    prix = table.Column<decimal>(type: "TEXT", nullable: false),
                    lien = table.Column<string>(type: "TEXT", nullable: true),
                    photo = table.Column<string>(type: "TEXT", nullable: true),
                    dejaAchete = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadeau", x => x.Id);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadeau");

            migrationBuilder.DropTable(
                name: "Utilisateur");
        }
    }
}
