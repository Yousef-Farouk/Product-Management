using System.ComponentModel.DataAnnotations;

namespace Product_Management.ViewModels
{
    public class ClientProductVm
    {
        public int ClientId { get; set; }

        public int ProductId { get; set; }


        [Required(ErrorMessage ="Start Date is required")]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "License is required")]
        public string License { get; set; }
    }
}
