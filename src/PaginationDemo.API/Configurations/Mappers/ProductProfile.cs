using AutoMapper;
using PaginationDemo.API.Dtos;
using PaginationDemo.Domain.Models;

namespace PaginationDemo.API.Configurations.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResultDto>();
        }
    }
}