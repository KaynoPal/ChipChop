using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class newdatabasess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b64c8479-a792-4abd-a270-aa5ec0c46e50"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fc23e8cd-dff1-4e51-8318-e0d4fe733325"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("0c57287a-daca-4358-aac8-c4bd0c5dbcac"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("c1402ca8-86c3-4795-90ba-b260d30b8a77"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("0c57287a-daca-4358-aac8-c4bd0c5dbcac"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c1402ca8-86c3-4795-90ba-b260d30b8a77"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0c57287a-daca-4358-aac8-c4bd0c5dbcac"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("fc23e8cd-dff1-4e51-8318-e0d4fe733325"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("b64c8479-a792-4abd-a270-aa5ec0c46e50"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("fc23e8cd-dff1-4e51-8318-e0d4fe733325"), "09020123456" });
        }
    }
}
