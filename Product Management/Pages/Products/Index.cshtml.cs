using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Product_Management.Models;
using Product_Management.Service;
using Product_Management.UnitOfWorks;
using Product_Management.ViewModels;
using X.PagedList;

namespace Product_Management.Pages.Products
{
    public class Index : PageModel
    {
        private readonly ProductService productservice;

        //public IList<ProductVm> Products { get; set; }
        public IPagedList<ProductVm> Products { get; set; }


        public Index(ProductService _productservice)
        {
            productservice = _productservice;
        }
        //public void OnGet()
        //{
        //    Products = productservice.GetAllProducts();
        //}

        public void OnGetAsync(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 1;   // Number of products per page
            Products =  productservice.GetPagedProductsAsync(pageNumber, pageSize);
        }

        public IActionResult OnPostDelete(int id)
        {
            productservice.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
