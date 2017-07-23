
using System;

public class Citizen : IParticipant,IBirthable,IPerson
{


    public Citizen(string name,int age,string id,string birthDay)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.BirthDay = birthDay;
    }

    public string Id { get; private set; }
    public int Age { get; private set; }
    public string Name { get; private set; }
    public string BirthDay { get; private set; }

    public int Food { get; private set; }

    public void BuyFood()
    {
        this.Food += 10;
    }
}

