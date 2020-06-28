using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAPI.Contracts.Requests;
using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LearningDbContext _context;

        public BooksController(LearningDbContext context)
        {
            _context = context;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBooks(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<ActionResult> PostBook([FromBody] Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return Created("abc", book);
        }

        // PUT api/<BooksController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchBook(int id, [FromBody] PatchBookRequest request)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if(book == null)
            {
                return NotFound();
            }

            book.Name = request.Name;
            await _context.SaveChangesAsync();

            return Ok(book);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(book);
        }
    }
}
