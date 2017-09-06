using System;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type type = Type.GetType(ammunitionName);

        IAmmunition instance = (IAmmunition) Activator.CreateInstance(type, new object[] {ammunitionName});

        return instance;
    }
}

