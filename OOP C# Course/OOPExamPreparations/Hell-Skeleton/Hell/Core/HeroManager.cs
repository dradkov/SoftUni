using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;


    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }


    public string AddHero(List<string> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type clazz = Type.GetType(heroType);
            var constructors = clazz.GetConstructors();
            IHero hero = (IHero)constructors[0].Invoke(new object[] { heroName });


            result = string.Format($"Created {heroType} - {hero.GetType().Name}");
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItemToHero(List<string> arguments, IHero hero)
    {
        string result = null;


        string itemName = arguments[0];
        string heroName = arguments[1];
        long strengthBonus = long.Parse(arguments[2]);
        long agilityBonus = long.Parse(arguments[3]);
        long intelligenceBonus = long.Parse(arguments[4]);
        long hitPointsBonus = long.Parse(arguments[5]);
        long damageBonus = long.Parse(arguments[6]);

        CommonItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus);


        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string AddRecepieToHero(List<string> arguments, IHero hero)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        long strengthBonus = long.Parse(arguments[2]);
        long agilityBonus = long.Parse(arguments[3]);
        long intelligenceBonus = long.Parse(arguments[4]);
        long hitPointsBonus = long.Parse(arguments[5]);
        long damageBonus = long.Parse(arguments[6]);

        string[] items = arguments.Skip(7).ToArray();

        RecipeItems newItem = new RecipeItems(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus, items);

        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);

        return result;

    }

    public string CreateGame()
    {
        StringBuilder result = new StringBuilder();

        foreach (var hero in heroes)
        {
            result.AppendLine(hero.Key);
        }

        return result.ToString();
    }

    public string Inspect(List<String> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    public string Quit()
    {
        StringBuilder sb = new StringBuilder();

        int counter = 1;

        List<AbstractHero> sortedHeroes = this.heroes.Values.Select(h => h as AbstractHero).ToList();

        foreach (var hero in sortedHeroes)
        {
            sb.AppendLine($"{counter++}.{hero.GetType().Name}: {hero.Name}");
            sb.AppendLine($"###HitPoints: {hero.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Damage}");
            sb.AppendLine($"###Strength: {hero.Strength}");
            sb.AppendLine($"###Agility: {hero.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Intelligence}");


            string items = (string.Join(", ", hero.Items.Select(i => i.Name)));

            if (items.Length == 0)
            {
                items = "None";
            }

            sb.AppendLine($"###Items: {items}");

        }

        return sb.ToString().Trim();
    }


}