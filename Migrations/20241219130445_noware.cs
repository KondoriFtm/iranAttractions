using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iranAttractions.Migrations
{
    /// <inheritdoc />
    public partial class noware : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "lat",
                table: "sightseeing",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "lon",
                table: "sightseeing",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lat",
                table: "sightseeing");

            migrationBuilder.DropColumn(
                name: "lon",
                table: "sightseeing");
        }
    }
}
