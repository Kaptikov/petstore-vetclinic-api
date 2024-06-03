using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace petstore_vetclinic_api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AnimalId",
                table: "Appointments",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Animals_AnimalId",
                table: "Appointments",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Animals_AnimalId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AnimalId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Appointments");
        }
    }
}
