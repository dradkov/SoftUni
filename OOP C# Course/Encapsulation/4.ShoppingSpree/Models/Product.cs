namespace ShopingSpree.Models
{
    using System;

public class Product
{
    private string name;
    private decimal coast;



    public Product(string name, decimal coast)
    {
        this.Name = name;
        this.Coast = coast;

    }


    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value == string.Empty || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }


    }
    public decimal Coast
        {
            get { return this.coast; }
            private set
            {

                this.coast = value;
            }
        }

    }
}
