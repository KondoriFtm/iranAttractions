using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iranAttractions.Migrations
{
    /// <inheritdoc />
    public partial class add_picurl_to_comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "picurl",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "picurl",
                table: "Comment");
        }
    }
}
