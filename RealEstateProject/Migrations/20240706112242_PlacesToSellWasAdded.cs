using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateProject.Migrations
{
    /// <inheritdoc />
    public partial class PlacesToSellWasAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlacesToBuy_Houses_HouseId",
                table: "PlacesToBuy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlacesToBuy",
                table: "PlacesToBuy");

            migrationBuilder.RenameTable(
                name: "PlacesToBuy",
                newName: "PlacesToSell");

            migrationBuilder.RenameIndex(
                name: "IX_PlacesToBuy_HouseId",
                table: "PlacesToSell",
                newName: "IX_PlacesToSell_HouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlacesToSell",
                table: "PlacesToSell",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacesToSell_Houses_HouseId",
                table: "PlacesToSell",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlacesToSell_Houses_HouseId",
                table: "PlacesToSell");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlacesToSell",
                table: "PlacesToSell");

            migrationBuilder.RenameTable(
                name: "PlacesToSell",
                newName: "PlacesToBuy");

            migrationBuilder.RenameIndex(
                name: "IX_PlacesToSell_HouseId",
                table: "PlacesToBuy",
                newName: "IX_PlacesToBuy_HouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlacesToBuy",
                table: "PlacesToBuy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacesToBuy_Houses_HouseId",
                table: "PlacesToBuy",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
