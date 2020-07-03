using FirstAPI.Contracts.Requests;
using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Data
{
    public interface IBookRepository
    {
        Task<List<Book>> ListAsync();
        Task<Book> GetByIdAsync(int id);
        Task<List<UserBook>> ListByUserNameAsync(string userName);
        void Create(Book book);
        Task<Book> Update(int id, PatchBookRequest request);
        Task<Book> Delete(int id);
    }
}
