using System;

public class Cat : Animal
{
    public Cat(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string IntroduceAnimal()
    {
        return $"{typeof(Cat)}" + Environment.NewLine + $"{base.Name} {base.Age} {base.Genger}";
    }

    public override string ProduceSound()
    {
        return "Meow meow";
    }
}

