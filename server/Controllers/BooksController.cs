using Microsoft.AspNetCore.Mvc;
using server.Model;
using Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly string _baseImageUrl = "/images/";
        public BookController(ApplicationDbContext context)
        {
            _context = context;

            // Seed dummy data if empty
            if (!_context.Books.Any())
            {
                _context.Books.AddRange(new List<Book>
                {
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Great Gatsby",
                        Author = "F. Scott Fitzgerald",
                        ISBN = "9780743273565",
                        Genre = "Classic",
                        Description = "A novel set in the Roaring Twenties.",
                        ImageUrl = _baseImageUrl + "book.jpeg",
                        Price = 10.99m,
                        InventoryCount = 50,
                        IsOnSale = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "1984",
                        Author = "George Orwell",
                        ISBN = "9780451524935",
                        Genre = "Dystopian",
                        Description = "A novel about totalitarianism and surveillance.",
                        ImageUrl =  _baseImageUrl + "book.jpeg",
                        Price = 8.99m,
                        InventoryCount = 40,
                        IsOnSale = false,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }
                });

                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            return Ok(_context.Books.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetById(Guid id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            book.Id = Guid.NewGuid();
            book.CreatedAt = DateTime.UtcNow;
            book.UpdatedAt = DateTime.UtcNow;
            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Book updatedBook)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.ISBN = updatedBook.ISBN;
            book.Genre = updatedBook.Genre;
            book.Description = updatedBook.Description;
            book.ImageUrl = updatedBook.ImageUrl;
            book.Price = updatedBook.Price;
            book.InventoryCount = updatedBook.InventoryCount;
            book.IsOnSale = updatedBook.IsOnSale;
            book.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
