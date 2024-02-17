using FakeShop.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeShop.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Products> Products { get; set; }
}