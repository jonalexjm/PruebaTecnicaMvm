using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Radicaciones.Infraestructure.Data.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoAnotacion",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UsuarioCreacion = table.Column<string>(nullable: true),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    UsuarioActualizacion = table.Column<string>(nullable: true),
                    NombreEvento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAnotacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoArchivo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UsuarioCreacion = table.Column<string>(nullable: true),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    UsuarioActualizacion = table.Column<string>(nullable: true),
                    NombreTipoArchivo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoArchivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UsuarioCreacion = table.Column<string>(nullable: true),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    UsuarioActualizacion = table.Column<string>(nullable: true),
                    NombreTipoUsuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anotaciones",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UsuarioCreacion = table.Column<string>(nullable: true),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    UsuarioActualizacion = table.Column<string>(nullable: true),
                    FechaEvento = table.Column<DateTime>(nullable: false),
                    Usuario = table.Column<string>(nullable: true),
                    TipoAnotacionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anotaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anotaciones_TipoAnotacion_TipoAnotacionId",
                        column: x => x.TipoAnotacionId,
                        principalTable: "TipoAnotacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Archivo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UsuarioCreacion = table.Column<string>(nullable: true),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    UsuarioActualizacion = table.Column<string>(nullable: true),
                    NumeroRadicado = table.Column<string>(nullable: true),
                    FechaRadicado = table.Column<DateTime>(nullable: false),
                    UrlArchivo = table.Column<string>(nullable: true),
                    TipoArchivoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archivo_TipoArchivo_TipoArchivoId",
                        column: x => x.TipoArchivoId,
                        principalTable: "TipoArchivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UsuarioCreacion = table.Column<string>(nullable: true),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    UsuarioActualizacion = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    NumeroDocumento = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    CorreoElectronico = table.Column<string>(nullable: true),
                    Contraseña = table.Column<string>(nullable: true),
                    TipoUsuarioId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "TipoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GestionDocumento",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UsuarioCreacion = table.Column<string>(nullable: true),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    UsuarioActualizacion = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true),
                    FechaEnvio = table.Column<DateTime>(nullable: false),
                    ArchivoId = table.Column<long>(nullable: false),
                    UsuarioId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestionDocumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GestionDocumento_Archivo_ArchivoId",
                        column: x => x.ArchivoId,
                        principalTable: "Archivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GestionDocumento_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anotaciones_TipoAnotacionId",
                table: "Anotaciones",
                column: "TipoAnotacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Archivo_TipoArchivoId",
                table: "Archivo",
                column: "TipoArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionDocumento_ArchivoId",
                table: "GestionDocumento",
                column: "ArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionDocumento_UsuarioId",
                table: "GestionDocumento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoUsuarioId",
                table: "Usuario",
                column: "TipoUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anotaciones");

            migrationBuilder.DropTable(
                name: "GestionDocumento");

            migrationBuilder.DropTable(
                name: "TipoAnotacion");

            migrationBuilder.DropTable(
                name: "Archivo");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoArchivo");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
