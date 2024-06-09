using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Product_Management.Models;
using Product_Management.Service;
using Product_Management.ViewModels;

namespace Product_Management.Pages.Clients
{
    public class ClientDetailsModel : PageModel
    {
        private readonly ClientService clientService;
        private readonly ClientProductsService clientProductsService;

        public ClientDetailsModel(ClientService _clientService,ClientProductsService _clientProductsService)
        {
            clientService = _clientService;
            clientProductsService = _clientProductsService;
        }

        public ClientDetailsVm ClientVm { get; set; }


        public IActionResult OnGet(int id)
        {
            ClientVm =  clientService.GetClientDetails(id);

            if (ClientVm == null)
            {
                return NotFound();
            }

            return Page();
        }


        public IActionResult OnPostDeleteClientProduct(int productId,int clientId)
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }

            clientProductsService.DeleteClientProduct(clientId,productId);

            return RedirectToPage("/Clients/ClientDetails", new { id = clientId });
        }
    }
}
