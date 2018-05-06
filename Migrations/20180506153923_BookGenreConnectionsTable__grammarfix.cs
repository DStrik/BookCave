using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class BookGenreConnectionsTable__grammarfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookGereConnections",
                table: "BookGereConnections");

            migrationBuilder.RenameTable(
                name: "BookGereConnections",
                newName: "BookGenreConnections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookGenreConnections",
                table: "BookGenreConnections",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookGenreConnections",
                table: "BookGenreConnections");

            migrationBuilder.RenameTable(
                name: "BookGenreConnections",
                newName: "BookGereConnections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookGereConnections",
                table: "BookGereConnections",
                column: "Id");
        }
    }
}
