using Microsoft.EntityFrameworkCore;
using PaginationDemo.Domain.Interfaces;
using PaginationDemo.Domain.Models;
using PaginationDemo.Infrastructure.Context;

namespace PaginationDemo.Infrastructure.Repositories
{
    // Example of a generic Offset Pagination in a generic Repository;
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly PaginationDemoDbContext Db;

        protected Repository(PaginationDemoDbContext db)
        {
            Db = db;
        }

        public virtual async Task<PagedResponseOffset<TEntity>> GetWithOffsetPagination(int pageNumber, int pageSize)
        {
            var totalRecords = await Db.Set<TEntity>().AsNoTracking().CountAsync();

            var entities = await Db.Set<TEntity>().AsNoTracking()
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var pagedResponse = new PagedResponseOffset<TEntity>(entities, pageNumber, pageSize, totalRecords);

            return pagedResponse;
        }
    }
}
