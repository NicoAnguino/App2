using Microsoft.EntityFrameworkCore.Migrations;

namespace App2.Data.Migrations
{
    public partial class PrimerMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rubros",
                columns: table => new
                {
                    RubroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubros", x => x.RubroID);
                });

            migrationBuilder.CreateTable(
                name: "Subrubros",
                columns: table => new
                {
                    SubrubroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    RubroID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subrubros", x => x.SubrubroID);
                    table.ForeignKey(
                        name: "FK_Subrubros_Rubros_RubroID",
                        column: x => x.RubroID,
                        principalTable: "Rubros",
                        principalColumn: "RubroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subrubros_RubroID",
                table: "Subrubros",
                column: "RubroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subrubros");

            migrationBuilder.DropTable(
                name: "Rubros");
        }
    }
}
