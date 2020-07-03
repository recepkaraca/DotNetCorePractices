using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Data
{
    public class LearningDbContext : DbContext
    {
        public LearningDbContext() { }

        public LearningDbContext(DbContextOptions<LearningDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBook>().HasKey(t => new { t.UserName, t.BookId });
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<UserBook> UsersBooks { get; set; }
    }
}
