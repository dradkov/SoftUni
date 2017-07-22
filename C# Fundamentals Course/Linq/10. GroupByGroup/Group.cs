namespace GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public  class Group
    {
        static void Main(string[] args)
        {

            var studentInfo = Console.ReadLine();

            var listPerson = new List<Person>();

            while (studentInfo != "END")
            {
                var splitStudentInfo = studentInfo.Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);

                var firstName = splitStudentInfo[0];
                var lastName = splitStudentInfo[1];
                var groupStudent = int.Parse(splitStudentInfo[2]);

                var student = new Person(firstName + " " + lastName, groupStudent);
                listPerson.Add(student);


                studentInfo = Console.ReadLine();
            }

            var ordered = listPerson.GroupBy(x => x.Group).OrderBy(x => x.Key);

            foreach (var person in ordered)
            {
                Console.Write($"{person.Key} - ");
                var sb = new StringBuilder();
                foreach (var name in person)
                {
                    sb.Append(name.Name).Append(", ");

                }
                sb.Length -= 2;
                Console.WriteLine(sb);
            }


        }
        public class Person
        {
            public Person(string name, int group)
            {
                Name = name;
                Group = group;

            }

            public string Name { get; set; }
            public int Group { get; set; }
        }
    }
}
