using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Product_Management.Models;
using Product_Management.UnitOfWorks;

namespace Product_Management.Pages
{
    public class HomeModel : PageModel
    {
        UnitOfWork Unit;

        public IList<Product> Products { get; set; }


        public HomeModel(UnitOfWork _Unit)
        {
            Unit = _Unit;
        }
        public async Task OnGetAsync()
        {
             Products =  (await Unit.ProductRepository.GetAll()).ToList();

        }
    }
}
