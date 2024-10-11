using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class ufccuflss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("301a94c4-b5d1-4c42-9d49-427580bebb73"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("9db2a23a-0d3e-44f2-8949-b8fedb041c1d"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("301a94c4-b5d1-4c42-9d49-427580bebb73"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9db2a23a-0d3e-44f2-8949-b8fedb041c1d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("301a94c4-b5d1-4c42-9d49-427580bebb73"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("95b354fb-5e59-415b-a248-c1914266279f"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("16dea23a-f509-4939-9519-6a307f748647"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("95b354fb-5e59-415b-a248-c1914266279f"), "09020123456" });
        }
    }
}
