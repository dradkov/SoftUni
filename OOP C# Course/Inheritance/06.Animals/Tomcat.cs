using System;

public class Tomcat : Animal
{
    public Tomcat(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string IntroduceAnimal()
    {
        return $"{typeof(Tomcat)}" + Environment.NewLine + $"{base.Name} {base.Age} {base.Genger}";

    }

    public override string ProduceSound()
    {
        return "MEOW";
    }
}
