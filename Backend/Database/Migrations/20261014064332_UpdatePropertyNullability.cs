using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertyNullability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Word",
                table: "WordRef",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<List<string>>(
                name: "Tags",
                table: "WordRef",
                type: "text[]",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Sense",
                table: "Translations",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<List<string>>(
                name: "Glosses",
                table: "Sense",
                type: "text[]",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Sense",
                table: "Proverbs",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Word",
                table: "WordRef",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<List<string>>(
                name: "Tags",
                table: "WordRef",
                type: "text[]",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sense",
                table: "Translations",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<List<string>>(
                name: "Glosses",
                table: "Sense",
                type: "text[]",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sense",
                table: "Proverbs",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
