using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iranAttractions.Migrations
{
    /// <inheritdoc />
    public partial class addparttosightseeing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_sightseeing_SightseeingId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_SightseeingId",
                table: "Picture");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Part_SightseeingId",
                table: "Part",
                column: "SightseeingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Part_sightseeing_SightseeingId",
                table: "Part",
                column: "SightseeingId",
                principalTable: "sightseeing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Part_sightseeing_SightseeingId",
                table: "Part");

            migrationBuilder.DropIndex(
                name: "IX_Part_SightseeingId",
                table: "Part");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_SightseeingId",
                table: "Picture",
                column: "SightseeingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_sightseeing_SightseeingId",
                table: "Picture",
                column: "SightseeingId",
                principalTable: "sightseeing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
