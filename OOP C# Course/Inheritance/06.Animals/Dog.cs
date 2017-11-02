using System.Text;

public class Dog : Animal
{
    public Dog(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string IntroduceAnimal()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{typeof(Dog)}")
            .Append($"{base.Name} {base.Age} {base.Genger}");
        return sb.ToString();
    }

    public override string ProduceSound()
    {
        return "Woof!";
    }
}
