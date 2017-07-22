namespace FilterStudentsByEmailDomain
{
    using System;
    using System.Collections.Generic;

   public class FilterStudents
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
                var email = splitEntrance[2];

                var substring = email.Substring(email.Length - 10);
                if (substring == "@gmail.com")
                {
                    var student = new Student(firstNameStudent, lastNameStudent);
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
