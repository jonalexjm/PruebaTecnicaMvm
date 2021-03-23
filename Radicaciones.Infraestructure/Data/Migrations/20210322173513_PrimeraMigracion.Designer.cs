﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Radicaciones.Infraestructure;

namespace Radicaciones.Infraestructure.Data.Migrations
{
    [DbContext(typeof(RadicacionesContext))]
    [Migration("20210322173513_PrimeraMigracion")]
    partial class PrimeraMigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Radicaciones.Core.Entities.Anotacion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEvento")
                        .HasColumnType("datetime2");

                    b.Property<long>("TipoAnotacionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioActualizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TipoAnotacionId");

                    b.ToTable("Anotaciones");
                });

            modelBuilder.Entity("Radicaciones.Core.Entities.Archivo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRadicado")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroRadicado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TipoArchivoId")
                        .HasColumnType("bigint");

                    b.Property<string>("UrlArchivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioActualizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TipoArchivoId");

                    b.ToTable("Archivo");
                });

            modelBuilder.Entity("Radicaciones.Core.Entities.GestionDocumento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ArchivoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEnvio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioActualizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ArchivoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("GestionDocumento");
                });

            modelBuilder.Entity("Radicaciones.Core.Entities.TipoAnotacion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreEvento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioActualizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoAnotacion");
                });

            modelBuilder.Entity("Radicaciones.Core.Entities.TipoArchivo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreTipoArchivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioActualizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoArchivo");
                });

            modelBuilder.Entity("Radicaciones.Core.Entities.TipoUsuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreTipoUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioActualizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("Radicaciones.Core.Entities.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TipoUsuarioId")
                        .HasColumnType("bigint");

                    b.Property<string>("UsuarioActualizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Radicaciones.Core.Entities.Anotacion", b =>
                {
                    b.HasOne("Radicaciones.Core.Entities.TipoAnotacion", "TipoAnotacion")
                        .WithMany("Anotaciones")
                        .HasForeignKey("TipoAnotacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Radicaciones.Core.Entities.Archivo", b =>
                {
                    b.HasOne("Radicaciones.Core.Entities.TipoArchivo", "TipoArchivo")
                        .WithMany()
                        .HasForeignKey("TipoArchivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Radicaciones.Core.Entities.GestionDocumento", b =>
                {
                    b.HasOne("Radicaciones.Core.Entities.Archivo", "Archivo")
                        .WithMany()
                        .HasForeignKey("ArchivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Radicaciones.Core.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Radicaciones.Core.Entities.Usuario", b =>
                {
                    b.HasOne("Radicaciones.Core.Entities.TipoUsuario", "TipoUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("TipoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
