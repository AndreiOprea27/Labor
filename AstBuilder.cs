using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor
{
    public static class AstBuilder
    {
        public static string BuildAst(Queue<string> tokens)
        {
           Stack<AstNode> stack = new Stack<AstNode>();
            while (tokens.Count > 0)
            {
                var token = tokens.Dequeue();
                if (IsOperator(token))
                {
                    var right = tokens.Dequeue();
                    var left = tokens.Dequeue();
                    var newNode = $"({left} {token} {right})";
                    tokens.Enqueue(newNode);
                }
                else
                {
                    tokens.Enqueue(token);
                }
            }
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
