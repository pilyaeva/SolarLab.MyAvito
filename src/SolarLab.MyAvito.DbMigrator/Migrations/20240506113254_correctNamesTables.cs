using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarLab.MyAvito.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class correctNamesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "file");

            migrationBuilder.RenameTable(
                name: "Advertisements",
                newName: "advertisement");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "file",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Length",
                table: "file",
                newName: "length");

            migrationBuilder.RenameColumn(
                name: "ContentType",
                table: "file",
                newName: "contentType");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "file",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "file",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "advertisement",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "advertisement",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "advertisement",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Condition",
                table: "advertisement",
                newName: "condition");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "advertisement",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "file",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "contentType",
                table: "file",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "advertisement",
                type: "character varying(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "advertisement",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "condition",
                table: "advertisement",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_file",
                table: "file",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_advertisement",
                table: "advertisement",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_file",
                table: "file");

            migrationBuilder.DropPrimaryKey(
                name: "PK_advertisement",
                table: "advertisement");

            migrationBuilder.RenameTable(
                name: "file",
                newName: "Files");

            migrationBuilder.RenameTable(
                name: "advertisement",
                newName: "Advertisements");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Files",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "length",
                table: "Files",
                newName: "Length");

            migrationBuilder.RenameColumn(
                name: "contentType",
                table: "Files",
                newName: "ContentType");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Files",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Files",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Advertisements",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Advertisements",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Advertisements",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "condition",
                table: "Advertisements",
                newName: "Condition");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Advertisements",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Files",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                table: "Files",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Advertisements",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(70)",
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Advertisements",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Condition",
                table: "Advertisements",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements",
                column: "Id");
        }
    }
}
