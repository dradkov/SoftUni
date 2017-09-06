using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const double DefaultRegeneration = 10.0;
    private const double MaxEndurance = 100.0;
    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = this.FillWeapons();
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public double Experience { get; private set; }

    public double Endurance
    {
        get => this.endurance;
        protected set
        {
            if (value > MaxEndurance)
            {
                this.endurance = MaxEndurance;
            }
            else
            {
                this.endurance = value;
            }
        }
    }

    public abstract double OverallSkill { get; }

    public IDictionary<string, IAmmunition> Weapons { get; }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public virtual void Regenerate()
    {
        this.Endurance += this.Age + DefaultRegeneration;
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;
        this.AmmunitionRevision(mission.WearLevelDecrement);
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    private IDictionary<string, IAmmunition> FillWeapons()
    {
        var weapons = new Dictionary<string, IAmmunition>();

        foreach (var weapon in this.WeaponsAllowed)
        {
            weapons.Add(weapon, null);
        }

        return weapons;
    }

    public override string ToString()
    {
        return string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
    }
}