using System.ComponentModel.DataAnnotations;

namespace Product_Management.ViewModels
{
    public class ClientProductVm
    {
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string License { get; set; }
    }
}
