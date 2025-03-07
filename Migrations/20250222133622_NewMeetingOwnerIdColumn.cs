using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Managemate.Migrations
{
    /// <inheritdoc />
    public partial class NewMeetingOwnerIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Meetings",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_OwnerId",
                table: "Meetings",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Users_OwnerId",
                table: "Meetings",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Users_OwnerId",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_OwnerId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Meetings");
        }
    }
}
