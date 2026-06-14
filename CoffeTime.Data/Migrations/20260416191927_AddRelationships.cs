using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeTime.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "OrdersList");

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
                name: "IX_OrdersList_UserId",
                table: "OrdersList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ordersOrderId",
                table: "OrderProduct",
                column: "ordersOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersList_UsersList_UserId",
                table: "OrdersList",
                column: "UserId",
                principalTable: "UsersList",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersList_UsersList_UserId",
                table: "OrdersList");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrdersList_UserId",
                table: "OrdersList");

            migrationBuilder.AddColumn<string>(
                name: "ProductsId",
                table: "OrdersList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
