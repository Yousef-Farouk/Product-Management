using Product_Management.Models;
using Product_Management.Repository;

namespace Product_Management.UnitOfWorks
{
    public class UnitOfWork 
    {
        ProductManagementContext db;
        Repository<Product> productRepository;
        Repository<Client> clientRepository;

        public UnitOfWork(ProductManagementContext _db)
        {
            this.db = _db;

        }

        public Repository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new Repository<Product>(db);

                }
                return productRepository;
            }
        }

        public Repository<Client> ClientRepository
        {
            get
            {
                if (clientRepository == null)
                {
                    clientRepository = new Repository<Client>(db);
                }
                return clientRepository;
            }
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
