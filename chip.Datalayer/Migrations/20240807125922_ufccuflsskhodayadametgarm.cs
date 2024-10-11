using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class ufccuflsskhodayadametgarm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9db2a23a-0d3e-44f2-8949-b8fedb041c1d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("301a94c4-b5d1-4c42-9d49-427580bebb73"));

            migrationBuilder.DropColumn(
                name: "Selloff",
                table: "Contents");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("523aa99f-593e-4fd9-a230-01f61b0f4f3e"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("37fa4dbe-544a-4d93-8665-281413ea4409"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("523aa99f-593e-4fd9-a230-01f61b0f4f3e"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("37fa4dbe-544a-4d93-8665-281413ea4409"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("523aa99f-593e-4fd9-a230-01f61b0f4f3e"));

            migrationBuilder.AddColumn<int>(
                name: "Selloff",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("301a94c4-b5d1-4c42-9d49-427580bebb73"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("9db2a23a-0d3e-44f2-8949-b8fedb041c1d"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("301a94c4-b5d1-4c42-9d49-427580bebb73"), "09020123456" });
        }
    }
}
