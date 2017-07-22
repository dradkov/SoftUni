namespace StudentsbyGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupStudents
    {
        static void Main(string[] args)
        {
            var entrance = Console.ReadLine();

            var name = new List<Student>();



            while (entrance != "END")
            {
                var splitEntrance = entrance.Split();

                var firstNameStudent = splitEntrance[0];
                var lastNameStudent = splitEntrance[1];
                var groupNumber = int.Parse(splitEntrance[2]);

                if (groupNumber == 2)
                {
                    var student = new Student(firstNameStudent, lastNameStudent);

                    name.Add(student);
                }


                entrance = Console.ReadLine();
            }

            var ordered = name.OrderBy(x => x.FirstName);

            foreach (var item in ordered)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }


        }
        public class Student
        {
            public Student(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }

        }
    }
}
