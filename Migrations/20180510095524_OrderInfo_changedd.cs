using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class OrderInfo_changedd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.AddColumn<string>(
                name: "PaymentFullName",
                table: "OrderInfo",
                nullable: true);

             migrationBuilder.AddColumn<string>(
                name: "PaymentExpirationYear",
                table: "OrderInfo",
                nullable: true);

             migrationBuilder.AddColumn<string>(
                name: "PaymentExpirationMonth",
                table: "OrderInfo",
                nullable: true);

             migrationBuilder.AddColumn<string>(
                name: "PaymentCardNumber",
                table: "OrderInfo",
                nullable: true);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
