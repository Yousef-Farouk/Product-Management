using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Product_Management.Models;
using Product_Management.ViewModels;

namespace Product_Management.Repository
{
    public class ClientProductRepository : Repository<ClientProducts>, IClientProductRepository
    {
        public ProductManagementContext db;

        public ClientProductRepository(ProductManagementContext _db) : base(_db)
        {
            db = _db;

        }

        public ClientProducts GetClientProduct(int clientId, int ProductId)
        {

            return db.ClientProducts.FirstOrDefault(cp => cp.ClientId == clientId && cp.ProductId == ProductId);

        }

    }

}

