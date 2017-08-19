
public class Assassin : AbstractHero
{
    private const int AssassinStrength = 25;
    private const int AssassinAgility = 100;
    private const int AssassinIntelligence = 15;
    private const int AssassinHitPoints = 150;
    private const int AssassinDamage = 300;


    public Assassin(string name)
    {
        this.Name = name;
        this.Strength = AssassinStrength;
        this.Agility = AssassinAgility;
        this.Intelligence = AssassinIntelligence;
        this.HitPoints = AssassinHitPoints;
        this.Damage = AssassinDamage;
    }
}

