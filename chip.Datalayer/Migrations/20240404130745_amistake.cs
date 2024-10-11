using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class amistake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d34fad2-3653-4ca2-9eac-f02961ceffa4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f821367b-9cc0-4293-8d98-22b96cbe6191"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("95a17904-9222-412a-90dc-b16c51b6c664"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "RoleId", "UserName", "UserPassword" },
                values: new object[] { new Guid("09668f15-5e9c-4229-a3e2-cc58dd8589f6"), true, new Guid("95a17904-9222-412a-90dc-b16c51b6c664"), "NoName", "JfnnlDI7RTiF9RgfG2JNCw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("09668f15-5e9c-4229-a3e2-cc58dd8589f6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("95a17904-9222-412a-90dc-b16c51b6c664"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("f821367b-9cc0-4293-8d98-22b96cbe6191"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "RoleId", "UserName", "UserPassword" },
                values: new object[] { new Guid("9d34fad2-3653-4ca2-9eac-f02961ceffa4"), true, new Guid("f821367b-9cc0-4293-8d98-22b96cbe6191"), "NoName", "JfnnlDI7RTiF9RgfG2JNCw==" });
        }
    }
}
