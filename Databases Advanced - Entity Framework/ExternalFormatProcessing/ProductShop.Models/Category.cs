namespace ProductShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Category
    {
        public int CategoryId { get; set; }

        
        [MinLength(3), MaxLength(15)]
        public string Name { get; set; }

        public ICollection<CategoryProduct> Products { get; set; } = new HashSet<CategoryProduct>();


    }
}
