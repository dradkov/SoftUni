namespace FilterStudentsByPhone
{
    using System;
    using System.Collections.Generic;

    public class FilterByPhone
    {
        static void Main()
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

                var substringOne = email.Substring(0, 2);
                var substringTwo = email.Substring(0, 5);



                if (substringOne == "02" || substringTwo == "+3592")
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
