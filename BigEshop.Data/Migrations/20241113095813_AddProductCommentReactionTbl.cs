using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCommentReactionTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCommentReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ProductCommentId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCommentReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCommentReactions_ProductComments_ProductCommentId",
                        column: x => x.ProductCommentId,
                        principalTable: "ProductComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCommentReactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeblogCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeblogCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weblog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    WeblogCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weblog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weblog_WeblogCategory_WeblogCategoryId",
                        column: x => x.WeblogCategoryId,
                        principalTable: "WeblogCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeblogComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeblogId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeblogComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeblogComment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeblogComment_Weblog_WeblogId",
                        column: x => x.WeblogId,
                        principalTable: "Weblog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCommentReactions_ProductCommentId",
                table: "ProductCommentReactions",
                column: "ProductCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCommentReactions_UserId",
                table: "ProductCommentReactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Weblog_WeblogCategoryId",
                table: "Weblog",
                column: "WeblogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WeblogComment_UserId",
                table: "WeblogComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeblogComment_WeblogId",
                table: "WeblogComment",
                column: "WeblogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCommentReactions");

            migrationBuilder.DropTable(
                name: "WeblogComment");

            migrationBuilder.DropTable(
                name: "Weblog");

            migrationBuilder.DropTable(
                name: "WeblogCategory");
        }
    }
}
