using Microsoft.EntityFrameworkCore.Migrations;

namespace App2.Data.Migrations
{
    public partial class CrearTablaArticulos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ArticuloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    PrecioCosto = table.Column<decimal>(nullable: false),
                    PorcentajeGanancia = table.Column<decimal>(nullable: false),
                    PrecioVenta = table.Column<decimal>(nullable: false),
                    SubrubroID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ArticuloID);
                    table.ForeignKey(
                        name: "FK_Articulos_Subrubros_SubrubroID",
                        column: x => x.SubrubroID,
                        principalTable: "Subrubros",
                        principalColumn: "SubrubroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_SubrubroID",
                table: "Articulos",
                column: "SubrubroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");
        }
    }
}
