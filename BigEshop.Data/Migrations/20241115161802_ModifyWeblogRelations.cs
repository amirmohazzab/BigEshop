using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyWeblogRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Weblogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Weblogs_UserId",
                table: "Weblogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weblogs_Users_UserId",
                table: "Weblogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weblogs_Users_UserId",
                table: "Weblogs");

            migrationBuilder.DropIndex(
                name: "IX_Weblogs_UserId",
                table: "Weblogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Weblogs");
        }
    }
}
