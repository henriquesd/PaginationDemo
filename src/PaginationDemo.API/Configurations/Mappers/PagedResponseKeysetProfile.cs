using AutoMapper;
using PaginationDemo.API.Dtos;
using PaginationDemo.Domain.Models;

namespace PaginationDemo.API.Configurations.Mappers
{
    public class PagedResponseKeysetProfile : Profile
    {
        public PagedResponseKeysetProfile()
        {
            CreateMap(typeof(PagedResponseKeyset<>), typeof(PagedResponseKeysetDto<>));
        }
    }
}