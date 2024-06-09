using Product_Management.Models;
using Product_Management.Repository;

namespace Product_Management.UnitOfWorks
{
    public class UnitOfWork 
    {
        ProductManagementContext db;
        ProductRepository productRepository;
        Repository<Client> clientRepository;
        IClientProductRepository clientproductsRepository;


        public UnitOfWork(ProductManagementContext _db)
        {
            this.db = _db;

        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(db);

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

        public IClientProductRepository ClientProductsRepository
        {
            get
            {
                if (clientproductsRepository == null)
                {
                    clientproductsRepository = new ClientProductRepository(db);
                }
                return clientproductsRepository;
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
