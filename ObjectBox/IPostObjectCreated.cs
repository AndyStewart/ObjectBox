namespace ObjectBox
{
    public interface IPostObjectCreated<T>
    {
        void PostCreated(T value);
    }
}