using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App2.Data.Migrations
{
    public partial class CambiarCampoFechaUltActArticulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltActv",
                table: "Articulos");

            migrationBuilder.AddColumn<DateTime>(
                name: "UltAct",
                table: "Articulos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltAct",
                table: "Articulos");

            migrationBuilder.AddColumn<DateTime>(
                name: "UltActv",
                table: "Articulos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
