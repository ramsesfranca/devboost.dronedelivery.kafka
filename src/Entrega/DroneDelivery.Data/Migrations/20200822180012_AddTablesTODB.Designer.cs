﻿// <auto-generated />
using System;
using DroneDelivery.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DroneDelivery.Data.Migrations
{
    [DbContext(typeof(DroneDbContext))]
    [Migration("20200822180012_AddTablesTODB")]
    partial class AddTablesTODB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DroneDelivery.Domain.Entidades.Drone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Autonomia")
                        .HasColumnType("float");

                    b.Property<double>("Capacidade")
                        .HasColumnType("float");

                    b.Property<double>("Carga")
                        .HasColumnType("float");

                    b.Property<DateTime?>("HoraCarregamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("Velocidade")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Drones");
                });

            modelBuilder.Entity("DroneDelivery.Domain.Entidades.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DroneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DroneId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("DroneDelivery.Domain.Entidades.Pedido", b =>
                {
                    b.HasOne("DroneDelivery.Domain.Entidades.Drone", "Drone")
                        .WithMany("Pedidos")
                        .HasForeignKey("DroneId");
                });
#pragma warning restore 612, 618
        }
    }
}