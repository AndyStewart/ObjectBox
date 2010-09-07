using System;

namespace ObjectBox.Tests.Fixtures
{
    public class MyObjectFactory : IObjectFactory<MyObject>
    {
        public void SetDefault(ObjectInitialiser<MyObject> value)
        {
            value.Object.Id = 1;
        }
    }
}