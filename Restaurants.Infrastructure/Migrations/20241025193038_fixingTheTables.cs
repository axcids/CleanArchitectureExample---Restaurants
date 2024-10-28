using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurants.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixingTheTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Customers_CustomerId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CustomerId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteRestaurantId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FavoriteRestaurantId",
                table: "Customers",
                column: "FavoriteRestaurantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Restaurants_FavoriteRestaurantId",
                table: "Customers",
                column: "FavoriteRestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Restaurants_FavoriteRestaurantId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_FavoriteRestaurantId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FavoriteRestaurantId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CustomerId",
                table: "Restaurants",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Customers_CustomerId",
                table: "Restaurants",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
