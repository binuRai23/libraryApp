using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace server.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Navigation property for related books (optional but recommended)
       public List<Book> Books { get; set; } = new(); // Prevents null

    }
}