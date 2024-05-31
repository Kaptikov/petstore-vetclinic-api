using Microsoft.EntityFrameworkCore;
using petstore_vetclinic_api.Models.Animals;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Categories;
using petstore_vetclinic_api.Models.Clinic;
using petstore_vetclinic_api.Models.Comments;
using petstore_vetclinic_api.Models.Favourites;
using petstore_vetclinic_api.Models.Orders;
using petstore_vetclinic_api.Models.Products;
using petstore_vetclinic_api.Models.Users;

namespace petstore_vetclinic_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
       // public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAdvantage> ProductAdvantages { get; set; }
        public DbSet<ProductCharacteristics> ProductCharacteristics { get; set; }
        public DbSet<ProductComposition> ProductCompositions { get; set; }
        public DbSet<ProductDescription> productDescriptions { get; set; }
        public DbSet<ProductNutritionalValue> ProductNutritionalValues { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<Favourite> Favourites { get; set; }
        public DbSet<FavouriteItem> FavouriteItems { get; set; }
       // public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ProductImg> ProductImgs { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<UserDto> UserDtos  { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Application> Applications { get; set; }
    }
}
