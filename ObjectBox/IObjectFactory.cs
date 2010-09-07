using System;

namespace ObjectBox
{
    public interface IObjectFactory<T>
    {
        void SetDefault(ObjectInitialiser<T> value);
    }

    public class ObjectInitialiser<T>
    {
        public ObjectInitialiser(BaseFactory baseFactory, T newObject)
        {
            BaseFactory = baseFactory;
            Object = newObject;
        }

        public T Object { get; set; }
        public BaseFactory BaseFactory { get; set; }
    }
}