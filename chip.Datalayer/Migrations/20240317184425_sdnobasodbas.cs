using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class sdnobasodbas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("14231ffe-ea4f-435b-aa68-4faaefed2ba2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9e6e1ff8-dd11-4a0c-a2e4-335b3a7427a7"));

            migrationBuilder.AddColumn<string>(
                name: "SubmitDate",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("f821367b-9cc0-4293-8d98-22b96cbe6191"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "RoleId", "UserName", "UserPassword" },
                values: new object[] { new Guid("9d34fad2-3653-4ca2-9eac-f02961ceffa4"), true, new Guid("f821367b-9cc0-4293-8d98-22b96cbe6191"), "NoName", "JfnnlDI7RTiF9RgfG2JNCw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d34fad2-3653-4ca2-9eac-f02961ceffa4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f821367b-9cc0-4293-8d98-22b96cbe6191"));

            migrationBuilder.DropColumn(
                name: "SubmitDate",
                table: "Contents");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("9e6e1ff8-dd11-4a0c-a2e4-335b3a7427a7"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "RoleId", "UserName", "UserPassword" },
                values: new object[] { new Guid("14231ffe-ea4f-435b-aa68-4faaefed2ba2"), true, new Guid("9e6e1ff8-dd11-4a0c-a2e4-335b3a7427a7"), "NoName", "JfnnlDI7RTiF9RgfG2JNCw==" });
        }
    }
}
