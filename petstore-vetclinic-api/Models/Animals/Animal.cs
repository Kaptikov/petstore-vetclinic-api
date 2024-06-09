using petstore_vetclinic_api.Models.Clinic;
using petstore_vetclinic_api.Models.Users;
using System.Text.Json.Serialization;

namespace petstore_vetclinic_api.Models.Animals
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public string? Breed { get; set; }
        public string? imgUrl { get; set; }
        public int UserId { get; set; }
        public User? Users { get; set; }
        [JsonIgnore]
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
