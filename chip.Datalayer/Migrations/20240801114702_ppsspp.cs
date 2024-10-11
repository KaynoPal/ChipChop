using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class ppsspp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("e1eee119-8c6a-4708-b561-5c288b54c86f"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("b8e2913c-ba3c-4f7f-9fe3-70bf666f6128"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("e1eee119-8c6a-4708-b561-5c288b54c86f"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b8e2913c-ba3c-4f7f-9fe3-70bf666f6128"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e1eee119-8c6a-4708-b561-5c288b54c86f"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("9cf7a43c-a486-4c91-99bd-e8da83197184"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("eb268b1d-a505-42bb-9b11-00de754b9827"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("9cf7a43c-a486-4c91-99bd-e8da83197184"), "09020123456" });
        }
    }
}
