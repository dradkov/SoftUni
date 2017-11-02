using System;

public class Frog : Animal
{
    public Frog(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string IntroduceAnimal()
    {
        return $"{typeof(Frog)}" + Environment.NewLine + $"{base.Name} {base.Age} {base.Genger}";
    }

    public override string ProduceSound()
    {
        return "Ribbit";
    }
}
