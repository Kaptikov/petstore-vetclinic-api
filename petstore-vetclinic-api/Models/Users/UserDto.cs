

using petstore_vetclinic_api.Models.Carts;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace petstore_vetclinic_api.Models.Users
{
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        [JsonIgnore]
        public User? Users { get; set; }
    }
}
