﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageWikiBlockUser");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "PageWikiBlocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PageWikiBlocks_AuthorId",
                table: "PageWikiBlocks",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PageWikiBlocks_Users_AuthorId",
                table: "PageWikiBlocks",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageWikiBlocks_Users_AuthorId",
                table: "PageWikiBlocks");

            migrationBuilder.DropIndex(
                name: "IX_PageWikiBlocks_AuthorId",
                table: "PageWikiBlocks");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "PageWikiBlocks");

            migrationBuilder.CreateTable(
                name: "PageWikiBlockUser",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BlocksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageWikiBlockUser", x => new { x.AuthorsId, x.BlocksId });
                    table.ForeignKey(
                        name: "FK_PageWikiBlockUser_PageWikiBlocks_BlocksId",
                        column: x => x.BlocksId,
                        principalTable: "PageWikiBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageWikiBlockUser_Users_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageWikiBlockUser_BlocksId",
                table: "PageWikiBlockUser",
                column: "BlocksId");
        }
    }
}
