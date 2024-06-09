using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Product_Management.Models;
using Product_Management.Service;
using Product_Management.ViewModels;

namespace Product_Management.Pages.Clients
{
    public class EditClientModel : PageModel
    {
         ClientService clientservice;

        public List<SelectListItem> ClientClasses { get; set; }

        public List<SelectListItem> ClientStates { get; set; }

        public EditClientModel(ClientService _clientservice)
        {
            clientservice = _clientservice;

        }

        [BindProperty]
        public ClientVm ClientVm { get; set; }

        public IActionResult OnGetClientById(int id)
        {
            ClientVm = clientservice.GetClientById(id);
            ClientClasses = clientservice.GetClientClasses();
            ClientStates = clientservice.GetClientStates();

            if (ClientVm == null)
            {
                return NotFound();
            }
            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            clientservice.UpdateClient(ClientVm);

            return RedirectToPage("./Index");
        }


       

    }
}
