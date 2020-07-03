using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FirstAPI.Contracts.Requests;
using FirstAPI.Data;
using FirstAPI.Logger;
using FirstAPI.Models;
using FirstAPI.Services;
using Microsoft.AspNetCore.Http;
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
        private readonly ILoggerManager _logger;
        private readonly IBookService _bookService;

        public BooksController(LearningDbContext context, ILoggerManager logger, IBookService bookService)
        {
            _context = context;
            _logger = logger;
            _bookService = bookService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable>> GetBooks()
        {
            _logger.LogInfo("Here is info message from the controller.");
            var books = await _bookService.GetBooks();
            return books;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetBooks(int id)
        {
            var book = await _bookService.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("users/{username}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetBooksByUser(string username)
        {
            var books = await _bookService.GetBooksByUser(username);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        // POST api/<BooksController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> PostBook([FromBody] Book book)
        {
            _bookService.PostBook(book);
            return Created("abc", book);
        }

        // PUT api/<BooksController>/5
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> PatchBook(int id, [FromBody] PatchBookRequest request)
        {
            var book = await _bookService.PatchBook(id, request);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await _bookService.DeleteBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
