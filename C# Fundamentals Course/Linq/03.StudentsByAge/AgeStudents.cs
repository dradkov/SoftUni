namespace StudentsByAge
{
    using System;
    using System.Collections.Generic;

    public class AgeStudents
    {
        static void Main(string[] args)
        {

            var entrance = Console.ReadLine();

            var names = new List<Student>();

            while (entrance != "END")
            {
                var splitEntrance = entrance
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var firstNameStudent = splitEntrance[0];
                var lastNameStudent = splitEntrance[1];
                var ageStudent = int.Parse(splitEntrance[2]);


                var student = new Student(firstNameStudent, lastNameStudent, ageStudent);

                if (ageStudent >= 18 && ageStudent <= 24)
                {
                    names.Add(student);
                }


                entrance = Console.ReadLine();
            }

            foreach (var name in names)
            {
                Console.WriteLine($"{name.FirstName} {name.LastName} {name.Age}");
            }

        }
        public class Student
        {
            public Student(string firstName, string lastName, int age)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;

            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }

        }
    }
}
