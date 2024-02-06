using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaginationDemo.API.Dtos;
using PaginationDemo.Domain.Interfaces;

namespace PaginationDemo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper,
                                IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("GetWithOffsetPagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWithOffsetPagination(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
                return BadRequest($"{nameof(pageNumber)} and {nameof(pageSize)} size must be greater than 0.");

            var pagedProducts = await _productService.GetWithOffsetPagination(pageNumber, pageSize);

            var pagedProductsDto = _mapper.Map<PagedResponseOffsetDto<ProductResultDto>>(pagedProducts);

            return Ok(pagedProductsDto);
        }

        [HttpGet("GetWithKeysetPagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWithKeysetPagination(int reference = 0, int pageSize = 10)
        {
            if (pageSize <= 0)
                return BadRequest($"{nameof(pageSize)} size must be greater than 0.");

            var pagedProducts = await _productService.GetWithKeysetPagination(reference, pageSize);

            var pagedProductsDto = _mapper.Map<PagedResponseKeysetDto<ProductResultDto>>(pagedProducts);

            return Ok(pagedProductsDto);
        }
    }
}