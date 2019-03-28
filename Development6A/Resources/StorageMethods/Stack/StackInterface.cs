using ExtensionMethods;

namespace Development6A.Resources
{
    public interface StackInterface<T>
    {
        void Push(T e);
        Option<T> Pop();
        Option<T> Peek();
        bool isEmpty();
    }
}