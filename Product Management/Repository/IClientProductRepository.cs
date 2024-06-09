using Product_Management.Models;

namespace Product_Management.Repository
{
    public interface IClientProductRepository : IRepository<ClientProducts>
    {
        public ClientProducts GetClientProduct(int clientId, int ProductId);

    }
}
