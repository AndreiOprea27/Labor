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
                    double result = token switch
                    {
                        "+" => left + right,
                        "-" => left - right,
                        "*" => left * right,
                        "/" => left / right,
                        "^" => Power(left, right),
                        _ => throw new InvalidOperationException($"Unknown operator: {token}")
                    };
                    stack.Push(result);
                    previoustoken = token;
                }
            }
            return stack.Pop();
        }

        public double Power(double left, double right)
        {
            while (right > 0)
            {
                left = left * right;
                right--;
            }
            return left;
        }
    }
}
