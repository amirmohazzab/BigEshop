using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyContactTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnswerUserId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AnswerUserId",
                table: "Contacts",
                column: "AnswerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_AnswerUserId",
                table: "Contacts",
                column: "AnswerUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_AnswerUserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AnswerUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "AnswerUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Ip",
                table: "Contacts");
        }
    }
}
