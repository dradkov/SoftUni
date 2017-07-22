namespace AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GraduationAcademy
    {
        static void Main()
        {
            var studentScore = new Dictionary<string, List<double>>();

            var numberOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; i++)
            {
                var name = Console.ReadLine();
                var score = Console.ReadLine()
                    .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToList();

                if (!studentScore.ContainsKey(name))
                {
                    studentScore.Add(name, new List<double>());
                }
                studentScore[name].AddRange(score);
            }

            foreach (var student in studentScore.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }
        }
    }
}
