namespace ManKind.Models
{
    using System;

public class StrtUpManKind
{
        static void Main()
        {
            var studentInfo = Console.ReadLine();

            var split = studentInfo.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var firstnameS = split[0];
                var lastNameS = split[1];
                var facNum = split[2];

                var student = new Student(firstnameS, lastNameS, facNum);
                var workerInfo = Console.ReadLine();

                var splitW = workerInfo.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                var firstnameW = splitW[0];
                var lastNameW = splitW[1];
                var weekSalary = decimal.Parse(splitW[2]);
                var hoursPerDay = decimal.Parse(splitW[3]);

                var worker = new Worker(firstnameW, lastNameW, weekSalary, hoursPerDay);


                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}

