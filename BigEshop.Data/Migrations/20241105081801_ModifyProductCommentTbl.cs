using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyProductCommentTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ProductComments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ProductComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
