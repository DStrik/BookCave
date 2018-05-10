using BookCave.Data.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BookCave.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<BookRating> BookRatings { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthorConnection> BookAuthorConnections { get; set; }
        public DbSet<BookGenreConnection> BookGenreConnections { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        public DbSet<BooksInOrder> BooksInOrder { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderInfo> OrderInfo { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<FavBook> FavBooks { get; set; }
        public DbSet<AccountImage> AccountImages { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<ShippingBilling> ShippingBillingInfo { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<CoverImage> CoverImages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H16;Persist Security Info=False;User ID=VLN2_2018_H16_usr;Password=lushM@sk77;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                );
        }
    }
}