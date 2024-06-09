using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Management.Models;
using Product_Management.Service;
using Product_Management.ViewModels;

namespace Product_Management.Pages.Clients
{
    public class AddClientModel : PageModel
    {
        ClientService clientservice;


        [BindProperty]
        public ClientVm ClientVm { get; set; }


        public List<SelectListItem> ClientClasses { get; set; }

        public List<SelectListItem> ClientStates { get; set; }

        public AddClientModel(ClientService _clientservice)
        {
           clientservice = _clientservice;
        }

        public IActionResult OnGet()
        {
            ClientClasses = clientservice.GetClientClasses();
            ClientStates = clientservice.GetClientStates();

            return Page();
        }


        public  IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            clientservice.AddClient(ClientVm);
            return RedirectToPage("/Clients/Index");
        }

       





    }
}
