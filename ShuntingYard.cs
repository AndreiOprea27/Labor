namespace Labor
{
    public class ShuntingYard
    {
        public static Queue<string> InfixToPostfix(IEnumerable<string> tokens, Func<string, int> getPrecedence, Func<string, bool> isLeftAssociative)
        {
            var outputQueue = new Queue<string>();
            var operatorStack = new Stack<string>();
            foreach (var token in tokens)
            {
                if (int.TryParse(token, out _))
                {
                    outputQueue.Enqueue(token);
                }
                else if (token == "(")
                {
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Pop();
                }
                else
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(" &&
                           (getPrecedence(operatorStack.Peek()) > getPrecedence(token) ||
                            (getPrecedence(operatorStack.Peek()) == getPrecedence(token) && isLeftAssociative(token))))
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
            }
            while (operatorStack.Count > 0)
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }
            return outputQueue;
        }
    }
}
