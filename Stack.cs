namespace Labor
{
    public class Stack
    {
        /// <summary>
        /// Der Stack, der die Elemente enthält
        /// </summary>
        private List<object> Elements = new List<object>();
        public List<object> GetElements()
        {
            return Elements;
        }
        /// <summary>
        /// legt ein Element auf den Stack
        /// </summary>
        /// <param name="item">wird in den Stack addiert</param>
        public void Push(object item)
        {
            Elements.Add(item);
        }
        /// <summary>
        /// entfernt das oberste Element und gibt es zuruck
        /// </summary>
        public object? Pop()
        {
            if (Elements.Count == 0) return null;
            else
            {
                var item = Elements[Elements.Count - 1];
                Elements.RemoveAt(Elements.Count - 1);
                return item;
            }
        }
        /// <summary>
        /// gibt das oberste Element zuruck, ohne es zu entfernen.
        /// </summary>
        public object? Peek()
        {
            if (Elements.Count == 0) return null;
            else return Elements[Elements.Count - 1];
        }
        /// <summary>
        /// gibt True zuruck, wenn der Stack leer ist
        /// </summary>
        public bool IsEmpty()
        {
            if(Elements.Count == 0) return true;
            else return false;
        }
        /// <summary>
        /// gibt die aktuelle Anzahl der Elemente zuruck
        /// </summary>
        public int Size()
        {
            return Elements.Count;
        }
    }
}
