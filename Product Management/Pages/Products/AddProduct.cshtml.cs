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

namespace Product_Management.Pages.Products
{
    public class AddProductModel : PageModel
    {
        ProductService productservice;


        [BindProperty]
        public ProductVm ProductVm { get; set; }


        public AddProductModel(ProductService _productservice)
        {
            productservice = _productservice;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public  IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            productservice.AddProduct(ProductVm);
            return RedirectToPage("/Products/Index");
        }

       





    }
}
