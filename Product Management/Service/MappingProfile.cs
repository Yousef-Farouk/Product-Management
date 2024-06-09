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
            CreateMap<Client,ClientVm>().ReverseMap();

            CreateMap<Client, ClientDetailsVm>()
            .ForMember(dest => dest.ClientProducts, opt => opt.MapFrom(src => src.ClientProducts.OrderBy(cp => cp.Product.Name)));

            CreateMap<ClientProducts, RelatedProductsVm>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.Product.Description))
                .ForMember(dest => dest.ProductIsActive, opt => opt.MapFrom(src => src.Product.IsActive));

            CreateMap<ClientProductVm, ClientProducts>().ReverseMap();



        }
    }
}
