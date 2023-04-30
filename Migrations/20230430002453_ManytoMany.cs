using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP2.Migrations
{
    /// <inheritdoc />
    public partial class ManytoMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeladeriaHelado",
                columns: table => new
                {
                    HeladeriasId = table.Column<int>(type: "INTEGER", nullable: false),
                    HeladosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeladeriaHelado", x => new { x.HeladeriasId, x.HeladosId });
                    table.ForeignKey(
                        name: "FK_HeladeriaHelado_Heladeria_HeladeriasId",
                        column: x => x.HeladeriasId,
                        principalTable: "Heladeria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeladeriaHelado_Helado_HeladosId",
                        column: x => x.HeladosId,
                        principalTable: "Helado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeladeriaHelado_HeladosId",
                table: "HeladeriaHelado",
                column: "HeladosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeladeriaHelado");
        }
    }
}
