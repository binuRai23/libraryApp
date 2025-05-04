using System;
using Microsoft.EntityFrameworkCore;
using server.Model;
using Server.Model;

namespace Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Category> Categories { get; set; }
}
