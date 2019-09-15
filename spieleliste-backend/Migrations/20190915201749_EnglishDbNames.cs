using Microsoft.EntityFrameworkCore.Migrations;

namespace spieleliste_backend.Migrations
{
    public partial class EnglishDbNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEintraege");

            migrationBuilder.DropTable(
                name: "ListenEintraege");

            migrationBuilder.CreateTable(
                name: "ListEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpielId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    ListenEintragId = table.Column<int>(nullable: false),
                    ListEntryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEntries_ListEntries_ListEntryId",
                        column: x => x.ListEntryId,
                        principalTable: "ListEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserEntries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListEntries_SpielId",
                table: "ListEntries",
                column: "SpielId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEntries_ListEntryId",
                table: "UserEntries",
                column: "ListEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEntries_UserId",
                table: "UserEntries",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEntries");

            migrationBuilder.DropTable(
                name: "ListEntries");

            migrationBuilder.CreateTable(
                name: "ListenEintraege",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpielId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenEintraege", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEintraege",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ListenEintragId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEintraege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEintraege_ListenEintraege_ListenEintragId",
                        column: x => x.ListenEintragId,
                        principalTable: "ListenEintraege",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEintraege_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListenEintraege_SpielId",
                table: "ListenEintraege",
                column: "SpielId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEintraege_ListenEintragId",
                table: "UserEintraege",
                column: "ListenEintragId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEintraege_UserId",
                table: "UserEintraege",
                column: "UserId");
        }
    }
}
