using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyProductAnswerReactionTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAnswerReactions_ProductAnswers_ProductAnswerId",
                table: "ProductAnswerReactions");

            migrationBuilder.DropIndex(
                name: "IX_ProductAnswerReactions_ProductAnswerId",
                table: "ProductAnswerReactions");

            migrationBuilder.DropColumn(
                name: "ProductAnswerId",
                table: "ProductAnswerReactions");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAnswerReactions_AnswerId",
                table: "ProductAnswerReactions",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAnswerReactions_ProductAnswers_AnswerId",
                table: "ProductAnswerReactions",
                column: "AnswerId",
                principalTable: "ProductAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAnswerReactions_ProductAnswers_AnswerId",
                table: "ProductAnswerReactions");

            migrationBuilder.DropIndex(
                name: "IX_ProductAnswerReactions_AnswerId",
                table: "ProductAnswerReactions");

            migrationBuilder.AddColumn<int>(
                name: "ProductAnswerId",
                table: "ProductAnswerReactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAnswerReactions_ProductAnswerId",
                table: "ProductAnswerReactions",
                column: "ProductAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAnswerReactions_ProductAnswers_ProductAnswerId",
                table: "ProductAnswerReactions",
                column: "ProductAnswerId",
                principalTable: "ProductAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
