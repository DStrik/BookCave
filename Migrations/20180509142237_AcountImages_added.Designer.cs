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
    [Migration("20180509142237_AcountImages_added")]
    partial class AcountImages_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("Isbn");

                    b.Property<double>("Price");

                    b.Property<int>("PublisherId");

                    b.Property<int>("PublishingYear");

                    b.Property<string>("Title");

                    b.Property<string>("Type");

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

            modelBuilder.Entity("BookCave.Data.EntityModels.BookDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<string>("Description");

                    b.Property<string>("Font");

                    b.Property<int>("Length");

                    b.Property<int>("PageCount");

                    b.HasKey("Id");

                    b.ToTable("BookDetails");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.BookGenreConnection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("GenreId");

                    b.HasKey("Id");

                    b.ToTable("BookGenreConnections");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.BookReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("Grade");

                    b.Property<string>("Review");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("BookReviews");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("Quantity");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.CoverImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<byte[]>("Img");

                    b.HasKey("Id");

                    b.ToTable("CoverImages");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.FavBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<string>("UserId");

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

            modelBuilder.Entity("BookCave.Data.EntityModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfPurchase");

                    b.Property<string>("UserId");

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

                    b.Property<string>("BillingCity");

                    b.Property<string>("BillingCounry");

                    b.Property<string>("BillingFirstName");

                    b.Property<int>("BillingHouseNumber");

                    b.Property<string>("BillingLastName");

                    b.Property<string>("BillingStreetName");

                    b.Property<string>("BillingZipCode");

                    b.Property<int>("OrderId");

                    b.Property<string>("ShippingCity");

                    b.Property<string>("ShippingCountry");

                    b.Property<string>("ShippingFirstName");

                    b.Property<int>("ShippingHouseNumber");

                    b.Property<string>("ShippingLastName");

                    b.Property<string>("ShippingStreetName");

                    b.Property<string>("ShippingZipCode");

                    b.HasKey("Id");

                    b.ToTable("OrderInfo");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardNumber");

                    b.Property<string>("Cvc");

                    b.Property<string>("ExpirationMonth");

                    b.Property<string>("ExpirationYear");

                    b.Property<string>("FullName");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.ProfileImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Img");

                    b.Property<string>("UserId");

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

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ShippingBillingInfo");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
