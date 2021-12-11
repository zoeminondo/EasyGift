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
#pragma warning restore 612, 618
        }
    }
}