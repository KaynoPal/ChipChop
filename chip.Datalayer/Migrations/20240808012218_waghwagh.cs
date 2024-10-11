using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class waghwagh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("32832b2c-4565-408f-b537-742c49c28ba1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7dd4ad31-ae9d-49db-9602-0ed0e92ee724"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("e5ddb167-c8f8-43d8-a20d-e2a579af61b2"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("8eb530f1-2d92-4d35-9f21-84b4c3ca9b30"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("e5ddb167-c8f8-43d8-a20d-e2a579af61b2"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("7dd4ad31-ae9d-49db-9602-0ed0e92ee724"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("32832b2c-4565-408f-b537-742c49c28ba1"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("7dd4ad31-ae9d-49db-9602-0ed0e92ee724"), "09020123456" });
        }
    }
}
