using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace petstore_vetclinic_api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProductTableAddTableProductCharacteristicsValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductNutritionalValues_ProductId",
                table: "ProductNutritionalValues");

            migrationBuilder.DropIndex(
                name: "IX_ProductCharacteristics_ProductId",
                table: "ProductCharacteristics");

            migrationBuilder.DropIndex(
                name: "IX_ProductAdvantages_ProductId",
                table: "ProductAdvantages");

            migrationBuilder.RenameColumn(
                name: "NutritionalValue",
                table: "ProductNutritionalValues",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "productDescriptions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Composition",
                table: "ProductCompositions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Characteristics",
                table: "ProductCharacteristics",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Advantage",
                table: "ProductAdvantages",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductAdvantages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProductCharacteristicsValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCharacteristicsId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCharacteristicsValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCharacteristicsValues_ProductCharacteristics_ProductCharacteristicsId",
                        column: x => x.ProductCharacteristicsId,
                        principalTable: "ProductCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductNutritionalValues_ProductId",
                table: "ProductNutritionalValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCharacteristics_ProductId",
                table: "ProductCharacteristics",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAdvantages_ProductId",
                table: "ProductAdvantages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCharacteristicsValues_ProductCharacteristicsId",
                table: "ProductCharacteristicsValues",
                column: "ProductCharacteristicsId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCharacteristicsValues");

            migrationBuilder.DropIndex(
                name: "IX_ProductNutritionalValues_ProductId",
                table: "ProductNutritionalValues");

            migrationBuilder.DropIndex(
                name: "IX_ProductCharacteristics_ProductId",
                table: "ProductCharacteristics");

            migrationBuilder.DropIndex(
                name: "IX_ProductAdvantages_ProductId",
                table: "ProductAdvantages");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductAdvantages");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductNutritionalValues",
                newName: "NutritionalValue");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "productDescriptions",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductCompositions",
                newName: "Composition");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductCharacteristics",
                newName: "Characteristics");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductAdvantages",
                newName: "Advantage");

            migrationBuilder.CreateIndex(
                name: "IX_ProductNutritionalValues_ProductId",
                table: "ProductNutritionalValues",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCharacteristics_ProductId",
                table: "ProductCharacteristics",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAdvantages_ProductId",
                table: "ProductAdvantages",
                column: "ProductId",
                unique: true);
        }
    }
}
