using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace questionupload.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessibilities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessibilityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "RoleAccessibilities",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    AccessibilityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAccessibilities", x => new { x.RoleId, x.AccessibilityId });
                    table.ForeignKey(
                        name: "FK_RoleAccessibilities_Accessibilities_AccessibilityId",
                        column: x => x.AccessibilityId,
                        principalTable: "Accessibilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAccessibilities_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    College = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accessibilities",
                columns: new[] { "Id", "AccessibilityName" },
                values: new object[] { 1L, "all" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { 1L, "admin" });

            migrationBuilder.InsertData(
                table: "RoleAccessibilities",
                columns: new[] { "AccessibilityId", "RoleId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "RoleId", "Username" },
                values: new object[] { 1L, "admin123", 1L, "admin" });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "UserId", "College", "Dob", "Location", "Qualification" },
                values: new object[] { 1L, "Admin College", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin Location", "Admin Qualification" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccessibilities_AccessibilityId",
                table: "RoleAccessibilities",
                column: "AccessibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleAccessibilities");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "Accessibilities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
