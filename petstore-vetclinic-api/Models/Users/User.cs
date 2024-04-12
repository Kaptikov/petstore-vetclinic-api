using petstore_vetclinic_api.Models.Animals;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Comments;
using System.Text.Json.Serialization;

namespace petstore_vetclinic_api.Models.Users
{
    public class User
    {
        
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }

        public DateTime DataRegistration { get; set; } = DateTime.Now;

        //public int? CartId { get; set; }

        [JsonIgnore]
        public Cart? Carts { get; set; }
        [JsonIgnore]
        public UserDto? UserDtos { get; set; }
        [JsonIgnore]
        public List<Animal> Animals { get; set; } = new();
        [JsonIgnore]
        public List<Comment> Comments { get; set; }
    }
}
