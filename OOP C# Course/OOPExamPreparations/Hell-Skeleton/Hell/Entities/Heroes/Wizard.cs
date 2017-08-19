public class Wizard : AbstractHero
{
    private const int WizardStrength = 25;
    private const int WizardAgility = 25;
    private const int WizardIntelligence = 100;
    private const int WizardHitPoints = 100;
    private const int WizardDamage = 250;


    public Wizard(string name)
    {
        this.Name = name;
        this.Strength = WizardStrength;
        this.Agility = WizardAgility;
        this.Intelligence = WizardIntelligence;
        this.HitPoints = WizardHitPoints;
        this.Damage = WizardDamage;
    }
}

