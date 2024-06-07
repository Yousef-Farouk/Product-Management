using System.ComponentModel.DataAnnotations;

namespace Product_Management.ViewModels
{
    public class ProductVm
    {
       // public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(50, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set;}

    }
}
