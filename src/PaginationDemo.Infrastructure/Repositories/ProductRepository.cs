using Microsoft.EntityFrameworkCore;
using PaginationDemo.Domain.Interfaces;
using PaginationDemo.Domain.Models;
using PaginationDemo.Infrastructure.Context;

namespace PaginationDemo.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly PaginationDemoDbContext _dbContext;

        public ProductRepository(PaginationDemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedResponseOffset<Product>> GetWithOffsetPagination(int pageNumber, int pageSize)
        {
            var totalRecords = await _dbContext.Products.AsNoTracking().CountAsync();

            var products = await _dbContext.Products.AsNoTracking()
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var pagedResponse = new PagedResponseOffset<Product>(products, pageNumber, pageSize, totalRecords);

            return pagedResponse;
        }

        public async Task<PagedResponseKeyset<Product>> GetWithKeysetPagination(int reference, int pageSize)
        {
            var products = await _dbContext.Products.AsNoTracking()
                .OrderBy(x => x.Id)
                .Where(p => p.Id > reference)
                .Take(pageSize)
                .ToListAsync();

            var newReference = products.Count != 0 ? products.Last().Id : 0;

            var pagedResponse = new PagedResponseKeyset<Product>(products, newReference);

            return pagedResponse;
        }
    }
}
