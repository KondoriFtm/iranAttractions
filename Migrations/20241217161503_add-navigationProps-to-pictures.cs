using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iranAttractions.Migrations
{
    /// <inheritdoc />
    public partial class addnavigationPropstopictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserPhonenumber",
                table: "Pictures",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_SightseeingId",
                table: "Pictures",
                column: "SightseeingId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_UserPhonenumber",
                table: "Pictures",
                column: "UserPhonenumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_User_UserPhonenumber",
                table: "Pictures",
                column: "UserPhonenumber",
                principalTable: "User",
                principalColumn: "Phonenumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_sightseeing_SightseeingId",
                table: "Pictures",
                column: "SightseeingId",
                principalTable: "sightseeing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_User_UserPhonenumber",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_sightseeing_SightseeingId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_SightseeingId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_UserPhonenumber",
                table: "Pictures");

            migrationBuilder.AlterColumn<string>(
                name: "UserPhonenumber",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
