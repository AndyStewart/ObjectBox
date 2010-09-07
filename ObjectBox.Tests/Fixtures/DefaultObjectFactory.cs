using System;

namespace ObjectBox.Tests.Fixtures
{
    public class DefaultObjectFactory : IObjectFactory<DefaultObject>, IPostObjectCreated<DefaultObject>
    {
        public void PostCreated(DefaultObject value)
        {
            value.Total = value.Number1 + value.Number2;
        }

        public void SetDefault(ObjectInitialiser<DefaultObject> value)
        {
            value.Object.Id = 1;
            value.Object.Name = "Sarah";
            value.Object.Association = value.BaseFactory.Create<MyObject>();
        }
    }
}