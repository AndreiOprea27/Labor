using System;
using System.Collections.Generic;
using System.Linq;

namespace Labor
{
    public static class AstBuilder
    {
        public static AstNode BuildAstFromAsciiTree(string asciiTree)
        {
            var lines = asciiTree.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return ParseNode(lines, 0, 0).Node;
        }

        private static (AstNode Node, int NextIndex) ParseNode(string[] lines, int index, int indentLevel)
        {
            if (index >= lines.Length)
                return (null, index);

            string line = lines[index];
            string clean = line.Trim().Substring(3).Trim(); // Remove ├── or └──

            AstNode node = new AstNode(clean);

            int nextIndentLevel = indentLevel + 1;

            // Check for children
            var children = new List<AstNode>();
            int i = index + 1;
            while (i < lines.Length && GetIndentLevel(lines[i]) >= nextIndentLevel)
            {
                if (GetIndentLevel(lines[i]) == nextIndentLevel)
                {
                    var (childNode, nextIdx) = ParseNode(lines, i, nextIndentLevel);
                    children.Add(childNode);
                    i = nextIdx;
                }
                else
                {
                    i++;
                }
            }

            if (children.Count > 0)
            {
                node.Left = children.ElementAtOrDefault(0);
                node.Right = children.ElementAtOrDefault(1);
            }

            return (node, i);
        }

        private static int GetIndentLevel(string line)
        {
            int level = 0;
            foreach (char c in line)
            {
                if (c == '│' || c == ' ')
                    level++;
                else
                    break;
            }
            return level / 4; // Since '│   ' is 4 characters
        }

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
                        throw new InvalidOperationException("Invalid RPN Expression.");

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
                throw new InvalidOperationException("Invalid RPN Expression.");

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
