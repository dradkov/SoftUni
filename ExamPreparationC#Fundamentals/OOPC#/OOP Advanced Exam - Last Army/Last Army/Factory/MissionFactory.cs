using System;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type type = Type.GetType(difficultyLevel);

        IMission instance = (IMission)Activator.CreateInstance(type, new object[] {neededPoints});

        return instance;
    }
}

