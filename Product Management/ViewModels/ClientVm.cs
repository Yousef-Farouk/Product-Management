using Product_Management.Models;

namespace Product_Management.ViewModels
{
    public class ClientVm
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Code { get; set; }

        public ClientClass Class { get; set; }


        public ClientState State { get; set; }


    }
}
