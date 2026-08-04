using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaRMA.Migrations
{
    /// <inheritdoc />
    public partial class Inicial_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CriadoPorID",
                table: "PedidosRma",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosRma_CriadoPorID",
                table: "PedidosRma",
                column: "CriadoPorID");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosRma_AspNetUsers_CriadoPorID",
                table: "PedidosRma",
                column: "CriadoPorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosRma_AspNetUsers_CriadoPorID",
                table: "PedidosRma");

            migrationBuilder.DropIndex(
                name: "IX_PedidosRma_CriadoPorID",
                table: "PedidosRma");

            migrationBuilder.DropColumn(
                name: "CriadoPorID",
                table: "PedidosRma");
        }
    }
}
