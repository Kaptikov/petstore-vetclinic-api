using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace petstore_vetclinic_api.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldimgUrlToAnimalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgUrl",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgUrl",
                table: "Animals");
        }
    }
}
