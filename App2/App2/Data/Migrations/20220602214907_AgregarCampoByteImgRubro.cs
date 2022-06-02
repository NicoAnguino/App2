using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App2.Data.Migrations
{
    public partial class AgregarCampoByteImgRubro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Img",
                table: "Rubros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoImg",
                table: "Rubros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Rubros");

            migrationBuilder.DropColumn(
                name: "TipoImg",
                table: "Rubros");
        }
    }
}
