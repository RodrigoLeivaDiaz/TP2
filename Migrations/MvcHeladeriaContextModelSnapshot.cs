﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP2.Data;

#nullable disable

namespace TP2.Migrations
{
    [DbContext(typeof(MvcHeladeriaContext))]
    partial class MvcHeladeriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("TP2.Models.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Direccion");
                });

            modelBuilder.Entity("TP2.Models.Heladeria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DireccionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MarcaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DireccionId")
                        .IsUnique();

                    b.HasIndex("MarcaId");

                    b.ToTable("Heladeria");
                });

            modelBuilder.Entity("TP2.Models.Helado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sabor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Helado");
                });

            modelBuilder.Entity("TP2.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("TP2.Models.Heladeria", b =>
                {
                    b.HasOne("TP2.Models.Direccion", "Direccion")
                        .WithOne("Heladeria")
                        .HasForeignKey("TP2.Models.Heladeria", "DireccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP2.Models.Marca", "Marca")
                        .WithMany("Heladerias")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direccion");

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("TP2.Models.Direccion", b =>
                {
                    b.Navigation("Heladeria");
                });

            modelBuilder.Entity("TP2.Models.Marca", b =>
                {
                    b.Navigation("Heladerias");
                });
#pragma warning restore 612, 618
        }
    }
}
