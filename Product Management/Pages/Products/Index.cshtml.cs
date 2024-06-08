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
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public IEnumerable<ProductVm> Products { get; set; }


        public Index(ProductService _productservice)
        {
            productservice = _productservice;
        }


        //public void OnGet()
        //{
        //    Products = productservice.GetAllProducts();
        //}

        

        public async Task OnGetAsync(int? pageNumber)
        {
            int page = pageNumber ?? 1;
            int pageSize = 5; // Number of products per page

            var result =  await productservice.GetPagedProductsAsync(page, pageSize);
            Products = result.Products;
            CurrentPage = page;
            TotalPages = (int)Math.Ceiling(result.TotalCount / (double)pageSize);
        }

        public IActionResult OnPostDelete(int id)
        {
            productservice.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
