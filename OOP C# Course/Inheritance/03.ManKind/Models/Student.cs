namespace ManKind.Models
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10 || !value.All(char.IsLetterOrDigit))
                {
                    throw new ArgumentException("Invalid faculty number!");//SpaceBetweenNum and !
                }
                this.facultyNumber = value;
            }
        }
        private static bool IsNumberInvalid(string value)
        {
            bool isNumberInvalid = false;

            string numberPattern = @"^([0-9a-zA-Z]{5,10})$";

            var regex = new Regex(numberPattern);

            var match = regex.Match(value);

            if (match.Success)
                return isNumberInvalid;

            return !isNumberInvalid;
        }

        public override string ToString()
        {

            var sb = new StringBuilder();
            sb.Append(base.ToString())
                .Append("Faculty number: ").Append(this.FacultyNumber)
                .AppendLine();

            return sb.ToString();

        }
    }
}

