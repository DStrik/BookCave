using BookCave.Data.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BookCave.Data
{
    public class DataContext : DbContext
    {
        public DbSet<AudioBook> AudioBooks { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthorConnection> BookAuthorConnections { get; set; }
        public DbSet<BookDescription> BookDescriptions { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        public DbSet<CartItem> CartItes { get; set; }
        public DbSet<EBook> EBooks { get; set; }
        public DbSet<FavBook> FavBooks { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<HardCover> HardCovers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBooksConnection> OrderBooksConnection { get; set; }
        public DbSet<OrderInfo> OrderInfo { get; set; }
        public DbSet<PaperBack> PaperBacks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProfileImage> ProfileImages { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<ShippingBilling> ShippingBillingInfo { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H16;Persist Security Info=False;User ID=VLN2_2018_H16_usr;Password=lushM@sk77;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                );
        }
    }
}