
using System;

public class Pet : INameable, IBirthable
{


    public Pet(string name,string birthDay)
    {
        this.Name = name;
        this.BirthDay = birthDay;
    }


    public string BirthDay { get; private set; }

    public string Name { get; private set; }
}

