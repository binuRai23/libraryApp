using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Model
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int InventoryCount { get; set; }

        public bool IsOnSale { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        // Navigation property
        public Category Category { get; set; }
    }
}