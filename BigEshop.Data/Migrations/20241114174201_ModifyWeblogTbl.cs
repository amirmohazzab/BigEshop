using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyWeblogTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weblogs_WeblogCategories_WeblogCategoryId",
                table: "Weblogs");

            migrationBuilder.DropIndex(
                name: "IX_Weblogs_WeblogCategoryId",
                table: "Weblogs");

            migrationBuilder.DropColumn(
                name: "WeblogCategoryId",
                table: "Weblogs");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Weblogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Weblogs_CategoryId",
                table: "Weblogs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weblogs_WeblogCategories_CategoryId",
                table: "Weblogs",
                column: "CategoryId",
                principalTable: "WeblogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weblogs_WeblogCategories_CategoryId",
                table: "Weblogs");

            migrationBuilder.DropIndex(
                name: "IX_Weblogs_CategoryId",
                table: "Weblogs");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Weblogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WeblogCategoryId",
                table: "Weblogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Weblogs_WeblogCategoryId",
                table: "Weblogs",
                column: "WeblogCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weblogs_WeblogCategories_WeblogCategoryId",
                table: "Weblogs",
                column: "WeblogCategoryId",
                principalTable: "WeblogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
