using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class addcontent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Img",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("244ed2f7-6b13-4459-813f-4e7e39938c5b"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "RoleId", "UserName", "UserPassword" },
                values: new object[] { new Guid("67a2b2b9-8125-44c9-b570-513f7efa067f"), true, new Guid("244ed2f7-6b13-4459-813f-4e7e39938c5b"), "NoName", "JfnnlDI7RTiF9RgfG2JNCw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("67a2b2b9-8125-44c9-b570-513f7efa067f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("244ed2f7-6b13-4459-813f-4e7e39938c5b"));

            migrationBuilder.AlterColumn<string>(
                name: "Img",
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
                values: new object[] { new Guid("95a17904-9222-412a-90dc-b16c51b6c664"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "RoleId", "UserName", "UserPassword" },
                values: new object[] { new Guid("09668f15-5e9c-4229-a3e2-cc58dd8589f6"), true, new Guid("95a17904-9222-412a-90dc-b16c51b6c664"), "NoName", "JfnnlDI7RTiF9RgfG2JNCw==" });
        }
    }
}
