using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Smartphone.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicacion",
                columns: table => new
                {
                    AplicacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacion", x => x.AplicacionId);
                });

            migrationBuilder.CreateTable(
                name: "Operario",
                columns: table => new
                {
                    OperarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    apellido = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operario", x => x.OperarioId);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    SensorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.SensorId);
                });

            migrationBuilder.CreateTable(
                name: "Telefono",
                columns: table => new
                {
                    TelefonoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(type: "text", nullable: true),
                    Modelo = table.Column<string>(type: "text", nullable: true),
                    Precio = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefono", x => x.TelefonoId);
                });

            migrationBuilder.CreateTable(
                name: "Instalacion",
                columns: table => new
                {
                    InstalacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Exitosa = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    TelefonoId = table.Column<int>(type: "int", nullable: false),
                    AplicacionId = table.Column<int>(type: "int", nullable: false),
                    OperarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instalacion", x => x.InstalacionId);
                    table.ForeignKey(
                        name: "FK_Instalacion_Aplicacion_AplicacionId",
                        column: x => x.AplicacionId,
                        principalTable: "Aplicacion",
                        principalColumn: "AplicacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instalacion_Operario_OperarioId",
                        column: x => x.OperarioId,
                        principalTable: "Operario",
                        principalColumn: "OperarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instalacion_Telefono_TelefonoId",
                        column: x => x.TelefonoId,
                        principalTable: "Telefono",
                        principalColumn: "TelefonoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SensorTelefono",
                columns: table => new
                {
                    SensoresSensorId = table.Column<int>(type: "int", nullable: false),
                    TelefonosTelefonoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorTelefono", x => new { x.SensoresSensorId, x.TelefonosTelefonoId });
                    table.ForeignKey(
                        name: "FK_SensorTelefono_Sensor_SensoresSensorId",
                        column: x => x.SensoresSensorId,
                        principalTable: "Sensor",
                        principalColumn: "SensorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorTelefono_Telefono_TelefonosTelefonoId",
                        column: x => x.TelefonosTelefonoId,
                        principalTable: "Telefono",
                        principalColumn: "TelefonoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instalacion_AplicacionId",
                table: "Instalacion",
                column: "AplicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Instalacion_OperarioId",
                table: "Instalacion",
                column: "OperarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Instalacion_TelefonoId",
                table: "Instalacion",
                column: "TelefonoId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorTelefono_TelefonosTelefonoId",
                table: "SensorTelefono",
                column: "TelefonosTelefonoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instalacion");

            migrationBuilder.DropTable(
                name: "SensorTelefono");

            migrationBuilder.DropTable(
                name: "Aplicacion");

            migrationBuilder.DropTable(
                name: "Operario");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "Telefono");
        }
    }
}
