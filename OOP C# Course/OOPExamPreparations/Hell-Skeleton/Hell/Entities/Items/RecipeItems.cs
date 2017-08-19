using System.Collections.Generic;

public class RecipeItems : Items, IRecipe
{
    public RecipeItems(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, params string[] items)
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {
        this.RequiredItems = new List<string>();

        foreach (var item in items)
        {
            this.RequiredItems.Add(item);
        }
    }

    public List<string> RequiredItems { get; }
}

