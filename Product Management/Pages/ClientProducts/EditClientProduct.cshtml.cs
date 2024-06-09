using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Management.Models;
using Product_Management.Service;
using Product_Management.ViewModels;

namespace Product_Management.Pages.ClientProducts
{
    public class EditClientProductModel : PageModel
    {
        public ClientProductsService clientproductService;
        public ProductService productService;

        [BindProperty]
        public ClientProductVm ClientProductVm { get; set; }

        public SelectList ActiveProducts { get; set; }

        public EditClientProductModel(ClientProductsService _clientproductService, ProductService _productService)
        {
            clientproductService = _clientproductService;
            productService = _productService;
        }


        public void OnGet(int ClientId , int ProductId)
        {
            ActiveProducts = productService.GetActiveProducts();
            ClientProductVm = clientproductService.GetClientProductVm(ClientId, ProductId);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }

            clientproductService.UpdateClientProduct(ClientProductVm);

            return RedirectToPage("/Clients/ClientDetails", new { id = ClientProductVm.ClientId });
        }
    }
}
