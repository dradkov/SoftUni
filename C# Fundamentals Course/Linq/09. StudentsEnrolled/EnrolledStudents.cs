namespace StudentsEnrolled
{
    using System;
    using System.Collections.Generic;

    public class EnrolledStudents
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Trim();

            var names = new List<Student>();


            while (input != "END")
            {
                var splitInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var facultyNumber = splitInput[0];

                var scoreStudent = new List<int>();

                var substringOne = facultyNumber.Substring(facultyNumber.Length - 2);
                var substringTwo = facultyNumber.Substring(facultyNumber.Length - 2);

                if (substringOne == "14" || substringOne == "15")
                {
                    for (int i = 1; i < splitInput.Length; i++)
                    {

                        scoreStudent.Add(int.Parse(splitInput[i]));
                    }
                    var student = new Student("Mark", "Test", scoreStudent);

                    names.Add(student);

                }

                input = Console.ReadLine();
            }

            foreach (var score in names)
            {
                Console.WriteLine($"{string.Join(" ", score.Marks)}");
            }


        }
        public class Student
        {
            public Student(string firstName, string lastName, List<int> marks)
            {
                FirstName = firstName;
                LastName = lastName;
                Marks = marks;

            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<int> Marks { get; set; }


        }
    }
}
