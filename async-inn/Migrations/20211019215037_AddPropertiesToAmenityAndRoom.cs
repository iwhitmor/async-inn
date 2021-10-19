using Microsoft.EntityFrameworkCore.Migrations;

namespace async_inn.Migrations
{
    public partial class AddPropertiesToAmenityAndRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Layout",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Layout",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Amenities");
        }
    }
}
