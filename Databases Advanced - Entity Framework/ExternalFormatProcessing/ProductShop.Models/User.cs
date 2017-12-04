using System;

namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class User
    {
        
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public ICollection<Product> ProductsSold { get; set; } = new HashSet<Product>();

        public ICollection<Product> ProductsBought { get; set; } = new HashSet<Product>();
    }
}
