using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product_Management.Models;
using Product_Management.UnitOfWorks;
using Product_Management.ViewModels;

namespace Product_Management.Service
{
    public class ClientProductsService
    {
        //    private readonly IMapper mapper;
        //    private readonly UnitOfWork unit;

        //    public ClientProductsService(UnitOfWork _unit, IMapper _mapper)
        //    {
        //        mapper = _mapper;
        //        unit = _unit;
        //    }

        //    public IList<ClientProductsVm> GetAllClients()
        //    {
        //       // var clients = unit.ClientRepository.GetAll().OrderBy(cp=>cp.ClientProducts.);

        //        var clients = unit.ClientRepository.GetAll().Include(c => c.ClientProducts).ThenInclude(cp => cp.Product);

        //        return mapper.Map<IList<ClientVm>>(clients);
        //    }

        //    public ClientVm GetClientById(int id)
        //    {
        //        var client = unit.ClientRepository.GetByID(id);

        //        return mapper.Map<ClientVm>(client);

        //    }
        //    public void AddClient(ClientVm ClientVm)
        //    {
        //        var client = mapper.Map<Client>(ClientVm);
        //        unit.ClientRepository.Add(client);
        //        unit.SaveChanges();
        //    }


        //    public void UpdateClient(ClientVm ClientVm)
        //    {
        //        var client = mapper.Map<Client>(ClientVm);
        //        unit.ClientRepository.Update(client);
        //        unit.SaveChanges();
        //    }


        //    public void DeleteClient(int id)
        //    {
        //        var client = unit.ClientRepository.GetByID(id);
        //        unit.ClientRepository.Delete(client);
        //        unit.SaveChanges();
        //    }

        //    public async Task<(IEnumerable<ClientVm> Clients, int TotalCount)> GetPagedClientsAsync(int pageNumber, int pageSize)
        //    {
        //        var query = unit.ClientRepository.GetAll();

        //        int totalCount = await query.CountAsync();

        //        var clients = await query
        //            .OrderBy(p => p.Code)
        //            .Skip((pageNumber - 1) * pageSize)
        //            .Take(pageSize)
        //            .ToListAsync();

        //        var clientVm = mapper.Map<List<ClientVm>>(clients);

        //        return (clientVm, totalCount);
        //    }


        //}
    }
}
