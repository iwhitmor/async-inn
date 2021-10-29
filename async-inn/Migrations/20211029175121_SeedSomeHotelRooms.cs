using Microsoft.EntityFrameworkCore.Migrations;

namespace async_inn.Migrations
{
    public partial class SeedSomeHotelRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelId", "RoomNumber", "PetFriendly", "Price" },
                values: new object[,]
                {
                    { 1, 10, false, 110m },
                    { 1, 11, false, 150m },
                    { 1, 12, false, 175m },
                    { 2, 20, false, 100m },
                    { 2, 21, false, 120m },
                    { 2, 22, false, 150m },
                    { 3, 30, false, 135m },
                    { 3, 31, false, 180m },
                    { 3, 32, false, 200m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 2, 20 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 2, 21 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 3, 30 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 3, 31 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 3, 32 });
        }
    }
}
