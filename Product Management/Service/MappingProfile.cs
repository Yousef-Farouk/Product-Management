using AutoMapper;
using Product_Management.Models;
using Product_Management.ViewModels;

namespace Product_Management.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductVm>().ReverseMap();
            
        }
    }
}
