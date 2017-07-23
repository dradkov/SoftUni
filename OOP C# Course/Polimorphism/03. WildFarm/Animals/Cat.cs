
public class Cat : Felime
{
    public Cat(string name, string type, double weight, string livigRegion, string breed)
        : base(name, type, weight, livigRegion)
    {
        this.Breed = breed;
    }

    private string Breed { get; set; }

    public override string MakeSound()
    {
        return "Meowwww";
    }

    public override string ToString()
    {
        return $"{this.Type}[{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }

}
