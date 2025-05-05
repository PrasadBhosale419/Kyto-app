using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace az_demo_prac.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDatatypeInEarn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeprecated",
                table: "Earns",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsDeprecated",
                table: "Earns",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
