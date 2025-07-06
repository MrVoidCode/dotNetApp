using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleApi.Migrations
{
    /// <inheritdoc />
    public partial class Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointOfInterest_Cities_CityId",
                table: "PointOfInterest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PointOfInterest",
                table: "PointOfInterest");

            migrationBuilder.RenameTable(
                name: "PointOfInterest",
                newName: "PointOfInterests");

            migrationBuilder.RenameIndex(
                name: "IX_PointOfInterest_CityId",
                table: "PointOfInterests",
                newName: "IX_PointOfInterests_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PointOfInterests",
                table: "PointOfInterests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PointOfInterests_Cities_CityId",
                table: "PointOfInterests",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointOfInterests_Cities_CityId",
                table: "PointOfInterests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PointOfInterests",
                table: "PointOfInterests");

            migrationBuilder.RenameTable(
                name: "PointOfInterests",
                newName: "PointOfInterest");

            migrationBuilder.RenameIndex(
                name: "IX_PointOfInterests_CityId",
                table: "PointOfInterest",
                newName: "IX_PointOfInterest_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PointOfInterest",
                table: "PointOfInterest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PointOfInterest_Cities_CityId",
                table: "PointOfInterest",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
