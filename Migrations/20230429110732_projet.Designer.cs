﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gestion_de_stock.Data;

#nullable disable

namespace gestion_de_stock.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230429110732_projet")]
    partial class projet
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("gestion_de_stock.Models.Admin", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("gestion_de_stock.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<string>("Addresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClient");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("gestion_de_stock.Models.Commande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("dateCommande")
                        .HasColumnType("datetime2");

                    b.Property<int>("idClient")
                        .HasColumnType("int");

                    b.Property<int>("idProduit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("idClient");

                    b.HasIndex("idProduit");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("gestion_de_stock.Models.Produit", b =>
                {
                    b.Property<int>("IdProduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduit"));

                    b.Property<string>("Categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomProduit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PrixUnit")
                        .HasColumnType("real");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.HasKey("IdProduit");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("gestion_de_stock.Models.Commande", b =>
                {
                    b.HasOne("gestion_de_stock.Models.Client", "client")
                        .WithMany("commandes")
                        .HasForeignKey("idClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gestion_de_stock.Models.Produit", "Produit")
                        .WithMany("commandes")
                        .HasForeignKey("idProduit")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produit");

                    b.Navigation("client");
                });

            modelBuilder.Entity("gestion_de_stock.Models.Client", b =>
                {
                    b.Navigation("commandes");
                });

            modelBuilder.Entity("gestion_de_stock.Models.Produit", b =>
                {
                    b.Navigation("commandes");
                });
#pragma warning restore 612, 618
        }
    }
}
