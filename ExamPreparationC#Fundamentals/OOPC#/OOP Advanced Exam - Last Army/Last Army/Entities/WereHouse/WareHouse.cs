
using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private readonly AmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.ammunitionFactory = new AmmunitionFactory();
        this.Ammunitions = new Dictionary<string, List<IAmmunition>>();
    }

    public Dictionary<string, List<IAmmunition>> Ammunitions { get; }

    public IAmmunition CreateAmmunition(string name)
    {
        return this.ammunitionFactory.CreateAmmunition(name);
    }

    public void AddAmmunitions(IAmmunition ammunition, int number)
    {
        if (!this.Ammunitions.ContainsKey(ammunition.Name))
        {
            this.Ammunitions[ammunition.Name] = new List<IAmmunition>();
        }

        for (int i = 0; i < number; i++)
        {
            this.Ammunitions[ammunition.Name].Add(ammunition);
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            var neededWeapons = soldier.Weapons.Where(w => w.Value == null).ToList();

            foreach (var kvp in neededWeapons)
            {
                var ammoName = kvp.Key;

                if (this.Ammunitions.ContainsKey(ammoName) && this.Ammunitions[ammoName].Count > 0)
                {
                    soldier.Weapons[ammoName] = ammunitionFactory.CreateAmmunition(ammoName);
                    this.Ammunitions[ammoName].RemoveAt(0);
                }
            }
        }
    }

    public bool SoldierCanBeEquipped(ISoldier soldier)
    {
        foreach (var ammunition in soldier.Weapons.Keys)
        {
            if (!this.Ammunitions.ContainsKey(ammunition) || this.Ammunitions[ammunition].Count == 0)
            {
                return false;
            }
        }

        return true;
    }

    public void EquipSoldier(ISoldier soldier)
    {
        var neededWeapons = soldier.Weapons.Keys.ToList();
        foreach (var weapon in neededWeapons)
        {
            soldier.Weapons[weapon] = ammunitionFactory.CreateAmmunition(weapon);
            this.Ammunitions[weapon].RemoveAt(0);
        }
    }
}