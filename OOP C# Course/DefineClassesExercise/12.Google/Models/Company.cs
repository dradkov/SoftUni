namespace Google.Models
{
    using System;
    public class Company
    {
        public string name;
        public string department;
        public decimal salary;

        public Company(string name, string department, decimal salary)
        {
            this.name = name;
            this.department = department;
            this.salary = salary;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2:F2}", this.name, this.department, this.salary);
        }
    }
}
