using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaRMA.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTabelaEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "PedidosRma");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "PedidosRma",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosRma_EstadoId",
                table: "PedidosRma",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosRma_Estados_EstadoId",
                table: "PedidosRma",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosRma_Estados_EstadoId",
                table: "PedidosRma");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_PedidosRma_EstadoId",
                table: "PedidosRma");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "PedidosRma");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "PedidosRma",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
