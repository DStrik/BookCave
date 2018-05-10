using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class UserIdColumnInBookReview_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OrderInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BookReviews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderInfo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookReviews");
        }
    }
}
