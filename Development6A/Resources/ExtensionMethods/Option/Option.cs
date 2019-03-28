namespace ExtensionMethods
{
    public interface Option<T>
    {
        bool empty { get; }
        T data { get; set; }

    }
}