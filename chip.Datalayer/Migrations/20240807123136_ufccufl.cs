using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class ufccufl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("95b354fb-5e59-415b-a248-c1914266279f"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("16dea23a-f509-4939-9519-6a307f748647"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("95b354fb-5e59-415b-a248-c1914266279f"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("16dea23a-f509-4939-9519-6a307f748647"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("95b354fb-5e59-415b-a248-c1914266279f"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("0cc759ab-a919-4c0e-8473-a867780927b7"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("095021e7-e676-43c4-a10c-b3aeb8df10f1"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("0cc759ab-a919-4c0e-8473-a867780927b7"), "09020123456" });
        }
    }
}
