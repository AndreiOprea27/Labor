using System.Text;

namespace Labor
{
    internal class Tokenizer
    {
        public static List<object>? Tokenize(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            var tokens = new Stack();
            var tokenList = tokens.GetElements();
            var currentToken = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (currentToken.Length > 0)
                    {
                        tokens.Push(currentToken.ToString());
                        currentToken.Clear();
                    }
                }
                else
                {
                    currentToken.Append(c);
                }
            }
            if (currentToken.Length > 0)
            {
                tokens.Push(currentToken.ToString());
            }
            return tokenList;
        }
    }
}
