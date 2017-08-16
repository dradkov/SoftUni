namespace _03.DependencyInversion.Models
{
    using _03.DependencyInversion.Interfaces;

    public class AdditionStrategy : IMathStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
