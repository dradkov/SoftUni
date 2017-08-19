using System.Collections.Generic;

public class HeroCommand : Command
{
    public HeroCommand(List<string> args, IManager manager)
        : base(args, manager)
    {
    }

    public override string Execute()
    {
        return this.Maneger.AddHero(this.Args);
    }
}

