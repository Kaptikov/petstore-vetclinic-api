﻿using petstore_vetclinic_api.Models.Animals;
using petstore_vetclinic_api.Models.Carts;
using petstore_vetclinic_api.Models.Clinic;
using petstore_vetclinic_api.Models.Comments;
using petstore_vetclinic_api.Models.Favourites;
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
        public string? Phone { get; set; }
        public int RoleId { get; set; }
        [JsonIgnore]
        public Role? Roles { get; set; }
        public DateTime DataRegistration { get; set; } = DateTime.Now;
        [JsonIgnore]
        public UserDto? UserDtos { get; set; }
        [JsonIgnore]
        public List<Animal> Animals { get; set; } = new List<Animal>();
        [JsonIgnore]
        public List<Comment> Comments { get; set; } = new List<Comment>();
        [JsonIgnore]
        public List<CartItem> CartItems = new List<CartItem>();
        [JsonIgnore]
        public List<FavouriteItem> FavouriteItems = new List<FavouriteItem>();
        [JsonIgnore]
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
