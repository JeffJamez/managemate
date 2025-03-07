using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Managemate.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedWorkLogsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckInTime",
                table: "WorkLogs");

            migrationBuilder.RenameColumn(
                name: "TotalWorkingHours",
                table: "WorkLogs",
                newName: "TotalMinutesWorked");

            migrationBuilder.RenameColumn(
                name: "CheckoutTime",
                table: "WorkLogs",
                newName: "LogDate");

            migrationBuilder.CreateTable(
                name: "WorkSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WorkLogId = table.Column<int>(type: "int", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CheckoutTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSessions_WorkLogs_WorkLogId",
                        column: x => x.WorkLogId,
                        principalTable: "WorkLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSessions_WorkLogId",
                table: "WorkSessions",
                column: "WorkLogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkSessions");

            migrationBuilder.RenameColumn(
                name: "TotalMinutesWorked",
                table: "WorkLogs",
                newName: "TotalWorkingHours");

            migrationBuilder.RenameColumn(
                name: "LogDate",
                table: "WorkLogs",
                newName: "CheckoutTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInTime",
                table: "WorkLogs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
