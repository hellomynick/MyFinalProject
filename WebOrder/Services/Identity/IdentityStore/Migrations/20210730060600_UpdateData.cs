using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityStore.Migrations
{
    public partial class UpdateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Palace",
                table: "AspNetUsers");

            migrationBuilder.CreateSequence(
                name: "store_palace_hilo",
                incrementBy: 10);

            migrationBuilder.AddColumn<int>(
                name: "StorePalaceId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StorePalace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorePalace", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StorePalaceId",
                table: "AspNetUsers",
                column: "StorePalaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StorePalace_StorePalaceId",
                table: "AspNetUsers",
                column: "StorePalaceId",
                principalTable: "StorePalace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StorePalace_StorePalaceId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "StorePalace");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StorePalaceId",
                table: "AspNetUsers");

            migrationBuilder.DropSequence(
                name: "store_palace_hilo");

            migrationBuilder.DropColumn(
                name: "StorePalaceId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Palace",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
