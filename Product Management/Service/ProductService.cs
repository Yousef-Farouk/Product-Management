using AutoMapper;
using Product_Management.Models;
using Product_Management.UnitOfWorks;
using Product_Management.ViewModels;

namespace Product_Management.Service
{
    public class ProductService
    {
        private readonly IMapper  mapper;
        private readonly UnitOfWork unit;
        public ProductService(UnitOfWork _unit ,IMapper _mapper )
        {
            mapper = _mapper;
            unit = _unit;
        }

        public IList<ProductVm> GetAllProducts()
        {
            var products = unit.ProductRepository.GetAll();
            return mapper.Map<IList<ProductVm>>(products);
        }

        public void AddProduct(ProductVm productVm)
        {
            var product = mapper.Map<Product>(productVm);
            unit.ProductRepository.Add(product);
            unit.SaveChanges();
        }
    }
}
