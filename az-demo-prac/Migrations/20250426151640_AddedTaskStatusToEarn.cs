using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace az_demo_prac.Migrations
{
    /// <inheritdoc />
    public partial class AddedTaskStatusToEarn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskStatus",
                table: "Earns",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskStatus",
                table: "Earns");
        }
    }
}
