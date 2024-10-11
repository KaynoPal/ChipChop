using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chipchop.Datalayer.Migrations
{
    public partial class newnewtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c40560e4-8f40-4951-96f7-296355bdf5ef"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("773deb54-2d9f-4b9a-93c6-3163b69d2622"));

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Factors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    PayDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserInfos_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactorDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactorId = table.Column<int>(type: "int", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    DetailCount = table.Column<int>(type: "int", nullable: false),
                    DetailPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactorDetails_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FactorDetails_Factors_FactorId",
                        column: x => x.FactorId,
                        principalTable: "Factors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("ea9b13ed-c08b-42f2-95b9-c3000839f0c9"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("174b2a06-3375-46c5-9ffd-35e4d8693cad"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("ea9b13ed-c08b-42f2-95b9-c3000839f0c9"), "09020123456" });

            migrationBuilder.CreateIndex(
                name: "IX_FactorDetails_ContentId",
                table: "FactorDetails",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_FactorDetails_FactorId",
                table: "FactorDetails",
                column: "FactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Factors_UserId",
                table: "Factors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_UserId1",
                table: "UserInfos",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactorDetails");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "Factors");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("174b2a06-3375-46c5-9ffd-35e4d8693cad"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ea9b13ed-c08b-42f2-95b9-c3000839f0c9"));

            migrationBuilder.DropColumn(
                name: "price",
                table: "Contents");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName", "RoleTitle" },
                values: new object[] { new Guid("773deb54-2d9f-4b9a-93c6-3163b69d2622"), "admin", "مدیر" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("c40560e4-8f40-4951-96f7-296355bdf5ef"), true, "JfnnlDI7RTiF9RgfG2JNCw==", new Guid("773deb54-2d9f-4b9a-93c6-3163b69d2622"), "09020123456" });
        }
    }
}
