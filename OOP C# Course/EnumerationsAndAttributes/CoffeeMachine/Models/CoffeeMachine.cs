
using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private int coins;
    private IList<CoffeeType> coffeeSold;


    public CoffeeMachine()
    {
        
        this.coffeeSold = new List<CoffeeType>();
    }


   public void BuyCoffee(string size, string type)
   {
       CoffeeType coffeeType = (CoffeeType) Enum.Parse(typeof(CoffeeType), type);
       CoffeePrice coffeePrice = (CoffeePrice) Enum.Parse(typeof(CoffeePrice), size);


        if (this.coins>= (int)coffeePrice)
        {
            coffeeSold.Add(coffeeType);
            this.coins = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        Coin insertCoins = (Coin) Enum.Parse(typeof(Coin), coin);

        this.coins += (int)insertCoins;
    }

    public IEnumerable<CoffeeType> CoffeesSold
    {
        get { return this.coffeeSold; }
    }

}

