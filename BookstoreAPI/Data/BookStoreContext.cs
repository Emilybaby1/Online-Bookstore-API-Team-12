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
        public DbSet<Books> Books { get; set; }
        public DbSet<Sales> Sales { get; set; }
    }
}