using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class ddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36f4884d-f84c-468b-a1c9-f9499d134c6f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b731038e-b8d9-4989-8ac3-286302145ef8"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("2dd3447f-aea7-4c10-a186-fd90b542b614"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("9711c8e7-281d-4ba5-b38a-c8101f2d6193"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("2dd3447f-aea7-4c10-a186-fd90b542b614"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("b731038e-b8d9-4989-8ac3-286302145ef8"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("36f4884d-f84c-468b-a1c9-f9499d134c6f"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("b731038e-b8d9-4989-8ac3-286302145ef8"), "09020123456" });
        }
    }
}
