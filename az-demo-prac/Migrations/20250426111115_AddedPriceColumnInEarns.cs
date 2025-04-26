using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace az_demo_prac.Migrations
{
    /// <inheritdoc />
    public partial class AddedPriceColumnInEarns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Earns",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "taskName",
                table: "Earns",
                newName: "TaskName");

            migrationBuilder.RenameColumn(
                name: "taskDetails",
                table: "Earns",
                newName: "TaskDetails");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Earns",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "flatNo",
                table: "Earns",
                newName: "FlatNo");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Earns",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "addressline2",
                table: "Earns",
                newName: "Addressline2");

            migrationBuilder.RenameColumn(
                name: "addressline1",
                table: "Earns",
                newName: "Addressline1");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Earns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Earns",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Earns");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Earns");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Earns",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "TaskName",
                table: "Earns",
                newName: "taskName");

            migrationBuilder.RenameColumn(
                name: "TaskDetails",
                table: "Earns",
                newName: "taskDetails");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Earns",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "FlatNo",
                table: "Earns",
                newName: "flatNo");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Earns",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Addressline2",
                table: "Earns",
                newName: "addressline2");

            migrationBuilder.RenameColumn(
                name: "Addressline1",
                table: "Earns",
                newName: "addressline1");
        }
    }
}
