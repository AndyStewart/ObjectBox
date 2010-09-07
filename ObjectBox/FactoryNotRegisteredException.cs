using System;

namespace ObjectBox
{
    public class FactoryNotRegisteredException : Exception
    {
        private Type type;

        public FactoryNotRegisteredException(Type type)
        {
            this.type = type;
        }

        public override string Message
        {
            get
            {
                return String.Format("No Factory registered for type - {0}", type.AssemblyQualifiedName);
            }
        }

    }
}