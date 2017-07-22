namespace ManKind.Models
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal hoursPerDay;
        private decimal salaryPerHour;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal hoursPerDay)
            : base(firstName, lastName)
        {

            this.WeekSalary = weekSalary;
            this.HoursPerDay = hoursPerDay;
            this.SalaryPerHour = salaryPerHour;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }
        public decimal HoursPerDay
        {
            get { return this.hoursPerDay; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.hoursPerDay = value;
            }
        }
        public decimal SalaryPerHour
        {
            get
            {
                return this.salaryPerHour = (this.WeekSalary / 5 / this.HoursPerDay);

            }
            set
            {
                this.salaryPerHour = value;
            }
        }
        public override string ToString()
        {

            var sb = new StringBuilder();
            sb.Append(base.ToString())
                .Append("Week Salary: ").AppendLine($"{this.WeekSalary:f2}")
                .Append("Hours per day: ").AppendLine($"{this.HoursPerDay:f2}")
                .Append("Salary per hour: ").AppendLine($"{this.SalaryPerHour:f2}");


            return sb.ToString();

        }
    }
}

