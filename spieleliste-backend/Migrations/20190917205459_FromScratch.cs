using Microsoft.EntityFrameworkCore.Migrations;

namespace spieleliste_backend.Migrations
{
    public partial class FromScratch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    ListEntryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEntries_ListEntries_ListEntryId",
                        column: x => x.ListEntryId,
                        principalTable: "ListEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEntries");

            migrationBuilder.DropTable(
                name: "ListEntries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
