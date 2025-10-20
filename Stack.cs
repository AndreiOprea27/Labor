namespace Labor
{
    public class Stack
    {
        /// <summary>
        /// Der Stack, der die Elemente enthält
        /// </summary>
        private List<object> Elements = new List<object>();
        /// <summary>
        /// legt ein Element auf den Stack
        /// </summary>
        /// <param name="item">wird in den Stack addiert</param>
        public void Push(object item)
        {
            Elements.Add(item);
            Console.WriteLine($"{item} wurde hinzugefügt.");
        }
        /// <summary>
        /// entfernt das oberste Element und gibt es zuruck
        /// </summary>
        public object? Pop()
        {
            if (Elements.Count == 0)
            {
                Console.WriteLine("Der Stack ist leer.");
                return null;
            }
            else
            {
                var item = Elements[Elements.Count - 1];
                Elements.RemoveAt(Elements.Count - 1);
                Console.WriteLine($"{item} war entfernt.");
                return item;
            }
        }
        /// <summary>
        /// gibt das oberste Element zuruck, ohne es zu entfernen.
        /// </summary>
        public void Peek()
        {
            if (Elements.Count == 0) Console.WriteLine("Der Stack ist leer.");
            else Console.WriteLine($"Das oberste Element ist {Elements[Elements.Count - 1]}.");
        }
        /// <summary>
        /// gibt True zuruck, wenn der Stack leer ist
        /// </summary>
        public bool IsEmpty()
        {
            Console.WriteLine(Elements.Count == 0 ? "Der Stack ist leer." : "Der Stack ist nicht leer.");
            return Elements.Count == 0;
        }
        /// <summary>
        /// gibt die aktuelle Anzahl der Elemente zuruck
        /// </summary>
        public void Size()
        {
            if(Elements.Count == 0) Console.WriteLine("Der Stack ist leer.");
            else if(Elements.Count == 1) Console.WriteLine("Der Stack hat 1 Element.");
            else Console.WriteLine($"Der Stack hat {Elements.Count} Elemente.");
        }
    }
}
