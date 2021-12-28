﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyGift.Migrations
{
    [DbContext(typeof(EasyGiftContext))]
    partial class EasyGiftContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("EasyGift.Models.Cadeau", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("commentaire")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("dejaAchete")
                        .HasColumnType("TEXT");

                    b.Property<string>("lien")
                        .HasColumnType("TEXT");

                    b.Property<int?>("listeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("marque")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("photo")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("prix")
                        .HasColumnType("TEXT");

                    b.Property<string>("titre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("listeId");

                    b.ToTable("Cadeau");
                });

            modelBuilder.Entity("EasyGift.Models.Liste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("createurid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nomListe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("createurid");

                    b.ToTable("Liste");
                });

            modelBuilder.Entity("EasyGift.Models.Utilisateur", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("TEXT");

                    b.Property<int>("cp")
                        .HasColumnType("INTEGER");

                    b.Property<string>("mail")
                        .HasColumnType("TEXT");

                    b.Property<string>("mdp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nomUtilisateur")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("numero")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ville")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Utilisateur");
                });

            modelBuilder.Entity("EasyGift.Models.Cadeau", b =>
                {
                    b.HasOne("EasyGift.Models.Liste", "nomListe")
                        .WithMany("cad")
                        .HasForeignKey("listeId");

                    b.Navigation("nomListe");
                });

            modelBuilder.Entity("EasyGift.Models.Liste", b =>
                {
                    b.HasOne("EasyGift.Models.Utilisateur", "createur")
                        .WithMany()
                        .HasForeignKey("createurid");

                    b.Navigation("createur");
                });

            modelBuilder.Entity("EasyGift.Models.Liste", b =>
                {
                    b.Navigation("cad");
                });
#pragma warning restore 612, 618
        }
    }
}
