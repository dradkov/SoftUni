namespace WebServer.ByTheCakeApplication.Models
{
   public class Cake
    {
        public Cake(string name,decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
