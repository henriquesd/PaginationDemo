using PaginationDemo.Domain.Models;

namespace PaginationDemo.Domain.Interfaces
{
    public interface IProductService
    {
        Task<PagedResponseOffset<Product>> GetWithOffsetPagination(int pageNumber, int pageSize);
        Task<PagedResponseKeyset<Product>> GetWithKeysetPagination(int reference, int pageSize);
    }
}
