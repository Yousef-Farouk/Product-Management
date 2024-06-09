using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Product_Management.Models;
using Product_Management.UnitOfWorks;
using Product_Management.ViewModels;

namespace Product_Management.Service
{
    public class ClientService
    {
        private readonly IMapper mapper;
        private readonly UnitOfWork unit;
        public ClientService(UnitOfWork _unit, IMapper _mapper)
        {
            mapper = _mapper;
            unit = _unit;
        }

        public IList<ClientVm> GetAllClients()
        {
            var clients = unit.ClientRepository.GetAll().OrderBy(c=>c.Code);
            return mapper.Map<IList<ClientVm>>(clients);
        }

        public ClientVm GetClientById(int id)
        {
            var client = unit.ClientRepository.GetByID(id);

            return mapper.Map<ClientVm>(client);

        }
        public void AddClient(ClientVm ClientVm)
        {
            var client = mapper.Map<Client>(ClientVm);
            unit.ClientRepository.Add(client);
            unit.SaveChanges();
        }


        public void UpdateClient(ClientVm ClientVm)
        {
            var client = mapper.Map<Client>(ClientVm);
            unit.ClientRepository.Update(client);
            unit.SaveChanges();
        }


        public void DeleteClient(int id)
        {
            var client = unit.ClientRepository.GetByID(id);
            unit.ClientRepository.Delete(client);
            unit.SaveChanges();
        }

        public async Task<(IEnumerable<ClientVm> Clients, int TotalCount)> GetPagedClientsAsync(int pageNumber, int pageSize)
        {
            var query = unit.ClientRepository.GetAll();

            int totalCount = await query.CountAsync();

            var clients = await query
                .OrderBy(p => p.Code)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var clientVm = mapper.Map<List<ClientVm>>(clients);

            return (clientVm, totalCount);
        }

        public List<SelectListItem> GetClientClasses()
        {
            return Enum.GetValues(typeof(ClientClass))
                            .Cast<ClientClass>()
                            .Select(c => new SelectListItem { Value = c.ToString(), Text = c.ToString() })
                            .ToList();

        }

        public List<SelectListItem> GetClientStates()
        {
            return Enum.GetValues(typeof(ClientState))
                            .Cast<ClientState>()
                            .Select(c => new SelectListItem { Value = c.ToString(), Text = c.ToString() })
                            .ToList();

        }

        public  ClientDetailsVm GetClientDetails(int clientId)
        {
            var client = unit.ClientRepository.GetAll().Include(c => c.ClientProducts).ThenInclude(cp => cp.Product).FirstOrDefault(c => c.Id == clientId);

            if (client == null)
            {
                return null;
            }

            var clientDetailsVm = mapper.Map<ClientDetailsVm>(client);

            return clientDetailsVm;
        }

    }
}
