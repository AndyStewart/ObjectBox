using System;
using System.Collections;
using System.Linq;

namespace ObjectBox
{
    public class BaseFactory
    {
        public BaseFactory()
        {
            Factories = new ArrayList();
        }
        public ArrayList Factories { get; private set; }

        /// <summary>
        /// Creates an object using the defaults configured for the 
        /// type specified in it's factory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public T Create<T>(Action<T> defaultValues = null)
        {
            var factoriesFound = Factories.OfType<IObjectFactory<T>>();
            if (factoriesFound.Count() > 0)
            {
                var newObject = Activator.CreateInstance<T>();
                var factory = factoriesFound.First();

                var initialiser = new ObjectInitialiser<T>(this, newObject);
                factory.SetDefault(initialiser);

                if (defaultValues != null)
                    defaultValues.Invoke(newObject);


                var postCreateEvent = factory as IPostObjectCreated<T>;
                if (postCreateEvent != null)
                    postCreateEvent.PostCreated(newObject);

                return newObject;
            }


            throw new FactoryNotRegisteredException(typeof(T));
        }

        public void Register<T>() 
        {
            Factories.Add(Activator.CreateInstance<T>());
        }
    }
}