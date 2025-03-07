using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Managemate.Migrations
{
    /// <inheritdoc />
    public partial class AddedRatingNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "TasksToDo",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "TasksToDo");
        }
    }
}
