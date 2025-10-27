using System.Numerics;

namespace Labor
{
    public class RpnEvaluator
    {
        public static double Evaluate(string rpnExpression)
        {
            var tokens = rpnExpression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<double>();
            string previoustoken = "";
            double result = 0;
            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double number))
                {
                    stack.Push(number);
                    previoustoken = token;
                }
                else if (double.TryParse(token, out double number1))
                {
                    stack.Push(-number);
                    previoustoken = token;
                }
                else
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    if (token == "/" && right == 0)
                    {
                        throw new DivideByZeroException("Division durch Null ist nicht erlaubt.");
                    }

                    if (token == "+") result = left + right;
                    else if (token == "-") result = left - right;
                    else if (token == "*") result = left * right;
                    else if (token == "/") result = left / right;
                    else if (token == "^") result = Power(left, right);
                    else throw new InvalidOperationException($"Unknown operator: {token}");
                    stack.Push(result);
                    previoustoken = token;
                }
            }
            return stack.Pop();
        }

        public static double Power(double left, double right)
        {
            double result = left;
            while (right > 0)
            {
                result = result * left;
                right--;
            }
            return result;
        }
    }
}
