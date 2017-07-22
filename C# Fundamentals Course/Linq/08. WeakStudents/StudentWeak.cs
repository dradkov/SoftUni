namespace WeakStudents
{
    using System;
    using System.Collections.Generic;

    public class StudentsWeak
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
                var scoresStudent = new List<int>();

                for (int i = 2; i < splitEntrance.Length; i++)
                {
                    if (int.Parse(splitEntrance[i]) <= 3)
                    {
                        scoresStudent.Add(int.Parse(splitEntrance[i]));
                    }
                }

                if (scoresStudent.Count >= 2)
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
