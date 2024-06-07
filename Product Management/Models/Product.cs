using System.ComponentModel.DataAnnotations;

namespace Product_Management.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(2, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<ClientProducts> ClientProducts { get; set; }


    }



}
