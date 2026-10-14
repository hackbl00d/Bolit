using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Word = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LangCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Lang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Pos = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PosTitle = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Categories = table.Column<List<string>>(type: "text[]", maxLength: 200, nullable: false),
                    Tags = table.Column<List<string>>(type: "text[]", nullable: false),
                    EtymologyTexts = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.EntryId);
                });

            migrationBuilder.CreateTable(
                name: "WordRef",
                columns: table => new
                {
                    Word = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Tags = table.Column<List<string>>(type: "text[]", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "DerivedWord",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DerivedWordId = table.Column<Guid>(type: "uuid", nullable: false),
                    Word = table.Column<string>(type: "text", nullable: true),
                    Tags = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DerivedWord", x => x.EntryId);
                    table.ForeignKey(
                        name: "FK_DerivedWord_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    FormId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Tags = table.Column<List<string>>(type: "text[]", maxLength: 200, nullable: false),
                    RawTags = table.Column<List<string>>(type: "text[]", maxLength: 200, nullable: true),
                    Source = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    EntryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.FormId);
                    table.ForeignKey(
                        name: "FK_Form_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hyphenation",
                columns: table => new
                {
                    HyphenationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Parts = table.Column<List<string>>(type: "text[]", maxLength: 200, nullable: false),
                    EntryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hyphenation", x => x.HyphenationId);
                    table.ForeignKey(
                        name: "FK_Hyphenation_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proverbs",
                columns: table => new
                {
                    ProverbId = table.Column<Guid>(type: "uuid", nullable: false),
                    Phrase = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Sense = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    EntryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proverbs", x => x.ProverbId);
                    table.ForeignKey(
                        name: "FK_Proverbs_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedWord",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(type: "uuid", nullable: false),
                    RelatedWordId = table.Column<Guid>(type: "uuid", nullable: false),
                    Word = table.Column<string>(type: "text", nullable: true),
                    Tags = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedWord", x => x.EntryId);
                    table.ForeignKey(
                        name: "FK_RelatedWord_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sense",
                columns: table => new
                {
                    SenseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Glosses = table.Column<List<string>>(type: "text[]", maxLength: 200, nullable: false),
                    RawTags = table.Column<List<string>>(type: "text[]", maxLength: 200, nullable: false),
                    EntryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sense", x => x.SenseId);
                    table.ForeignKey(
                        name: "FK_Sense_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sound",
                columns: table => new
                {
                    SoundId = table.Column<Guid>(type: "uuid", nullable: false),
                    Ipa = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    EntryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sound", x => x.SoundId);
                    table.ForeignKey(
                        name: "FK_Sound_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Synonyms",
                columns: table => new
                {
                    SynonymId = table.Column<Guid>(type: "uuid", nullable: false),
                    Word = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RawTags = table.Column<List<string>>(type: "text[]", maxLength: 200, nullable: true),
                    EntryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Synonyms", x => x.SynonymId);
                    table.ForeignKey(
                        name: "FK_Synonyms_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    TranslationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Word = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LangCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Lang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Sense = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Tags = table.Column<List<string>>(type: "text[]", maxLength: 200, nullable: true),
                    EntryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.TranslationId);
                    table.ForeignKey(
                        name: "FK_Translations_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Example",
                columns: table => new
                {
                    ExampleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BoldTextOffsets = table.Column<List<List<int>>>(type: "json", maxLength: 50, nullable: false),
                    Translation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Reference = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SenseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Example", x => x.ExampleId);
                    table.ForeignKey(
                        name: "FK_Example_Sense_SenseId",
                        column: x => x.SenseId,
                        principalTable: "Sense",
                        principalColumn: "SenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Example_SenseId",
                table: "Example",
                column: "SenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Form_EntryId",
                table: "Form",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Hyphenation_EntryId",
                table: "Hyphenation",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Proverbs_EntryId",
                table: "Proverbs",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sense_EntryId",
                table: "Sense",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sound_EntryId",
                table: "Sound",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Synonyms_EntryId",
                table: "Synonyms",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_EntryId",
                table: "Translations",
                column: "EntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DerivedWord");

            migrationBuilder.DropTable(
                name: "Example");

            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropTable(
                name: "Hyphenation");

            migrationBuilder.DropTable(
                name: "Proverbs");

            migrationBuilder.DropTable(
                name: "RelatedWord");

            migrationBuilder.DropTable(
                name: "Sound");

            migrationBuilder.DropTable(
                name: "Synonyms");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "WordRef");

            migrationBuilder.DropTable(
                name: "Sense");

            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
