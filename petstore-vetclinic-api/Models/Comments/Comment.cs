using petstore_vetclinic_api.Models.Products;
using petstore_vetclinic_api.Models.Users;

namespace petstore_vetclinic_api.Models.Comments
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        //public string UserName { get; set; }
        public string Description { get; set; }

        public User? Users { get; set; }
        public Product? Products { get; set; }
    }   
}
