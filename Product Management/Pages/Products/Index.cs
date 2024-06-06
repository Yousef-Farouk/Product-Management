using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Product_Management.Models;
using Product_Management.Service;
using Product_Management.UnitOfWorks;
using Product_Management.ViewModels;

namespace Product_Management.Pages.Products
{
    public class Index : PageModel
    {
        private readonly ProductService productservice;

        public IList<ProductVm> Products { get; set; }


        public Index(ProductService _productservice)
        {
            productservice = _productservice;
        }
        public void OnGet()
        {
            Products = productservice.GetAllProducts();
        }
    }
}
