using Product_Management.Models;
using System.ComponentModel.DataAnnotations;

namespace Product_Management.ViewModels
{
    public class ClientVm
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Client Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Client Code is required.")]

        public int Code { get; set; }


        public ClientClass Class { get; set; }


        public ClientState State { get; set; }


    }
}
