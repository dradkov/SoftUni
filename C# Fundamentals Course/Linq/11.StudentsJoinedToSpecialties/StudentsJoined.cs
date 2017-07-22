namespace StudentsJoinedToSpecialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsJoined
    {
        static void Main(string[] args)
        {

            var info = Console.ReadLine();

            var student = new List<Student>();

            var speciality = new List<StudentSpecialty>();

            while (info != "Students:")
            {
                var splitInfo = info.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                speciality.Add(new StudentSpecialty(splitInfo[0] + " " + splitInfo[1], int.Parse(splitInfo[2])));

                info = Console.ReadLine();

            }
            info = Console.ReadLine();
            while (info != "END")
            {
                var splitInfo = info.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                student.Add(new Student(int.Parse(splitInfo[0]), splitInfo[1] + " " + splitInfo[2]));
                info = Console.ReadLine();
            }


            var result =
                speciality.Join(student, sp => sp.FacultetyNumber, st => st.FacultetyNumber, (sp, st) =>
                  new { Name = st.Name, FacultNum = sp.FacultetyNumber, Spec = sp.SpecialityName }).OrderBy(res => res.Name);

            foreach (var students in result)
            {
                Console.WriteLine($"{students.Name} {students.FacultNum} {students.Spec}");
            }

        }

        public class Student
        {
            public Student(int facultetyNum, string name)
            {
                FacultetyNumber = facultetyNum;
                Name = name;

            }

            public int FacultetyNumber { get; set; }
            public string Name { get; set; }

        }

        public class StudentSpecialty
        {
            public StudentSpecialty(string specialityname, int facNum)
            {
                SpecialityName = specialityname;
                FacultetyNumber = facNum;

            }
            public string SpecialityName { get; set; }
            public int FacultetyNumber { get; set; }
        }
    }
}
