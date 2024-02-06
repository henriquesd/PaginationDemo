using Microsoft.EntityFrameworkCore;
using PaginationDemo.Domain.Models;

namespace PaginationDemo.Infrastructure.Context
{
    public class PaginationDemoDbContext : DbContext
    {
        public PaginationDemoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}