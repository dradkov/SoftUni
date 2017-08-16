namespace _03.DependencyInversion.Models
{
    using System.Collections.Generic;
    using _03.DependencyInversion.Interfaces;

    public class PrimitiveCalculator
    {

        private IDictionary<char, IMathStrategy> primaryStrategy = new Dictionary<char, IMathStrategy>
        {
            {'+',new AdditionStrategy()},
            {'-',new SubtractionStrategy()},
            {'*',new MultiplyStrategy()},
            {'/',new DevideStrategy()}
        };

        private IMathStrategy strategy;


        public PrimitiveCalculator(IMathStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ChangeStrategy(char @operator)
        {
            this.strategy = this.primaryStrategy[@operator];
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
           return  this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
