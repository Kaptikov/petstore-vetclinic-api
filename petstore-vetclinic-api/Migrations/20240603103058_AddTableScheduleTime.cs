using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace petstore_vetclinic_api.Migrations
{
    /// <inheritdoc />
    public partial class AddTableScheduleTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Schedules");

            migrationBuilder.CreateTable(
                name: "ScheduleTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleScheduleTime",
                columns: table => new
                {
                    ScheduleTimesId = table.Column<int>(type: "int", nullable: false),
                    SchedulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleScheduleTime", x => new { x.ScheduleTimesId, x.SchedulesId });
                    table.ForeignKey(
                        name: "FK_ScheduleScheduleTime_ScheduleTime_ScheduleTimesId",
                        column: x => x.ScheduleTimesId,
                        principalTable: "ScheduleTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleScheduleTime_Schedules_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleScheduleTime_SchedulesId",
                table: "ScheduleScheduleTime",
                column: "SchedulesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleScheduleTime");

            migrationBuilder.DropTable(
                name: "ScheduleTime");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "Schedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Schedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
