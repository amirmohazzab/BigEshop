using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWeblogAndWeblogCategoryAndWeblogCommentTbls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weblog_WeblogCategory_WeblogCategoryId",
                table: "Weblog");

            migrationBuilder.DropForeignKey(
                name: "FK_WeblogComment_Users_UserId",
                table: "WeblogComment");

            migrationBuilder.DropForeignKey(
                name: "FK_WeblogComment_Weblog_WeblogId",
                table: "WeblogComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeblogComment",
                table: "WeblogComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeblogCategory",
                table: "WeblogCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weblog",
                table: "Weblog");

            migrationBuilder.RenameTable(
                name: "WeblogComment",
                newName: "WeblogComments");

            migrationBuilder.RenameTable(
                name: "WeblogCategory",
                newName: "WeblogCategories");

            migrationBuilder.RenameTable(
                name: "Weblog",
                newName: "Weblogs");

            migrationBuilder.RenameIndex(
                name: "IX_WeblogComment_WeblogId",
                table: "WeblogComments",
                newName: "IX_WeblogComments_WeblogId");

            migrationBuilder.RenameIndex(
                name: "IX_WeblogComment_UserId",
                table: "WeblogComments",
                newName: "IX_WeblogComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Weblog_WeblogCategoryId",
                table: "Weblogs",
                newName: "IX_Weblogs_WeblogCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeblogComments",
                table: "WeblogComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeblogCategories",
                table: "WeblogCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weblogs",
                table: "Weblogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeblogComments_Users_UserId",
                table: "WeblogComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeblogComments_Weblogs_WeblogId",
                table: "WeblogComments",
                column: "WeblogId",
                principalTable: "Weblogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weblogs_WeblogCategories_WeblogCategoryId",
                table: "Weblogs",
                column: "WeblogCategoryId",
                principalTable: "WeblogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeblogComments_Users_UserId",
                table: "WeblogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_WeblogComments_Weblogs_WeblogId",
                table: "WeblogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Weblogs_WeblogCategories_WeblogCategoryId",
                table: "Weblogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weblogs",
                table: "Weblogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeblogComments",
                table: "WeblogComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeblogCategories",
                table: "WeblogCategories");

            migrationBuilder.RenameTable(
                name: "Weblogs",
                newName: "Weblog");

            migrationBuilder.RenameTable(
                name: "WeblogComments",
                newName: "WeblogComment");

            migrationBuilder.RenameTable(
                name: "WeblogCategories",
                newName: "WeblogCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Weblogs_WeblogCategoryId",
                table: "Weblog",
                newName: "IX_Weblog_WeblogCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_WeblogComments_WeblogId",
                table: "WeblogComment",
                newName: "IX_WeblogComment_WeblogId");

            migrationBuilder.RenameIndex(
                name: "IX_WeblogComments_UserId",
                table: "WeblogComment",
                newName: "IX_WeblogComment_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weblog",
                table: "Weblog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeblogComment",
                table: "WeblogComment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeblogCategory",
                table: "WeblogCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weblog_WeblogCategory_WeblogCategoryId",
                table: "Weblog",
                column: "WeblogCategoryId",
                principalTable: "WeblogCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeblogComment_Users_UserId",
                table: "WeblogComment",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeblogComment_Weblog_WeblogId",
                table: "WeblogComment",
                column: "WeblogId",
                principalTable: "Weblog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
