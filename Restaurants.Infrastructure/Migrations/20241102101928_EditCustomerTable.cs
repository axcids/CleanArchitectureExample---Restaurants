using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurants.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditCustomerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_FavoriteRestaurantId",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FavoriteRestaurantId",
                table: "Customers",
                column: "FavoriteRestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_FavoriteRestaurantId",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FavoriteRestaurantId",
                table: "Customers",
                column: "FavoriteRestaurantId",
                unique: true);
        }
    }
}
