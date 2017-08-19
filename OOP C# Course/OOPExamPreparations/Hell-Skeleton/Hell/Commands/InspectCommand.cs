
using System.Collections.Generic;

public class InspectCommand : Command
{
    public InspectCommand(List<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        return base.Maneger.Inspect(this.Args);
    }
}

