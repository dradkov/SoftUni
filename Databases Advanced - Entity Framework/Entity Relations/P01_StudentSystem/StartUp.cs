using System;

namespace P01_StudentSystem
{
    using System.Collections.Generic;
    using P01_StudentSystem.Data;
    using P01_StudentSystem.Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            StudentSystemContext db = new StudentSystemContext();

            using (db)
            {
                Seed(db);
            }
        }

        private static void Seed(StudentSystemContext db)
        {
            List<Student> students = new List<Student>
            {
                new Student()
                {
                    Name = "Pesho",
                    PhoneNumber = "0123456789",
                    RegisteredOn = new DateTime(2003,12,23),
                    Birthday = new DateTime(2000,11,23)
                    
                },
                new Student()
                {
                    Name = "Georgi",
                    PhoneNumber = "0123456786",
                    RegisteredOn = new DateTime(2004,11,18),
                    Birthday = new DateTime(1999,5,1)

                },
                new Student()
                {
                    Name = "Stanimir",
                    PhoneNumber = "0012345678",
                    RegisteredOn = new DateTime(2017,1,3),
                    Birthday = new DateTime(1985,03,15)

                },


            };

            db.Students.AddRange(students);



            db.SaveChanges();


        }
    }
}
