using petstore_vetclinic_api.Models.Users;

namespace petstore_vetclinic_api.Models.Animals
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User? Users { get; set; }

    }
}
