namespace Labor.Tests
{
    public class Test
    {
        public static void TestStack()
        {
            var elements = new Stack();
            elements.Push(1);
            elements.Size();
            elements.Peek();
            elements.Push(2);
            elements.Size();
            elements.Peek();
            elements.Pop();
            elements.Peek();
            elements.IsEmpty();
            elements.Pop();
            elements.IsEmpty();
        }
    }  
}
