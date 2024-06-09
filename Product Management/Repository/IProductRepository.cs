using Product_Management.Models;

namespace Product_Management.Repository
{
    public interface IProductRepository :IRepository<Product>
    {

        public Product GetRelatedProduct(int id);

    }
}
