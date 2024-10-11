using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class addcontentl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("67a2b2b9-8125-44c9-b570-513f7efa067f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("244ed2f7-6b13-4459-813f-4e7e39938c5b"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("db9723a2-b32e-4d5d-a68c-d06b787fe6c2"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "RoleId", "UserName", "UserPassword" },
                values: new object[] { new Guid("29254a17-9b68-42bb-a5d2-c3bcaa201833"), true, new Guid("db9723a2-b32e-4d5d-a68c-d06b787fe6c2"), "NoName", "JfnnlDI7RTiF9RgfG2JNCw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("29254a17-9b68-42bb-a5d2-c3bcaa201833"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("db9723a2-b32e-4d5d-a68c-d06b787fe6c2"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("244ed2f7-6b13-4459-813f-4e7e39938c5b"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "RoleId", "UserName", "UserPassword" },
                values: new object[] { new Guid("67a2b2b9-8125-44c9-b570-513f7efa067f"), true, new Guid("244ed2f7-6b13-4459-813f-4e7e39938c5b"), "NoName", "JfnnlDI7RTiF9RgfG2JNCw==" });
        }
    }
}
