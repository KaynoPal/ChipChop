using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class seethat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9135f29e-60b6-49ae-ae2d-6a7b71a01751"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("be263cea-3dcc-4c02-a76f-9576907c60e0"));

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "Users",
                newName: "Password");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("773deb54-2d9f-4b9a-93c6-3163b69d2622"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("c40560e4-8f40-4951-96f7-296355bdf5ef"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("773deb54-2d9f-4b9a-93c6-3163b69d2622"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c40560e4-8f40-4951-96f7-296355bdf5ef"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("773deb54-2d9f-4b9a-93c6-3163b69d2622"));

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "UserPassword");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("be263cea-3dcc-4c02-a76f-9576907c60e0"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "RoleId", "UserName", "UserPassword" },
                values: new object[] { new Guid("9135f29e-60b6-49ae-ae2d-6a7b71a01751"), true, new Guid("be263cea-3dcc-4c02-a76f-9576907c60e0"), "09020123456", "JfnnlDI7RTiF9RgfG2JNCw==" });
        }
    }
}
