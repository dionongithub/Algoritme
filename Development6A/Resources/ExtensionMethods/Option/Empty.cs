namespace ExtensionMethods
{
    public class Empty<T> : Option<T>
    {
        public bool empty { get;  }
        public T data { get; set; }

        public Empty()
        {
            empty = true;
        }
    }
}