using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using server.Model;
using Server.Data;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.Books
                .Include(b => b.Category) // include category info
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Author,
                    b.ISBN,
                    b.Description,
                    b.Price,
                    b.InventoryCount,
                    b.IsOnSale,
                    b.CategoryId,
                    CategoryName = b.Category.Name,
                    b.CreatedAt
                })
                .ToList();

            return Ok(books);
        }
    }
}
