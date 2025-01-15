using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealWiseAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 15, 16, 32, 10, 813, DateTimeKind.Local).AddTicks(7665), new DateTime(2025, 1, 15, 16, 32, 10, 816, DateTimeKind.Local).AddTicks(461) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 15, 16, 32, 10, 816, DateTimeKind.Local).AddTicks(698), new DateTime(2025, 1, 15, 16, 32, 10, 816, DateTimeKind.Local).AddTicks(704) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 15, 16, 30, 52, 615, DateTimeKind.Local).AddTicks(2531), new DateTime(2025, 1, 15, 16, 30, 52, 617, DateTimeKind.Local).AddTicks(5307) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 15, 16, 30, 52, 617, DateTimeKind.Local).AddTicks(5560), new DateTime(2025, 1, 15, 16, 30, 52, 617, DateTimeKind.Local).AddTicks(5566) });
        }
    }
}
