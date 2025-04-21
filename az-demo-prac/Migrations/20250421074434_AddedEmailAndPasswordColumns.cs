using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace az_demo_prac.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmailAndPasswordColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Users");
        }
    }
}
