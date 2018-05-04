﻿// <auto-generated />
using BookCave.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BookCave.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180504125809_PaymentsTable_added")]
    partial class PaymentsTable_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookCave.Data.EntityModels.AudioBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("Isbn");

                    b.HasKey("Id");

                    b.ToTable("AudioBooks");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GenreId");

                    b.Property<int>("PublisherId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.BookAuthorConnection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<int>("BookId");

                    b.HasKey("Id");

                    b.ToTable("BookAuthorConnections");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.BookDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("BookDescriptions");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.BookReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("Grade");

                    b.Property<string>("Review");

                    b.HasKey("Id");

                    b.ToTable("BookReviews");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.EBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("Isbn");

                    b.Property<double>("Price");

                    b.Property<int>("PublishingYear");

                    b.HasKey("Id");

                    b.ToTable("EBooks");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.FavBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("FavBooks");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.HardCover", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<string>("Font");

                    b.Property<int>("Isbn");

                    b.Property<int>("PageCount");

                    b.Property<double>("Price");

                    b.Property<int>("PublishingYear");

                    b.HasKey("Id");

                    b.ToTable("HardCovers");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfPurchase");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.OrderBooksConnection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("OrderId");

                    b.HasKey("Id");

                    b.ToTable("OrderBooksConnection");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.OrderInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OrderId");

                    b.Property<int?>("ShippingBillingInformationId");

                    b.HasKey("Id");

                    b.HasIndex("ShippingBillingInformationId");

                    b.ToTable("OrderInfo");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.PaperBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<string>("Font");

                    b.Property<int>("Isbn");

                    b.Property<int>("PageCount");

                    b.Property<double>("Price");

                    b.Property<int>("PublishingYear");

                    b.HasKey("Id");

                    b.ToTable("PaperBacks");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CardNumber");

                    b.Property<int>("Cvc");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<string>("FullName");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.ProfileImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Img");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ProfileImages");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.ShippingBilling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BillingCity");

                    b.Property<string>("BillingCounry");

                    b.Property<string>("BillingFirstName");

                    b.Property<int>("BillingHouseNumber");

                    b.Property<string>("BillingLastName");

                    b.Property<string>("BillingStreetName");

                    b.Property<string>("BillingZipCode");

                    b.Property<string>("ShippingCity");

                    b.Property<string>("ShippingCountry");

                    b.Property<string>("ShippingFirstName");

                    b.Property<int>("ShippingHouseNumber");

                    b.Property<string>("ShippingLastName");

                    b.Property<string>("ShippingStreetName");

                    b.Property<string>("ShippingZipCode");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ShippingBillingInfo");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookTypeId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookCave.Models.ViewModels.ShippingBillingViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BillingCity");

                    b.Property<string>("BillingCountry");

                    b.Property<string>("BillingFirstName");

                    b.Property<int>("BillingHouseNumber");

                    b.Property<string>("BillingLastName");

                    b.Property<string>("BillingStreetName");

                    b.Property<string>("BillingZipCode");

                    b.Property<string>("ShippingCity");

                    b.Property<string>("ShippingCountry");

                    b.Property<string>("ShippingFirstName");

                    b.Property<int>("ShippingHouseNumber");

                    b.Property<string>("ShippingLastName");

                    b.Property<string>("ShippingStreetName");

                    b.Property<string>("ShippingZipCode");

                    b.HasKey("Id");

                    b.ToTable("ShippingBillingViewModel");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.OrderInfo", b =>
                {
                    b.HasOne("BookCave.Models.ViewModels.ShippingBillingViewModel", "ShippingBillingInformation")
                        .WithMany()
                        .HasForeignKey("ShippingBillingInformationId");
                });
#pragma warning restore 612, 618
        }
    }
}
