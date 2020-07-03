using FirstAPI.Contracts.Requests;
using FirstAPI.Data;
using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<List<Book>> GetBooks()
        {
            return _bookRepository.ListAsync();
        }

        public Task<Book> GetBookById(int id)
        {
            var book = _bookRepository.GetByIdAsync(id);
            return book;
        }

        public Task<List<UserBook>> GetBooksByUser(string username)
        {
            var books = _bookRepository.ListByUserNameAsync(username);
            return books;
        }

        public void PostBook(Book book)
        {
            _bookRepository.Create(book);
        }

        public async Task<Book> PatchBook(int id, PatchBookRequest request)
        {
            var book = await _bookRepository.Update(id, request);
            return book;
        }

        public async Task<Book> DeleteBook(int id)
        {
            var book = await _bookRepository.Delete(id);
            return book;
        }
    }
}
