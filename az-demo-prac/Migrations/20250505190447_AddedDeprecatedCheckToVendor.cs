using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace az_demo_prac.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeprecatedCheckToVendor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeprecated",
                table: "Vendors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeprecated",
                table: "Vendors");
        }
    }
}
