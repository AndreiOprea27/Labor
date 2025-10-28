using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor
{
    public static class AstBuilder
    {
        public static AstNode BuildAstFromRpn(Queue<string> tokens)
        {
            Stack<AstNode> stack = new Stack<AstNode>();

            while (tokens.Count > 0)
            {
                string token = tokens.Dequeue();

                if (!IsOperator(token))
                {
                    stack.Push(new AstNode(token));
                }
                else
                {
                    if (stack.Count < 2)
                        throw new InvalidOperationException("Invalide RPN Expression.");

                    AstNode right = stack.Pop();
                    AstNode left = stack.Pop();

                    AstNode node = new AstNode(token)
                    {
                        Left = left,
                        Right = right
                    };

                    stack.Push(node);
                }
            }

            if (stack.Count != 1)
                throw new InvalidOperationException("Invalide RPN Expression.");

            return stack.Pop();
        }

        private static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/" || token == "^"
                || token == "<<" || token == ">>";
        }

        public static void PrintAst(AstNode node, string indent = "", bool isLeft = true)
        {
            if (node == null)
                return;

            Console.WriteLine(indent + (isLeft ? "├── " : "└── ") + node.Value);
            PrintAst(node.Left, indent + (isLeft ? "│   " : "    "), true);
            PrintAst(node.Right, indent + (isLeft ? "│   " : "    "), false);
        }

    }

    public class AstNode
    {
        public string Value { get; set; }
        public AstNode Left { get; set; }
        public AstNode Right { get; set; }
        public AstNode(string value)
        {
            Value = value;
        }
    }
}
