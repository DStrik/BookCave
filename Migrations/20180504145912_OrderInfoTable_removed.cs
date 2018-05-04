using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class OrderInfoTable_removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.CreateTable(
                name: "OrderInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillingCity = table.Column<string>(nullable: true),
                    BillingCounry = table.Column<string>(nullable: true),
                    BillingFirstName = table.Column<string>(nullable: true),
                    BillingHouseNumber = table.Column<int>(nullable: false),
                    BillingLastName = table.Column<string>(nullable: true),
                    BillingStreetName = table.Column<string>(nullable: true),
                    BillingZipCode = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    ShippingCity = table.Column<string>(nullable: true),
                    ShippingCountry = table.Column<string>(nullable: true),
                    ShippingFirstName = table.Column<string>(nullable: true),
                    ShippingHouseNumber = table.Column<int>(nullable: false),
                    ShippingLastName = table.Column<string>(nullable: true),
                    ShippingStreetName = table.Column<string>(nullable: true),
                    ShippingZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
