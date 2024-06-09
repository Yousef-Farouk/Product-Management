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

namespace Product_Management.Pages.Products
{
    public class EditProductModel : PageModel
    {
        ProductService productservice;
        public EditProductModel(ProductService _productservice)
        {
            productservice = _productservice;

        }

        [BindProperty]
        public ProductVm ProductVm { get; set; }

        public IActionResult OnGetProductById(int id)
        {
            ProductVm = productservice.GetProductById(id);

            if (ProductVm == null)
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

            productservice.UpdateProduct(ProductVm);

            return RedirectToPage("/Products/Index");
        }


       

    }
}
