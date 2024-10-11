using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class poopoopoop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("319c88f5-003f-4450-9b8e-0d651bf97fdc"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ae1fdc77-ed82-4551-898d-84486e53479b"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("9225302e-02a8-43c0-9296-59e14a842b8d"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("f2ed74ac-26d5-429f-a46a-09c22c296d7c"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("9225302e-02a8-43c0-9296-59e14a842b8d"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f2ed74ac-26d5-429f-a46a-09c22c296d7c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9225302e-02a8-43c0-9296-59e14a842b8d"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("ae1fdc77-ed82-4551-898d-84486e53479b"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("319c88f5-003f-4450-9b8e-0d651bf97fdc"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("ae1fdc77-ed82-4551-898d-84486e53479b"), "09020123456" });
        }
    }
}
