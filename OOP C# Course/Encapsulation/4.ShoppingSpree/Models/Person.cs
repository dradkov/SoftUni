namespace ShopingSpree.Models
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;


        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();

        }


        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Name cannot be empty");
                }
                this.name = value;
            }


        }
        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new AggregateException("Money cannot be negative");
                }
                this.money = value;
            }


        }
        public void AddProducts(Product product)
        {
            this.bag.Add(product);
        }
        public List<Product> SeeBag()
        {
            return this.bag;
        }

    }
}

