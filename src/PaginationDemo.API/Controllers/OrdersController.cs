using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginationDemo.API.Dtos;
using PaginationDemo.Domain.Interfaces;

namespace PaginationDemo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IMapper mapper,
                                IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpGet("GetWithGenericOffsetPagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWithGenericOffsetPagination(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
                return BadRequest($"{nameof(pageNumber)} and {nameof(pageSize)} size must be greater than 0.");

            var pagedOrders = await _orderService.GetWithOffsetPagination(pageNumber, pageSize);

            var pagedOrdersDto = _mapper.Map<PagedResponseOffsetDto<OrderResultDto>>(pagedOrders);

            return Ok(pagedOrdersDto);
        }
    }
}