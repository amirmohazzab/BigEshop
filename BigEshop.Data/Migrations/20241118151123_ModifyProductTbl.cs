using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyProductTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductCommentReactions_ProductId",
                table: "ProductCommentReactions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAnswers_ProductId",
                table: "ProductAnswers",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAnswers_Products_ProductId",
                table: "ProductAnswers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCommentReactions_Products_ProductId",
                table: "ProductCommentReactions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAnswers_Products_ProductId",
                table: "ProductAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCommentReactions_Products_ProductId",
                table: "ProductCommentReactions");

            migrationBuilder.DropIndex(
                name: "IX_ProductCommentReactions_ProductId",
                table: "ProductCommentReactions");

            migrationBuilder.DropIndex(
                name: "IX_ProductAnswers_ProductId",
                table: "ProductAnswers");
        }
    }
}
