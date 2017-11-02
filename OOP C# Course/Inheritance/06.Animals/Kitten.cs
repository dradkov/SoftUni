using System;


public class Kitten : Animal
{
    public Kitten(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string IntroduceAnimal()
    {
        return $"{typeof(Kitten)}" + Environment.NewLine + $"{base.Name} {base.Age} {base.Genger}";
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}
