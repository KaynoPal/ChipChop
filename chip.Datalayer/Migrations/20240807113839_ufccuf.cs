using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class ufccuf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("0cc759ab-a919-4c0e-8473-a867780927b7"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("095021e7-e676-43c4-a10c-b3aeb8df10f1"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("0cc759ab-a919-4c0e-8473-a867780927b7"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("095021e7-e676-43c4-a10c-b3aeb8df10f1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0cc759ab-a919-4c0e-8473-a867780927b7"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("4c350a45-aad3-4f3c-8fa5-ece8f69e176d"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("bbbc5d34-ace2-44fe-a157-1125fd93f3ec"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("4c350a45-aad3-4f3c-8fa5-ece8f69e176d"), "09020123456" });
        }
    }
}
