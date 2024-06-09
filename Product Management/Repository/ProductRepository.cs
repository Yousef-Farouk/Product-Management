using Microsoft.EntityFrameworkCore;
using Product_Management.Models;

namespace Product_Management.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        public ProductManagementContext db;

        public ProductRepository(ProductManagementContext _db) :base(_db) 
        {
            db=_db;
        
        }
        

        public Product GetRelatedProduct(int id)
        {
           return  db.Products.Include(p=>p.ClientProducts).FirstOrDefault(p=>p.Id == id);
        }
    }
}
