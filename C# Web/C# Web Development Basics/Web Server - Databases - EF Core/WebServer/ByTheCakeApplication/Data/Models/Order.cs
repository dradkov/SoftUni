using System;
using System.Collections.Generic;

namespace WebServer.ByTheCakeApplication.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<OrderProducts> Products { get; set; } = new List<OrderProducts>();
    }
}
