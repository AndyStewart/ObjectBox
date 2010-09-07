namespace ObjectBox.Tests.Fixtures
{
    public class ObjectFactory : BaseFactory
    {
        public ObjectFactory()
        {
            Register<MyObjectFactory>();
            Register<DefaultObjectFactory>();
        }
    }
}