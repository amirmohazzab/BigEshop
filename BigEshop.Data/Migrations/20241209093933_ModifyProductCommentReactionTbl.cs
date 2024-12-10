using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyProductCommentReactionTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCommentReactions_ProductComments_ProductCommentId",
                table: "ProductCommentReactions");

            migrationBuilder.DropIndex(
                name: "IX_ProductCommentReactions_ProductCommentId",
                table: "ProductCommentReactions");

            migrationBuilder.DropColumn(
                name: "ProductCommentId",
                table: "ProductCommentReactions");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCommentReactions_CommentId",
                table: "ProductCommentReactions",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCommentReactions_ProductComments_CommentId",
                table: "ProductCommentReactions",
                column: "CommentId",
                principalTable: "ProductComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCommentReactions_ProductComments_CommentId",
                table: "ProductCommentReactions");

            migrationBuilder.DropIndex(
                name: "IX_ProductCommentReactions_CommentId",
                table: "ProductCommentReactions");

            migrationBuilder.AddColumn<int>(
                name: "ProductCommentId",
                table: "ProductCommentReactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCommentReactions_ProductCommentId",
                table: "ProductCommentReactions",
                column: "ProductCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCommentReactions_ProductComments_ProductCommentId",
                table: "ProductCommentReactions",
                column: "ProductCommentId",
                principalTable: "ProductComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
