using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Management.Models;
using Product_Management.Service;
using Product_Management.UnitOfWorks;
using Product_Management.ViewModels;

namespace Product_Management.Pages.ClientProducts
{
    public class AddClientProductModel : PageModel
    {
        
        public  ClientProductsService clientproductService;
        public  ProductService productService;

        [BindProperty]
        public ClientProductVm ClientProductVm { get; set; }
        public SelectList ActiveProducts { get; set; }

        public AddClientProductModel(ClientProductsService _clientproductService, ProductService _productService)
        {
            clientproductService = _clientproductService;
            productService = _productService;
        }


        public void OnGet(int? clientId)
        {
            ActiveProducts = productService.GetActiveProducts();
            if (clientId.HasValue)
            {
                ClientProductVm = new ClientProductVm
                {
                    ClientId = clientId.Value
                };
            }
        }

        public IActionResult OnPostClientProduct() 
        {
            if (!ModelState.IsValid)
            {
                
                return Page();
            }
            clientproductService.AddClientProduct(ClientProductVm);

            return RedirectToPage("/Clients/index");
        }
    }
}
