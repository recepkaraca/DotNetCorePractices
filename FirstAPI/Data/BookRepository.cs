using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly LearningDbContext _context;

        public BookRepository(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }
    }
}
