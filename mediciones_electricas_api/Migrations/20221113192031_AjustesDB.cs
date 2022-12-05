using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mediciones_electricas_api.Migrations
{
    public partial class AjustesDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "listaParte",
                table: "productos");

            migrationBuilder.AddColumn<string>(
                name: "listaParte",
                table: "productos",
                maxLength:100,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "valor",
                table: "pruebas",
                precision:10,
                scale:3,
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equiposEmpleado");

            migrationBuilder.DropTable(
                name: "equiposProductos");

            migrationBuilder.DropTable(
                name: "login");

            migrationBuilder.DropTable(
                name: "ordenProductos");

            migrationBuilder.DropTable(
                name: "pruebas");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "equipos");

            migrationBuilder.DropTable(
                name: "lineaProduccion");

            migrationBuilder.DropTable(
                name: "modelos");

            migrationBuilder.DropTable(
                name: "puestos");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "testPlan");
        }
    }
}
