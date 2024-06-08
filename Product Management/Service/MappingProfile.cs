using AutoMapper;
using Product_Management.Models;
using Product_Management.ViewModels;
using X.PagedList;

namespace Product_Management.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductVm>().ReverseMap();
            CreateMap<IPagedList<Product>, IPagedList<ProductVm>>().ReverseMap();

        }
    }
}
