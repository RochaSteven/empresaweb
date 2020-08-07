﻿// <auto-generated />
using System;
using Empresa2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Empresa2.Migrations
{
    [DbContext(typeof(DataMainContext))]
    partial class DataMainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Empresa2.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Empresa2.Models.Cliente_vehiculo", b =>
                {
                    b.Property<int>("idClienteVehiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdVehiculo")
                        .HasColumnType("int");

                    b.Property<int?>("VehiculoIdVehiculo")
                        .HasColumnType("int");

                    b.HasKey("idClienteVehiculo");

                    b.HasIndex("ClienteIdCliente");

                    b.HasIndex("VehiculoIdVehiculo");

                    b.ToTable("Cliente_vehiculo");
                });

            modelBuilder.Entity("Empresa2.Models.Empresa", b =>
                {
                    b.Property<int>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Propietario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEmpresa");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("Empresa2.Models.Motor", b =>
                {
                    b.Property<int>("IdMotor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDeMotor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMotor");

                    b.ToTable("Motor");
                });

            modelBuilder.Entity("Empresa2.Models.Vehiculo", b =>
                {
                    b.Property<int>("IdVehiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmpresaIdEmpresa")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<int>("IdMotor")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MotorIdMotor")
                        .HasColumnType("int");

                    b.HasKey("IdVehiculo");

                    b.HasIndex("EmpresaIdEmpresa");

                    b.HasIndex("MotorIdMotor");

                    b.ToTable("Vehiculo");
                });

            modelBuilder.Entity("Empresa2.Models.Cliente_vehiculo", b =>
                {
                    b.HasOne("Empresa2.Models.Cliente", "Cliente")
                        .WithMany("Cliente_vehiculo")
                        .HasForeignKey("ClienteIdCliente");

                    b.HasOne("Empresa2.Models.Vehiculo", "Vehiculo")
                        .WithMany("Cliente_vehiculo")
                        .HasForeignKey("VehiculoIdVehiculo");
                });

            modelBuilder.Entity("Empresa2.Models.Vehiculo", b =>
                {
                    b.HasOne("Empresa2.Models.Empresa", "Empresa")
                        .WithMany("Vehiculo")
                        .HasForeignKey("EmpresaIdEmpresa");

                    b.HasOne("Empresa2.Models.Motor", "Motor")
                        .WithMany("Vehiculo")
                        .HasForeignKey("MotorIdMotor");
                });
#pragma warning restore 612, 618
        }
    }
}
