using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_travel_agency.Migrations
{
    public partial class ModifyMessagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageTravelPackage");

            migrationBuilder.AddColumn<int>(
                name: "TravelPackageId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TravelPackageId",
                table: "Messages",
                column: "TravelPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_TravelPackages_TravelPackageId",
                table: "Messages",
                column: "TravelPackageId",
                principalTable: "TravelPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_TravelPackages_TravelPackageId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_TravelPackageId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "TravelPackageId",
                table: "Messages");

            migrationBuilder.CreateTable(
                name: "MessageTravelPackage",
                columns: table => new
                {
                    messagesId = table.Column<int>(type: "int", nullable: false),
                    packagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTravelPackage", x => new { x.messagesId, x.packagesId });
                    table.ForeignKey(
                        name: "FK_MessageTravelPackage_Messages_messagesId",
                        column: x => x.messagesId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageTravelPackage_TravelPackages_packagesId",
                        column: x => x.packagesId,
                        principalTable: "TravelPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageTravelPackage_packagesId",
                table: "MessageTravelPackage",
                column: "packagesId");
        }
    }
}
