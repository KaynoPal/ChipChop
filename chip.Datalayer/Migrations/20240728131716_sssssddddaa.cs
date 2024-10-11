using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class sssssddddaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_Users_UserId1",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_UserId1",
                table: "UserInfos");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dd4bed5a-9802-4e21-9f40-e4f571c6e6cd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("46aa3ab8-6ada-4e20-ac2d-dc6de7c49fc1"));

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserInfos");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("fc23e8cd-dff1-4e51-8318-e0d4fe733325"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("b64c8479-a792-4abd-a270-aa5ec0c46e50"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("fc23e8cd-dff1-4e51-8318-e0d4fe733325"), "09020123456" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_Users_UserId",
                table: "UserInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_Users_UserId",
                table: "UserInfos");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b64c8479-a792-4abd-a270-aa5ec0c46e50"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fc23e8cd-dff1-4e51-8318-e0d4fe733325"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UserInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("46aa3ab8-6ada-4e20-ac2d-dc6de7c49fc1"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("dd4bed5a-9802-4e21-9f40-e4f571c6e6cd"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("46aa3ab8-6ada-4e20-ac2d-dc6de7c49fc1"), "09020123456" });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_UserId1",
                table: "UserInfos",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_Users_UserId1",
                table: "UserInfos",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
