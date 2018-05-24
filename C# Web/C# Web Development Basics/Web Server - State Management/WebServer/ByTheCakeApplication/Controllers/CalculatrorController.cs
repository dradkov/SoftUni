namespace WebServer.ByTheCakeApplication.Controllers
{
    using System.Collections.Generic;
    using Infrastructure;
    using Server.Http.Contracts;

    public class CalculatrorController : Controller
    {
        public IHttpResponse Calculate()
        {
            Dictionary<string, string> calcValues = new Dictionary<string, string>
            {
                ["result"] = string.Empty
            };

            return this.FileViewResponse(@"calculator\calculator", calcValues);
        }
        public IHttpResponse Calculate(string firstNum, string secondNum, string operand)
        {

            string result = string.Empty;

            const string InvalidOperation = "Invalid Operation, cannot divide by zero";
            const string InvalidOperand = "InvalidOperand";

            List<string> operators = new List<string> { "+", "-", "*", "/" };

            if (!operators.Contains(operand))
            {
                result = InvalidOperand;
            }
            else
            {
                decimal num1 = decimal.Parse(firstNum);
                decimal num2 = decimal.Parse(secondNum);
                decimal tempResult = 0;

                switch (operand)
                {
                    case "+": tempResult = num1 + num2; break;
                    case "-": tempResult = num1 - num2; break;
                    case "*": tempResult = num1 * num2; break;
                    case "/":
                        if (num2 == 0)
                        {
                            result = InvalidOperation; break;
                        }

                        tempResult = num1 / num2; break;


                }

                if (result != InvalidOperation)
                {
                    result = tempResult.ToString();
                }
            }

            Dictionary<string, string> calcValues = new Dictionary<string, string>
            {
                ["result"] = result
            };

            return this.FileViewResponse(@"calculator\calculator", calcValues);
        }
    }
}
