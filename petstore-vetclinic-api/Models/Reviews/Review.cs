using petstore_vetclinic_api.Models.Products;
using petstore_vetclinic_api.Models.Users;
using System.Text.Json.Serialization;

namespace petstore_vetclinic_api.Models.Reviews
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        //public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime Date {  get; set; } = DateTime.Now;

        public User? Users { get; set; }
        [JsonIgnore]
        public Product? Products { get; set; }
    }   
}
