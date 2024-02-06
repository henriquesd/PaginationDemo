using PaginationDemo.Domain.Interfaces;
using PaginationDemo.Domain.Models;

namespace PaginationDemo.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<PagedResponseOffset<Order>> GetWithOffsetPagination(int pageNumber, int pageSize)
        {
            return await _orderRepository.GetWithOffsetPagination(pageNumber, pageSize);
        }
    }
}