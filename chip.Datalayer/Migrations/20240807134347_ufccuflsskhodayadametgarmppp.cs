using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class ufccuflsskhodayadametgarmppp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("7dd4ad31-ae9d-49db-9602-0ed0e92ee724"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("32832b2c-4565-408f-b537-742c49c28ba1"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("7dd4ad31-ae9d-49db-9602-0ed0e92ee724"), "09020123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("32832b2c-4565-408f-b537-742c49c28ba1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7dd4ad31-ae9d-49db-9602-0ed0e92ee724"));

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
    }
}
