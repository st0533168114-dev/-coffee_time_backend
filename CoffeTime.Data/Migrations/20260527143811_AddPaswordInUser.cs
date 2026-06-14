using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeTime.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPaswordInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UsersList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UsersList");
        }
    }
}
