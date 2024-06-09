using Product_Management.Models;
using System.ComponentModel.DataAnnotations;

namespace Product_Management.ViewModels
{
    public class RelatedProductsVm
    {


        public int ProductId { get; set; }

       
        public string ProductName { get; set; }

      
        public string ProductDescription { get; set; }

        public bool ProductIsActive { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string License { get; set; }
    }
}
