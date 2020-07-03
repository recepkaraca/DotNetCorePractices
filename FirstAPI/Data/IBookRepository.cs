using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Data
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooks();
    }
}
