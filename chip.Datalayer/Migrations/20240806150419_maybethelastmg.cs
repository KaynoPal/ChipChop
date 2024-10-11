using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class maybethelastmg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("4c350a45-aad3-4f3c-8fa5-ece8f69e176d"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("bbbc5d34-ace2-44fe-a157-1125fd93f3ec"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("4c350a45-aad3-4f3c-8fa5-ece8f69e176d"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bbbc5d34-ace2-44fe-a157-1125fd93f3ec"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4c350a45-aad3-4f3c-8fa5-ece8f69e176d"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("9225302e-02a8-43c0-9296-59e14a842b8d"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("f2ed74ac-26d5-429f-a46a-09c22c296d7c"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("9225302e-02a8-43c0-9296-59e14a842b8d"), "09020123456" });
        }
    }
}
