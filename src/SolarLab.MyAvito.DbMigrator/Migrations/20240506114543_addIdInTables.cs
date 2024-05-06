using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarLab.MyAvito.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class addIdInTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "advertisementId",
                table: "file",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "advertisement",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "advertisementId",
                table: "file");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "advertisement");
        }
    }
}
