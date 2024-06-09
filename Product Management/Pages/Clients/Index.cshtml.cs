using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Product_Management.Models;
using Product_Management.Service;
using Product_Management.UnitOfWorks;
using Product_Management.ViewModels;

namespace Product_Management.Pages.Clients
{
    public class Index : PageModel
    {
        private readonly ClientService clientservice;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public IEnumerable<ClientVm> Clients { get; set; }


        public Index(ClientService _clientservice)
        {
            clientservice = _clientservice;
        }

        public async Task OnGetAsync(int? pageNumber)
        {
            int page = pageNumber ?? 1;
            int pageSize = 2; // Number of products per page

            var result =  await clientservice.GetPagedClientsAsync(page, pageSize);
            Clients= result.Clients;
            CurrentPage = page;
            TotalPages = (int)Math.Ceiling(result.TotalCount / (double)pageSize);
        }

        public IActionResult OnPostDelete(int id)
        {
            clientservice.DeleteClient(id);
            return RedirectToAction("Index");
        }
    }
}
