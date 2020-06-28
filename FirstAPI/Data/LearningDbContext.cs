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

        public virtual DbSet<Book> Books { get; set; }
    }
}
