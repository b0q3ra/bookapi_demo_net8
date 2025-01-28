using Microsoft.EntityFrameworkCore;

namespace BooksApi.Models {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }
        
        public DbSet<BookModel> books => Set<BookModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<BookModel>().HasKey(book => book.Id);
            modelBuilder.Entity<BookModel>()
                        .HasIndex(book => book.Name)
                        .IsUnique();
        }

    }
}