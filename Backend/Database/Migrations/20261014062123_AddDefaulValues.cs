using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaulValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RelatedWord",
                table: "RelatedWord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DerivedWord",
                table: "DerivedWord");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelatedWord",
                table: "RelatedWord",
                column: "RelatedWordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DerivedWord",
                table: "DerivedWord",
                column: "DerivedWordId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedWord_EntryId",
                table: "RelatedWord",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_DerivedWord_EntryId",
                table: "DerivedWord",
                column: "EntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RelatedWord",
                table: "RelatedWord");

            migrationBuilder.DropIndex(
                name: "IX_RelatedWord_EntryId",
                table: "RelatedWord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DerivedWord",
                table: "DerivedWord");

            migrationBuilder.DropIndex(
                name: "IX_DerivedWord_EntryId",
                table: "DerivedWord");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelatedWord",
                table: "RelatedWord",
                column: "EntryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DerivedWord",
                table: "DerivedWord",
                column: "EntryId");
        }
    }
}
