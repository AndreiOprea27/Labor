namespace Labor
{
    public class ShuntingYard
    {
        public static Queue<string> InfixToPostfix(IEnumerable<string> tokens, Func<string, int> getPrecedence, Func<string, bool> isLeftAssociative)
        {
            var outputQueue = new Queue<string>();
            var operatorStack = new Stack<string>();
            string previoustoken = "";
            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _))
                {
                    outputQueue.Enqueue(token);
                }
                else if (token == "(" || token == "[")
                {
                    operatorStack.Push(token);
                }
                else if (token == "-" && (previoustoken == "(" || previoustoken == "["))
                {
                    outputQueue.Enqueue(token);
                }
                else if (token == ")" || token == "]")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(" && operatorStack.Peek() != "[")
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Pop();
                }
                else if (token == "^") operatorStack.Push(token);
                else if (token == "<" && previoustoken == "<")
                {
                    operatorStack.Pop();
                    operatorStack.Push("<<");
                }
                else if (token == ">" && previoustoken == ">")
                {
                    operatorStack.Pop();
                    operatorStack.Push(">>");
                }
                else if (Alphabet.AlphabetArray.Contains(token))
                {
                    outputQueue.Enqueue(token);
                }
                else
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(" && operatorStack.Peek() != "[" &&
                           (getPrecedence(operatorStack.Peek()) > getPrecedence(token) ||
                            (getPrecedence(operatorStack.Peek()) == getPrecedence(token) && isLeftAssociative(token))))
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
                previoustoken = token;
            }
            while (operatorStack.Count > 0)
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }
            return outputQueue;
        }
    }
}
