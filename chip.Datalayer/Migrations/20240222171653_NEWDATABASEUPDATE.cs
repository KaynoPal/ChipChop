using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class NEWDATABASEUPDATE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1145f7e3-b37e-4fd1-9e2f-4a5253fbe745"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("af2b31a1-0de9-4719-b564-737f5bd2c986"));

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleId", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("43f5febb-5791-442d-84b7-b79c719eb96d"), null, "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "RoleId", "UserName", "UserPassword" },
                values: new object[] { new Guid("3b2542ca-7128-423a-8921-1c2b902f256b"), true, new Guid("43f5febb-5791-442d-84b7-b79c719eb96d"), "NoName", "JfnnlDI7RTiF9RgfG2JNCw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_GroupId",
                table: "Contents",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b2542ca-7128-423a-8921-1c2b902f256b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("43f5febb-5791-442d-84b7-b79c719eb96d"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleId", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("af2b31a1-0de9-4719-b564-737f5bd2c986"), null, "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "RoleId", "UserName", "UserPassword" },
                values: new object[] { new Guid("1145f7e3-b37e-4fd1-9e2f-4a5253fbe745"), true, new Guid("af2b31a1-0de9-4719-b564-737f5bd2c986"), "NoName", "JfnnlDI7RTiF9RgfG2JNCw==" });
        }
    }
}
