using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Product_Management.Service;
using Product_Management.ViewModels;

namespace Product_Management.Pages.Clients
{
    public class ClientDetailsModel : PageModel
    {
        private readonly ClientService clientService;

        public ClientDetailsModel(ClientService _clientService)
        {
            clientService = _clientService;
        }

        public ClientDetailsVm ClientVm { get; set; }


        public IActionResult OnGetClientDetails(int id)
        {
            ClientVm =  clientService.GetClientDetails(id);

            if (ClientVm == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
