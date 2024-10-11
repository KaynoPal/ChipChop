using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class waghwaghss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8eb530f1-2d92-4d35-9f21-84b4c3ca9b30"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e5ddb167-c8f8-43d8-a20d-e2a579af61b2"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("c0192c07-1e11-487d-9f10-7958c309e7d3"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("11e86446-c3bb-41bf-96b5-62147b3bb1e2"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("c0192c07-1e11-487d-9f10-7958c309e7d3"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11e86446-c3bb-41bf-96b5-62147b3bb1e2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c0192c07-1e11-487d-9f10-7958c309e7d3"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("e5ddb167-c8f8-43d8-a20d-e2a579af61b2"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("8eb530f1-2d92-4d35-9f21-84b4c3ca9b30"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("e5ddb167-c8f8-43d8-a20d-e2a579af61b2"), "09020123456" });
        }
    }
}
