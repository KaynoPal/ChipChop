using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class ihopeitworks3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("9cf7a43c-a486-4c91-99bd-e8da83197184"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("eb268b1d-a505-42bb-9b11-00de754b9827"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("9cf7a43c-a486-4c91-99bd-e8da83197184"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("eb268b1d-a505-42bb-9b11-00de754b9827"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9cf7a43c-a486-4c91-99bd-e8da83197184"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("a82ea01f-a91e-4f49-80b6-310737eaac03"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("622890fe-d180-44a3-a4b3-daee1b1d7e10"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("a82ea01f-a91e-4f49-80b6-310737eaac03"), "09020123456" });
        }
    }
}
