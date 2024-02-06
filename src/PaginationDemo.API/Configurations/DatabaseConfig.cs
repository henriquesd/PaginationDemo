using Microsoft.EntityFrameworkCore;
using PaginationDemo.Domain.Models;
using PaginationDemo.Infrastructure.Context;

namespace PaginationDemo.API.Configurations
{
    public static class DatabaseConfig
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaginationDemoDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static void CreateDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PaginationDemoDbContext>();
                dbContext.Database.EnsureCreated();
            }
        }

        public static void PopulateDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PaginationDemoDbContext>();

                var numberOfProductsToSeed = 100_000;
                var numberOfOrdersToSeed = 1_000;

                if (!dbContext.Products.Any())
                {
                    var products = Enumerable.Range(1, numberOfProductsToSeed).Select(i => new Product { Name = $"Product {i}" });
                    dbContext.Products.AddRange(products);
                    dbContext.SaveChanges();
                }

                if (!dbContext.Orders.Any())
                {
                    var orders = Enumerable.Range(1, numberOfOrdersToSeed).Select(i => new Order { Code = $"ORDER-{i}" });
                    dbContext.Orders.AddRange(orders);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}