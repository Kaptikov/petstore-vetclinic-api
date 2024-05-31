using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace petstore_vetclinic_api.Migrations
{
    /// <inheritdoc />
    public partial class FixTableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FavouriteItems_ProductId",
                table: "FavouriteItems");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteItems_ProductId",
                table: "FavouriteItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FavouriteItems_ProductId",
                table: "FavouriteItems");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteItems_ProductId",
                table: "FavouriteItems",
                column: "ProductId",
                unique: true);
        }
    }
}
