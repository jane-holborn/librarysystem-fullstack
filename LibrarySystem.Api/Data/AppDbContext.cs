using Microsoft.EntityFrameworkCore;
using LibrarySystem.Api.Models;

namespace LibrarySystem.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure Book entity
            modelBuilder.Entity<Book>()
                .HasKey(b => b.LibraryReferenceNumber);
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<Book>()
                .Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Book>()
                .Property(b => b.LibraryReferenceNumber)
                .IsRequired()
                .HasMaxLength(13);
            modelBuilder.Entity<Book>()
                .HasIndex(b => b.LibraryReferenceNumber)
                .IsUnique();
            modelBuilder.Entity<Book>()
                .Property(b => b.PublicationYear)
                .IsRequired()
                .HasMaxLength(4);
            // Configure User entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(u => u.UserLibraryNumber)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserLibraryNumber)
                .IsUnique();
            // Temporary seeding to test the application
            modelBuilder.Entity<User>()
                .HasData(new User { Id = "1", Name = "John Doe", Email = "johndoe@email.com", UserLibraryNumber = "LIB12345", NumberOfBooksBorrowed = 0 },
                          new User { Id = "2", Name = "Jane Smith", Email = "janesmith@email.com", UserLibraryNumber = "LIB67890", NumberOfBooksBorrowed = 0 });
            // Configure Staff entity
            modelBuilder.Entity<Staff>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Staff>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Staff>()
                .Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Staff>()
                .Property(s => s.EmployeeId)
                .IsRequired()
                .HasMaxLength(12);
            modelBuilder.Entity<Staff>()
                .HasIndex(s => s.EmployeeId)
                .IsUnique();
        }
    }
}
