using AutoMapper;
using PaginationDemo.API.Dtos;
using PaginationDemo.Domain.Models;

namespace PaginationDemo.API.Configurations.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderResultDto>();
        }
    }
}