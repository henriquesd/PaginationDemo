using PaginationDemo.Domain.Interfaces;
using PaginationDemo.Domain.Models;
using PaginationDemo.Infrastructure.Context;

namespace PaginationDemo.Infrastructure.Repositories
{
    // Example using a generic Offset Pagination from a generic Repository;
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(PaginationDemoDbContext context) : base(context) { }
    }
}