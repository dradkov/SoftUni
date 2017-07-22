namespace StudentsResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ResultStudents
    {
        static void Main()
        {


            var dictStudents = new Dictionary<string, List<double>>();

            var commands = int.Parse(Console.ReadLine());



            for (int i = 0; i < commands; i++)
            {
                var studentInfo = Console.ReadLine().Split('-');

                var name = studentInfo[0];
                var splitScore = studentInfo[1].Split(',');

                var list = new List<double>();

                list.Add(double.Parse(splitScore[0]));
                list.Add(double.Parse(splitScore[1]));
                list.Add(double.Parse(splitScore[2]));

                if (!dictStudents.ContainsKey(name))
                {
                    dictStudents.Add(name, new List<double>());
                }
                dictStudents[name].AddRange(list);
               
            }


            Console.WriteLine
                   (string.Format($"{"Name",-10}|{"CAdv",7}|{"COOP",7}|{"AdvOOP",7}|{"Average",7}|"));


            foreach (var student  in dictStudents)
            {
                var name = student.Key;
                var list = student.Value.ToList();
                var avarage = list.Average();
                
                var first =list[0];
                var second =list[1];
                var third = list[2];


                
                    Console.WriteLine
                    (string.Format
                    ($"{name,-10}|{first,7:F2}|{second,7:F2}|{third,7:F2}|{avarage,7:F4}|"));
                

            }

        }
    }
}
