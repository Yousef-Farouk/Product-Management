using Microsoft.AspNetCore.Mvc.Rendering;
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

        public SelectList GetActiveProducts()
        {
            return new SelectList(db.Products.Where(p => p.IsActive), "Id", "Name");
        }

        public Product GetRelatedProduct(int id)
        {
           return  db.Products.Include(p=>p.ClientProducts).FirstOrDefault(p=>p.Id == id);
        }
    }
}
