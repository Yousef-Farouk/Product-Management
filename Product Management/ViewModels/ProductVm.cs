using System.ComponentModel.DataAnnotations;

namespace Product_Management.ViewModels
{
    public class ProductVm
    {
        public int Id { get; set; }

       [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product State is required.")]
        public bool IsActive { get; set;}

    }
}
