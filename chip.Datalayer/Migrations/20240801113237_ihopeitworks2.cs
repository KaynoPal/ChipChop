using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class ihopeitworks2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("103d33c7-621c-4fb5-8e7a-2f88e6ba61e3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("508dcc34-2e18-4042-8e25-6c5472ff99a7"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("a82ea01f-a91e-4f49-80b6-310737eaac03"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("622890fe-d180-44a3-a4b3-daee1b1d7e10"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("a82ea01f-a91e-4f49-80b6-310737eaac03"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("622890fe-d180-44a3-a4b3-daee1b1d7e10"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a82ea01f-a91e-4f49-80b6-310737eaac03"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("508dcc34-2e18-4042-8e25-6c5472ff99a7"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("103d33c7-621c-4fb5-8e7a-2f88e6ba61e3"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("508dcc34-2e18-4042-8e25-6c5472ff99a7"), "09020123456" });
        }
    }
}
