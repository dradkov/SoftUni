
using System.Collections.Generic;

public abstract class Command : ICommand
{
    protected Command(List<string> args , IManager manager)
    {
        this.Args = args;
        this.Maneger = manager;
    }

    public IManager Maneger { get;protected set; }

    protected List<string> Args { get;  set; }


    public abstract string Execute();


}

