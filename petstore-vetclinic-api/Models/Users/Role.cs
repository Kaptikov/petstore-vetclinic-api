﻿using System.Text.Json.Serialization;

namespace petstore_vetclinic_api.Models.Users
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public List<User> Users { get; set; } = new List<User>();
    }
}
