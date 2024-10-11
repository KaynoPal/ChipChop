using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class newMG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("174b2a06-3375-46c5-9ffd-35e4d8693cad"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ea9b13ed-c08b-42f2-95b9-c3000839f0c9"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("66e0725a-43bf-43ee-b169-c8c645124d0d"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("39dbeba9-1d0d-4175-a26d-662cd403dbae"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("66e0725a-43bf-43ee-b169-c8c645124d0d"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("39dbeba9-1d0d-4175-a26d-662cd403dbae"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("66e0725a-43bf-43ee-b169-c8c645124d0d"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("ea9b13ed-c08b-42f2-95b9-c3000839f0c9"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("174b2a06-3375-46c5-9ffd-35e4d8693cad"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("ea9b13ed-c08b-42f2-95b9-c3000839f0c9"), "09020123456" });
        }
    }
}
