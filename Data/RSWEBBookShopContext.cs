using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RSWEBBookShop.Areas.Identity.Data;
using RSWEBBookShop.Models;

namespace RSWEBBookShop.Data
{
    public class RSWEBBookShopContext : IdentityDbContext<RSWEBBookShopUser>
    {
        public RSWEBBookShopContext (DbContextOptions<RSWEBBookShopContext> options)
            : base(options)
        {
        }

        public DbSet<RSWEBBookShop.Models.Book> Book { get; set; } = default!;

        public DbSet<RSWEBBookShop.Models.Author> Author { get; set; } = default!;

        public DbSet<RSWEBBookShop.Models.Genre> Genre { get; set; } = default!;

        public DbSet<RSWEBBookShop.Models.Review> Review { get; set; } = default!;

        public DbSet<RSWEBBookShop.Models.UserBook> UserBook { get; set; } = default!;
        public DbSet<RSWEBBookShop.Models.BookGenre> BookGenre { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<BookGenre>()
            //    .HasOne<Book>(p => p.Book)
            //    .WithMany(p => p.Genres)
            //    .HasForeignKey(p => p.BookId);

            //modelBuilder.Entity<BookGenre>()
            //    .HasOne<Genre>(p => p.Genre)
            //    .WithMany(p => p.Books)
            //    .HasForeignKey(p => p.GenreId);

            //modelBuilder.Entity<Book>()
            //    .HasOne<Author>(p => p.Author)
            //    .WithMany(p => p.Books)
            //    .HasForeignKey(p => p.AuthorId);

            //modelBuilder.Entity<Review>()
            //    .HasOne<Book>(p => p.Book)
            //    .WithMany(p => p.Reviews)
            //    .HasForeignKey(p => p.BookId);

            //modelBuilder.Entity<UserBook>()
            //    .HasOne<Book>(p => p.Book)
            //    .WithMany(p => p.Users)
            //    .HasForeignKey(p => p.BookId);
        }
    }
}
