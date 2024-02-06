using PaginationDemo.Domain.Models;

namespace PaginationDemo.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<PagedResponseOffset<Order>> GetWithOffsetPagination(int pageNumber, int pageSize);
    }
}
