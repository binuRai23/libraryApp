using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.Response
{
    public class BookDto
    {public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int InventoryCount { get; set; }
    public bool IsOnSale { get; set; }
    public int CategoryId { get; set; }
    }
}