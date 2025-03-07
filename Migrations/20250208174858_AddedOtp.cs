using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Managemate.Migrations
{
    /// <inheritdoc />
    public partial class AddedOtp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Otp",
                table: "Users",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Otp",
                table: "Users");
        }
    }
}
