﻿using petstore_vetclinic_api.Models.Products;
using petstore_vetclinic_api.Models.Users;
using System.Text.Json.Serialization;

namespace petstore_vetclinic_api.Models.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int? Quantity { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }
    }
}
