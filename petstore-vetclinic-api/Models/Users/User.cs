using petstore_vetclinic_api.Models.Animals;
using petstore_vetclinic_api.Models.Carts;

namespace petstore_vetclinic_api.Models.Users
{
    public class User
    {
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
       /* public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
       
        //public int? CartId { get; set; }
        public Cart? Carts { get; set; }
        public List<Animal> Animals { get; set; } = new();*/
    }
}
