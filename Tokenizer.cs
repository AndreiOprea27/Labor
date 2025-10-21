using System.Text;
using System.Globalization;

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
                        tokens.Add(ParseToken(currentToken.ToString()));
                        currentToken.Clear();
                    }
                }
                else if (IsOperator(c) || c == '(' || c == ')')
                {
                    // Das letzte Zahl Token
                    if (currentToken.Length > 0)
                    {
                        tokens.Add(ParseToken(currentToken.ToString()));
                        currentToken.Clear();
                    }

                    tokens.Add(c.ToString());
                }
                else if (char.IsDigit(c) || c == '.')
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
                tokens.Add(ParseToken(currentToken.ToString()));
            }

            return tokens;
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        private static object ParseToken(string token)
        {
            // Parsen der Zahl
            if (double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out double number))
                return number;
            return token; // entweder Operator oder Klammer
        }
    }
}
