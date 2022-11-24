using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class entitesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDateBase",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "CreationDateBase",
                table: "Categories");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Things",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 14, 36, 46, 106, DateTimeKind.Utc).AddTicks(5493));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 14, 36, 46, 106, DateTimeKind.Utc).AddTicks(5222));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Categories");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateBase",
                table: "Things",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 0, 1, 42, 647, DateTimeKind.Utc).AddTicks(2861));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateBase",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 24, 0, 1, 42, 647, DateTimeKind.Utc).AddTicks(2562));
        }
    }
}
