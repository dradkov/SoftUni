namespace StudentsByFirstAndLastName
{
    using System;
    using System.Collections.Generic;

    public class StudentsFirstAndLastName
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


                var student = new Student(firstNameStudent, lastNameStudent);

                if (student.FirstName.CompareTo(student.LastName) == -1)
                {
                    names.Add(student);
                }



                entrance = Console.ReadLine();
            }

            foreach (var name in names)
            {
                Console.WriteLine($"{name.FirstName} {name.LastName}");
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
