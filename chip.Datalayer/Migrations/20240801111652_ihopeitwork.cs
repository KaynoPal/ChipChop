using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class ihopeitwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9711c8e7-281d-4ba5-b38a-c8101f2d6193"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2dd3447f-aea7-4c10-a186-fd90b542b614"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("508dcc34-2e18-4042-8e25-6c5472ff99a7"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("103d33c7-621c-4fb5-8e7a-2f88e6ba61e3"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("508dcc34-2e18-4042-8e25-6c5472ff99a7"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("103d33c7-621c-4fb5-8e7a-2f88e6ba61e3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("508dcc34-2e18-4042-8e25-6c5472ff99a7"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("2dd3447f-aea7-4c10-a186-fd90b542b614"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("9711c8e7-281d-4ba5-b38a-c8101f2d6193"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("2dd3447f-aea7-4c10-a186-fd90b542b614"), "09020123456" });
        }
    }
}
