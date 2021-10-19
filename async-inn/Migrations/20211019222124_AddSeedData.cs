using Microsoft.EntityFrameworkCore.Migrations;

namespace async_inn.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Amenitiies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mini-Bar" },
                    { 2, "Large Couch" },
                    { 3, "Kitchenette" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Country", "Name", "Phone", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Las Vegas", "USA", "MGM Grand", "800-111-1111", "Nevada", "1 Las Vegas Blvd" },
                    { 2, "Las Vegas", "USA", "Flamingo", "800-222-2222", "Nevada", "2 Las Vegas Blvd" },
                    { 3, "Las Vegas", "USA", "Golden Nugget", "800-333-3333", "Nevada", "3 Las Vegas Blvd" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Luxury Suite" },
                    { 2, 1, "Deluxe Suite" },
                    { 3, 2, "Penthouse Suite" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Amenitiies",
                table: "Amenitiies");

            migrationBuilder.DeleteData(
                table: "Amenitiies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenitiies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenitiies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "Amenitiies",
                newName: "Amenities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amenities",
                table: "Amenities",
                column: "Id");
        }
    }
}
