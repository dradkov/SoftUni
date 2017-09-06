using System;

public class SoldierFactory : ISoldierFactory
{

    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type type = Type.GetType(soldierTypeName);

        ISoldier instance = (ISoldier)Activator.CreateInstance(type, new object[] { name, age, experience, endurance });

        return instance;
    }
}
