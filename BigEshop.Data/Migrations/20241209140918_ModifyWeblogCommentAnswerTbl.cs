using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyWeblogCommentAnswerTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeblogCommentAnswers_WeblogComments_WeblogCommentId",
                table: "WeblogCommentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_WeblogCommentAnswers_WeblogCommentId",
                table: "WeblogCommentAnswers");

            migrationBuilder.DropColumn(
                name: "WeblogCommentId",
                table: "WeblogCommentAnswers");

            migrationBuilder.CreateIndex(
                name: "IX_WeblogCommentAnswers_CommentId",
                table: "WeblogCommentAnswers",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAnswerReactions_ProductId",
                table: "ProductAnswerReactions",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAnswerReactions_Products_ProductId",
                table: "ProductAnswerReactions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeblogCommentAnswers_WeblogComments_CommentId",
                table: "WeblogCommentAnswers",
                column: "CommentId",
                principalTable: "WeblogComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAnswerReactions_Products_ProductId",
                table: "ProductAnswerReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_WeblogCommentAnswers_WeblogComments_CommentId",
                table: "WeblogCommentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_WeblogCommentAnswers_CommentId",
                table: "WeblogCommentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_ProductAnswerReactions_ProductId",
                table: "ProductAnswerReactions");

            migrationBuilder.AddColumn<int>(
                name: "WeblogCommentId",
                table: "WeblogCommentAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WeblogCommentAnswers_WeblogCommentId",
                table: "WeblogCommentAnswers",
                column: "WeblogCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeblogCommentAnswers_WeblogComments_WeblogCommentId",
                table: "WeblogCommentAnswers",
                column: "WeblogCommentId",
                principalTable: "WeblogComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
