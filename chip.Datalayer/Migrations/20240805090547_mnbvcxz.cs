using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class mnbvcxz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("ae1fdc77-ed82-4551-898d-84486e53479b"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("319c88f5-003f-4450-9b8e-0d651bf97fdc"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("ae1fdc77-ed82-4551-898d-84486e53479b"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("319c88f5-003f-4450-9b8e-0d651bf97fdc"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ae1fdc77-ed82-4551-898d-84486e53479b"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("e1eee119-8c6a-4708-b561-5c288b54c86f"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("b8e2913c-ba3c-4f7f-9fe3-70bf666f6128"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("e1eee119-8c6a-4708-b561-5c288b54c86f"), "09020123456" });
        }
    }
}
