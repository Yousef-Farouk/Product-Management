using System.ComponentModel.DataAnnotations;

namespace Product_Management.Models
{
    public class Client
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(9)]
        public int Code { get; set; }

        [Required]
        public ClientClass Class { get; set; }

        [Required]
        public ClientState State { get; set; }

        public virtual ICollection<ClientProducts> ClientProducts { get; set; }


    }

   

    
}
