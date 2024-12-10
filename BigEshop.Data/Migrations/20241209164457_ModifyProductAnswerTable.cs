using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyProductAnswerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAnswers_ProductQuestions_ProductQuestionId",
                table: "ProductAnswers");

            migrationBuilder.DropIndex(
                name: "IX_ProductAnswers_ProductQuestionId",
                table: "ProductAnswers");

            migrationBuilder.DropColumn(
                name: "ProductQuestionId",
                table: "ProductAnswers");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAnswers_QuestionId",
                table: "ProductAnswers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAnswers_ProductQuestions_QuestionId",
                table: "ProductAnswers",
                column: "QuestionId",
                principalTable: "ProductQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAnswers_ProductQuestions_QuestionId",
                table: "ProductAnswers");

            migrationBuilder.DropIndex(
                name: "IX_ProductAnswers_QuestionId",
                table: "ProductAnswers");

            migrationBuilder.AddColumn<int>(
                name: "ProductQuestionId",
                table: "ProductAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAnswers_ProductQuestionId",
                table: "ProductAnswers",
                column: "ProductQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAnswers_ProductQuestions_ProductQuestionId",
                table: "ProductAnswers",
                column: "ProductQuestionId",
                principalTable: "ProductQuestions",
                principalColumn: "Id");
        }
    }
}
