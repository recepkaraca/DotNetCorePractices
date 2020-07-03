using FirstAPI.Contracts.Requests;
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

        public async Task<List<Book>> ListAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            Book a = await _context.Books.FindAsync(id);
            return a;
        }

        public Task<List<UserBook>> ListByUserNameAsync(string userName)
        {
            return _context.UserBooks.Include(x => x.Book).Where(x => x.UserName == userName).ToListAsync();
        }

        public void Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChangesAsync();
        }

        public async Task<Book> Update(int id, PatchBookRequest request)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {
                return null;
            }

            book.Name = request.Name;
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return null;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }
    }
}
