using Microsoft.EntityFrameworkCore.Migrations;

namespace async_inn.Migrations
{
    public partial class UpdateAmenitiesTableWithCorrectSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Amenitiies",
                table: "Amenitiies");

            migrationBuilder.RenameTable(
                name: "Amenitiies",
                newName: "Amenities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amenities",
                table: "Amenities",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Amenities",
                table: "Amenities");

            migrationBuilder.RenameTable(
                name: "Amenities",
                newName: "Amenitiies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amenitiies",
                table: "Amenitiies",
                column: "Id");
        }
    }
}
