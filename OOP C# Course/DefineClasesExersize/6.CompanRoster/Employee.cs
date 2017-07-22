namespace CompanRoster
{
    public class Employee
    {
        private string name;
        private decimal salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public Employee(string name, decimal salary, string position, string department, string email, int age)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = email;
            this.Age = age;
        }


        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public decimal Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }
        public string Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public string Department
        {
            get { return this.department; }
            set { this.department = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
    }
}

