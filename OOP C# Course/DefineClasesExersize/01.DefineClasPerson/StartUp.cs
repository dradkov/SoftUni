namespace DefineClassPerson
{
    using System;
    using System.Reflection;

   public class StartUp
    {
        static void Main()
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            var numLines = int.Parse(Console.ReadLine());

            var member = new Family();

            for (int i = 0; i < numLines; i++)
            {
                var split = Console.ReadLine().Split();

                var person = new Person(split[0], int.Parse(split[1]));

                member.AddMember(person);
            }

            var oldest = member.GetOldestMember();

            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}

