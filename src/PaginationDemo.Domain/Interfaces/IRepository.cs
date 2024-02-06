using PaginationDemo.Domain.Models;

namespace PaginationDemo.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<PagedResponseOffset<TEntity>> GetWithOffsetPagination(int pageNumber, int pageSize);
    }
}