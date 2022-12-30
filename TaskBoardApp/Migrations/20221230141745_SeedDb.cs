using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirsName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4867274c-fad6-45d0-a399-890ba8014164", 0, "981d49c0-8a54-4326-89b5-c7f4a5aac9db", "guest@gmail.com", false, "GUEST", "User", false, null, "GUEST@MAIL.COM", "GUEST", null, null, false, "8f26cbd9-5fd4-4e7a-9340-3592af5fbb61", false, "guest" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progres" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 30, 16, 17, 45, 496, DateTimeKind.Local).AddTicks(4588), "Learn using ASP.NET Core Identity", "4867274c-fad6-45d0-a399-890ba8014164", "Prepare for ASP.NET Fundamentals exam" },
                    { 2, 3, new DateTime(2022, 7, 30, 16, 17, 45, 496, DateTimeKind.Local).AddTicks(4640), "Learn using EF Core and MS SQL Server Management Studio", "4867274c-fad6-45d0-a399-890ba8014164", "ImproveEF Core skills" },
                    { 3, 2, new DateTime(2022, 12, 20, 16, 17, 45, 496, DateTimeKind.Local).AddTicks(4644), "Learn using ASP.NET Core Identity", "4867274c-fad6-45d0-a399-890ba8014164", "Improve ASP.NET Core skills" },
                    { 4, 3, new DateTime(2021, 12, 30, 16, 17, 45, 496, DateTimeKind.Local).AddTicks(4647), "Prepare by solving old Mid and Final exams", "4867274c-fad6-45d0-a399-890ba8014164", "Prepare for C# Fundamentals exam" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4867274c-fad6-45d0-a399-890ba8014164");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
