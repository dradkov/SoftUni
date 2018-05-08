namespace StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using StudentSystem.Data;
    using StudentSystem.Data.Models;
    using StudentSystem.Data.Models.Enums;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (StudentSystemDbContext db = new StudentSystemDbContext())
            {
                SetDb(db);
                SeedSomeData(db);
                RelateTables(db);
                //AllStudentAndHomework(db);
                //AllCoursesAndResourses(db);
                //AllCoursesWithMoreThanXResources(db);
                //ListAllCoursesGivenDate(db);
                //ListStudentWithCourses(db);
                //ListCoursesAndResourses(db);
                //ListStudentCoursesResoursesLicense(db);
            }
        }

      

        //01 Resource Licenses
        private static void ListCoursesAndResourses(StudentSystemDbContext db)
        {
            var courses = db.Courses.Select(c => new
            {
                c.Name,
                ResourcessInfo = c.Resources.Select(e => new
                {
                    e.Name,
                    LicenseNames = e.Licenses.Select(l => new
                    {
                        l.Name
                    }),
                    LicenseCount = e.Licenses.Count
                }).OrderByDescending(s => s.LicenseCount).ThenBy(s => s.Name),
                ResoursesCount = c.Resources.Count

            }).OrderByDescending(c => c.ResoursesCount).ThenBy(c => c.Name).ToArray();

            foreach (var c in courses)
            {
                Console.WriteLine($"Course Name {c.Name}");
                foreach (var r in c.ResourcessInfo)
                {
                    Console.WriteLine($"    ResourseName {r.Name} ");
                    foreach (var lm in r.LicenseNames)
                    {
                        Console.WriteLine($"        LicenseName {lm.Name}");
                    }
                }
            }
        }
        //02 Resource Licenses
        private static void ListStudentCoursesResoursesLicense(StudentSystemDbContext db)
        {
            var students = db.Students.Select(s => new
            {
                s.Name,
                CoursesCount = s.Courses.Count,
                Resourses = s.Courses.Select(r => new
                {
                    ResCount = r.Course.Resources.Count,
                    ResLicense = r.Course.Resources.Select(rs => new
                    {
                        LicenseCount = rs.Licenses.Count

                    })
                }).OrderByDescending(c => c.ResCount)

            }).OrderByDescending(c => c.CoursesCount).ThenBy(c => c.Name).ToArray();

            foreach (var s in students)
            {
                Console.WriteLine($"Name {s.Name} Courses Number {s.CoursesCount}");
                foreach (var r in s.Resourses)
                {
                    Console.WriteLine($"    Resourses Count : {r.ResCount}");

                    Console.WriteLine($"        License Count : {r.ResLicense.Sum(c => c.LicenseCount)}");

                }
            }
        }

        //01 Working with the Database
        private static void AllStudentAndHomework(StudentSystemDbContext db)
        {
            var students = db.Students.Select(s => new
            {
                s.Name,
                HomeworksSubmits = s.Homeworks.Select(w => new
                {
                    w.Content,
                    w.ContentType

                })
            }).ToArray();

            foreach (var s in students)
            {
                Console.WriteLine(s.Name);
                foreach (var h in s.HomeworksSubmits)
                {
                    Console.WriteLine($"{h.Content} - {h.ContentType}");
                }
            }
        }
        //02 Working with the Database
        private static void AllCoursesAndResourses(StudentSystemDbContext db)
        {
            var courses = db.Courses.Select(c => new
            {
                c.Name,
                c.Description,
                c.StartDate,
                c.EndDate,
                c.Resources

            })
            .OrderBy(x => x.StartDate)
            .ThenBy(c => c.EndDate)
            .ToArray();


            foreach (var c in courses)
            {
                Console.WriteLine($"Name - {c.Name} => Descrption {c.Description}");
                Console.WriteLine("Resourses as following : ");
                foreach (var r in c.Resources)
                {
                    Console.WriteLine($"Name : {r.Name}");
                    Console.WriteLine($"ResourseType : {r.Resourse}");
                    Console.WriteLine($"Url : {r.Url}");
                }
            }
        }
        //03 Working with the Database
        private static void AllCoursesWithMoreThanXResources(StudentSystemDbContext db)
        {
            var courses = db.Courses.Where(s => s.Resources.Count >= 5).Select(c => new
            {
                c.Name,
                c.StartDate,
                Resources = c.Resources.Count


            })
                .OrderByDescending(c => c.Resources)
                .ThenBy(c => c.StartDate)
                .ToArray();

            foreach (var c in courses)
            {
                Console.WriteLine($"{c.Name} => {c.Resources}");
            }
        }
        //04 Working with the Database
        private static void ListAllCoursesGivenDate(StudentSystemDbContext db)
        {
            var courses = db.Courses.Where(c => c.StartDate >= new DateTime(2004, 2, 10)).Select(c => new
            {
                c.Name,
                c.StartDate,
                c.EndDate,
                Students = c.Students.Count
            }).OrderByDescending(c => c.Students)
                .ThenBy(c => (c.EndDate - c.StartDate).Days)
                .ToArray();

            foreach (var c in courses)
            {
                Console.WriteLine($"Course {c.Name} , Starts {c.StartDate}, Ends {c.EndDate}");
                Console.WriteLine($"    Duration {(c.EndDate - c.StartDate).Days} Students Enrolled {c.Students}");
            }

        }
        //05 Working with the Database
        private static void ListStudentWithCourses(StudentSystemDbContext db)
        {
            var students = db.Students.Select(s => new
            {
                s.Name,
                CoursesCount = s.Courses.Count,
                TotalPrice = s.Courses.Sum(c => c.Course.Price),
                AvaragePrice = s.Courses.Average(c => c.Course.Price)

            }).ToArray();

            foreach (var s in students)
            {
                Console.WriteLine($"Name : {s.Name}, Number of Courses {s.CoursesCount}");
                Console.WriteLine($"    Total Price {s.TotalPrice}  Avarage Price {s.AvaragePrice:f2}");
            }
        }

        private static void SetDb(StudentSystemDbContext db)
        {
            Console.WriteLine("Loading....");

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            Console.WriteLine("Database was created successfuly");
            Console.Clear();

        }

        private static void SeedSomeData(StudentSystemDbContext db)
        {
            List<Student> students = new List<Student>
            {
                new Student()
                {
                    Name = "Pesho",
                    PhoneNumber = "0123456789",
                    RegistrationTime = new DateTime(2003,12,23),
                    Birthday = new DateTime(2000,11,23)

                },
                new Student()
                {
                    Name = "Georgi",
                    PhoneNumber = "0123456786",
                    RegistrationTime = new DateTime(2004,11,18),
                    Birthday = new DateTime(1999,5,1)

                },
                new Student()
                {
                    Name = "Stanimir",
                    PhoneNumber = "0012345678",
                    RegistrationTime= new DateTime(2017,1,3),
                    Birthday = new DateTime(1985,03,15)

                },


            };
            List<Course> courses = new List<Course>()
            {
                new Course()
                {
                    Name = "History",
                    Description = "Learning History",
                    Price = 210,
                    StartDate = new DateTime(2005,10,14),
                    EndDate = new DateTime(2008,10,11)
                },
                new Course()
                {
                    Name = "Biology",
                    Description = "Learning Biology",
                    Price = 210,
                    StartDate = new DateTime(2012,5,2),
                    EndDate = new DateTime(2017,10,11)
                },
                new Course()
                {
                    Name = "Math",
                    Description = "Learning Math",
                    Price = 100,
                    StartDate = new DateTime(2000,1,2),
                    EndDate = new DateTime(2001,6,11)
                },
                new Course()
                {
                    Name = "History",
                    Description = "Learning English",
                    Price = 25.10M,
                    StartDate = new DateTime(2006,3,2),
                    EndDate = new DateTime(2008,10,11)
                },
                new Course()
                {
                    Name = "History",
                    Description = "Learning Informatics",
                    Price = 18.32M,
                    StartDate = new DateTime(2000,11,24),
                    EndDate = new DateTime(2003,12,11)
                },
            };
            List<Homework> homeworks = new List<Homework>()
            {
                new Homework()
                {
                    Content = "File",
                    ContentType = ContentType.Application,
                    SubmitionTime = new DateTime(2005,10,8),
                    CourseId = 1,
                    StudentId = 1


                },
                new Homework()
                {
                    Content = "FileZip",
                    ContentType = ContentType.Zip,
                    SubmitionTime = new DateTime(2006,12,8),
                    CourseId = 2,
                    StudentId = 1

                },
                new Homework()
                {
                    Content = "FilePDF",
                    ContentType = ContentType.Pdf,
                    SubmitionTime = new DateTime(2000,6,6),
                    CourseId = 3,
                    StudentId = 2

                },
                new Homework()
                {
                    Content = "FileAnother",
                    ContentType = ContentType.Application,
                    SubmitionTime = new DateTime(2005,12,1),
                    CourseId = 1,
                    StudentId = 2
                },
                new Homework()
                {
                    Content = "FileP",
                    ContentType = ContentType.Pdf,
                    SubmitionTime = new DateTime(2004,3,7),
                    CourseId = 3,
                    StudentId = 3
                }
            };
            List<Resource> resources = new List<Resource>()
            {
                new Resource()
                {
                    Name = "Wiki",
                    Resourse = ResourseType.Document,
                    Url = "neshoto.jpeg",
                    CourseId = 1

                },
                new Resource()
                {
                    Name = "Book",
                    Resourse = ResourseType.Other,
                    Url = "neshoto.jpeg",
                    CourseId = 2
                },
                new Resource()
                {
                    Name = "Edin Priqtel",
                    Resourse = ResourseType.Presentation,
                    Url = "neshoto.jpeg",
                    CourseId = 3
                },
                new Resource()
                {
                    Name = "Video",
                    Resourse = ResourseType.Video,
                    Url = "neshoto.jpeg",
                    CourseId = 2
                },
                new Resource()
                {
                    Name = "Doc",
                    Resourse = ResourseType.Document,
                    Url = "neshoto.jpeg",
                    CourseId = 3
                },
                new Resource()
                {
                    Name = "Oshte edno Video",
                    Resourse = ResourseType.Video,
                    Url = "neshoto.jpeg",
                    CourseId = 1
                },
                new Resource()
                {
                    Name = "Oshte edno Video",
                    Resourse = ResourseType.Document,
                    Url = "neshoto.jpeg",
                    CourseId = 1
                },
                new Resource()
                {
                    Name = "Oshte p",
                    Resourse = ResourseType.Presentation,
                    Url = "neshoto.jpeg",
                    CourseId = 2
                },
                new Resource()
                {
                    Name = "Oshte pres",
                    Resourse = ResourseType.Video,
                    Url = "neshoto.jpeg",
                    CourseId = 2
                },
                new Resource()
                {
                    Name = "Oshte pak",
                    Resourse = ResourseType.Video,
                    Url = "neshoto.jpeg",
                    CourseId = 2
                },
            };
            List<License> licenses = new List<License>()
            {
                new License()
                {
                    Name = "Super License",
                    ResourseId = 1
                },
                new License()
                {
                    Name = "Best License",
                    ResourseId = 2,
                },
                new License()
                {
                    Name = "Hiper License",
                    ResourseId = 3,
                },
                new License()
                {
                    Name = "Mega License",
                    ResourseId = 4,
                },
                new License()
                {
                    Name = "Giga License",
                    ResourseId = 5
                },

            };

            db.Students.AddRange(students);
            db.Courses.AddRange(courses);
            db.SaveChanges();
            db.Homeworks.AddRange(homeworks);
            db.Resources.AddRange(resources);
            db.SaveChanges();
            db.Licenses.AddRange(licenses);
            db.SaveChanges();

        }

        private static void RelateTables(StudentSystemDbContext db)
        {

            Student student = db.Students.Find(1);
            Course course = db.Courses.Find(2);
            Student student1 = db.Students.Find(3);
            Course course1 = db.Courses.Find(1);
            Student student2 = db.Students.Find(2);
            Course course2 = db.Courses.Find(3);


            course.Students.Add(new StudentCourses()
            {
                Student = student
            });
            course1.Students.Add(new StudentCourses()
            {
                Student = student1
            });
            course2.Students.Add(new StudentCourses()
            {
                Student = student2
            });

            student.Courses.Add(new StudentCourses()
            {
                Course = course1
            });

            student2.Courses.Add(new StudentCourses()
            {
                Course = course
            });

            db.SaveChanges();


        }
    }
}
