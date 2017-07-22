namespace SortStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentSort
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


                names.Add(student);



                entrance = Console.ReadLine();
            }

            var result = names.OrderBy(n => n.LastName).ThenByDescending(n => n.FirstName).ToList();

            foreach (var name in result)
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
