using System.Text;

namespace Labor
{
    public class Tokenizer
    {
        public static List<object>? Tokenize(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;

            var tokens = new List<object>();
            var currentToken = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    // Das letzte Token
                    if (currentToken.Length > 0)
                    {
                        tokens.Add(currentToken.ToString());
                        currentToken.Clear();
                    }
                }
                else if (IsOperator(c) || c == '<' || c == '^' || c == '(' || c == ')' || c == '[' || c == ']')
                {
                    // Das letzte Zahl Token
                    if (currentToken.Length > 0)
                    {
                        tokens.Add(currentToken.ToString());
                        currentToken.Clear();
                    }

                    tokens.Add(c.ToString());
                }
                else if (char.IsDigit(c) || c == '.' || c == ',')
                {
                    currentToken.Append(c);
                }
                else
                {
                    throw new ArgumentException($"Ungültiges Zeichen im Ausdruck: {c}");
                }
            }

            // Das letzte Token addieren, falls vorhanden
            if (currentToken.Length > 0)
            {
                tokens.Add(currentToken.ToString());
            }

            return tokens;
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
    }
}
