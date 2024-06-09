using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product_Management.Models;
using Product_Management.UnitOfWorks;
using Product_Management.ViewModels;

namespace Product_Management.Service
{
    public class ClientProductsService
    {
        private readonly IMapper mapper;
        private readonly UnitOfWork unit;

        public ClientProductsService(UnitOfWork _unit, IMapper _mapper)
        {
            mapper = _mapper;
            unit = _unit;
        }

        
        public void AddClientProduct(ClientProductVm clientProductVm)
        {
            var clientProduct = mapper.Map<ClientProducts>(clientProductVm);
            unit.ClientProductsRepository.Add(clientProduct);
            unit.SaveChanges();
        }




        
    }
}
