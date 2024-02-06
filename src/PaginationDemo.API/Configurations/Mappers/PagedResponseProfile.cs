using AutoMapper;
using PaginationDemo.API.Dtos;
using PaginationDemo.Domain.Models;

namespace PaginationDemo.API.Configurations.Mappers
{
    public class PagedResponseProfile : Profile
    {
        public PagedResponseProfile()
        {
            CreateMap(typeof(PagedResponseOffset<>), typeof(PagedResponseOffsetDto<>));
        }
    }
}