using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class aksnobgsoabgosab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Roles_RoleId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleId",
                table: "Roles");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b2542ca-7128-423a-8921-1c2b902f256b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("43f5febb-5791-442d-84b7-b79c719eb96d"));

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Roles");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("9e6e1ff8-dd11-4a0c-a2e4-335b3a7427a7"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "RoleId", "UserName", "UserPassword" },
                values: new object[] { new Guid("14231ffe-ea4f-435b-aa68-4faaefed2ba2"), true, new Guid("9e6e1ff8-dd11-4a0c-a2e4-335b3a7427a7"), "NoName", "JfnnlDI7RTiF9RgfG2JNCw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("14231ffe-ea4f-435b-aa68-4faaefed2ba2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9e6e1ff8-dd11-4a0c-a2e4-335b3a7427a7"));

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleId", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("43f5febb-5791-442d-84b7-b79c719eb96d"), null, "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "RoleId", "UserName", "UserPassword" },
                values: new object[] { new Guid("3b2542ca-7128-423a-8921-1c2b902f256b"), true, new Guid("43f5febb-5791-442d-84b7-b79c719eb96d"), "NoName", "JfnnlDI7RTiF9RgfG2JNCw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleId",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Roles_RoleId",
                table: "Roles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
