using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product_Management.Models;
using Product_Management.UnitOfWorks;
using Product_Management.ViewModels;
using X.PagedList;

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
            var products = unit.ProductRepository.GetAll().OrderBy(p=>p.Name);
            return mapper.Map<IList<ProductVm>>(products);
        }

        public ProductVm GetProductById(int id)
        {
            var product = unit.ProductRepository.GetByID(id);

            return mapper.Map<ProductVm>(product);
        
        }
        public void AddProduct(ProductVm productVm)
        {
            var product = mapper.Map<Product>(productVm);
            unit.ProductRepository.Add(product);
            unit.SaveChanges();
        }


        public void UpdateProduct(ProductVm productvm) 
        {
            var product  = mapper.Map<Product>(productvm);
            unit.ProductRepository.Update(product);
            unit.SaveChanges();
        }


        public bool DeleteProduct(int id) 
        {
            var product = unit.ProductRepository.GetRelatedProduct(id);

            if (product.ClientProducts.Any())
            {
                return false;           // Cannot delete product because it has related ClientProducts
            }

            unit.ProductRepository.Delete(product);
            unit.SaveChanges();

            return true;
        }

        public async Task<(IEnumerable<ProductVm> Products, int TotalCount)> GetPagedProductsAsync(int pageNumber, int pageSize)
        {
            var query = unit.ProductRepository.GetAll();

            int totalCount = await query.CountAsync();

            var products = await query
                .OrderBy(p => p.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var productVm = mapper.Map<List<ProductVm>>(products);

            return (productVm, totalCount);
        }

    }
}
