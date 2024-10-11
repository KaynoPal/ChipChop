using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class newModellll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("39dbeba9-1d0d-4175-a26d-662cd403dbae"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("66e0725a-43bf-43ee-b169-c8c645124d0d"));

            migrationBuilder.AddColumn<int>(
                name: "NumberAvailable",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Selloff",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("46aa3ab8-6ada-4e20-ac2d-dc6de7c49fc1"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("dd4bed5a-9802-4e21-9f40-e4f571c6e6cd"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("46aa3ab8-6ada-4e20-ac2d-dc6de7c49fc1"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dd4bed5a-9802-4e21-9f40-e4f571c6e6cd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("46aa3ab8-6ada-4e20-ac2d-dc6de7c49fc1"));

            migrationBuilder.DropColumn(
                name: "NumberAvailable",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Selloff",
                table: "Contents");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("66e0725a-43bf-43ee-b169-c8c645124d0d"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("39dbeba9-1d0d-4175-a26d-662cd403dbae"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("66e0725a-43bf-43ee-b169-c8c645124d0d"), "09020123456" });
        }
    }
}
