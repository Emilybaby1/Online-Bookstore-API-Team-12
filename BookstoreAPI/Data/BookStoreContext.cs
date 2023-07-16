using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore__Management_system.Models;

namespace BookStore__Management_system.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
              .HasKey(u => new {
                  u.UserId
              });

            builder.Entity<Books>()
              .HasKey(e => new
              {
                  e.Id
              });

            builder.Entity<CartItem>()
             .HasKey(c => new
             {
                 c.CartId
             });
        }
        
    }
}