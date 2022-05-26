using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App2.Data.Migrations
{
    public partial class AgregarFechaUltActArticulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UltActv",
                table: "Articulos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltActv",
                table: "Articulos");
        }
    }
}
