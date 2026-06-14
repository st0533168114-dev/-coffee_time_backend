using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeTime.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ProductsList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsList_OrderId",
                table: "ProductsList",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsList_OrdersList_OrderId",
                table: "ProductsList",
                column: "OrderId",
                principalTable: "OrdersList",
                principalColumn: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsList_OrdersList_OrderId",
                table: "ProductsList");

            migrationBuilder.DropIndex(
                name: "IX_ProductsList_OrderId",
                table: "ProductsList");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ProductsList");

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    ordersOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.ProductsProductId, x.ordersOrderId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_OrdersList_ordersOrderId",
                        column: x => x.ordersOrderId,
                        principalTable: "OrdersList",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_ProductsList_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "ProductsList",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ordersOrderId",
                table: "OrderProduct",
                column: "ordersOrderId");
        }
    }
}
