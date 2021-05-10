using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeChoiceDiscipline.DAL.Migrations
{
    public partial class identityinitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aad6be8c-3599-4683-8b83-90489024e4c1", "c584cf83-87e7-4d3d-b21a-42dc39d9a75e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "687238bc-72ee-4c14-815f-63dc3c875053", "a4248158-d9b1-462d-bf49-043faa766bfe", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1383c7c-0a9c-45a4-ae24-9d75077a14be", "b81d0f30-608b-4cf4-8da9-b420227df950", "Guest", "GUEST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "687238bc-72ee-4c14-815f-63dc3c875053");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aad6be8c-3599-4683-8b83-90489024e4c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1383c7c-0a9c-45a4-ae24-9d75077a14be");
        }
    }
}
