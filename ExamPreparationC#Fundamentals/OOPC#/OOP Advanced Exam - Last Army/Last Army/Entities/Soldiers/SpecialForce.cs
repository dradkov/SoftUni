using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OverallSkillMultiplier = 3.5;
    private const double DefaultRegeneration = 30d;
    private const double MaxEndurance = 100d;

    private readonly List<string> weaponsAllowed = new List<string>
    {
        nameof(Gun),
        nameof(AutomaticMachine),
        nameof(Helmet),
        nameof(MachineGun),
        nameof(Knife),
        nameof(RPG),
        nameof(NightVision)
    };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    public override double OverallSkill => (this.Age + this.Experience) * OverallSkillMultiplier;

    public override void Regenerate()
    {
        this.Endurance += this.Age + DefaultRegeneration;
        if (this.Endurance > MaxEndurance)
        {
            this.Endurance = MaxEndurance;
        }
    }
}