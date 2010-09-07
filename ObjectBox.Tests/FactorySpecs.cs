using System;
using Machine.Specifications;
using ObjectBox.Tests.Fixtures;

namespace ObjectBox.Tests
{
    public class When_attempting_to_create_object_that_isnt_registered
    {
        Establish Context = () => factory = new ObjectFactory();
        Because Of = () => NotRegisteredException = Catch.Exception(() => factory.Create<UnknownObject>());

        It should_throw_exception = () => NotRegisteredException.ShouldBeOfType<FactoryNotRegisteredException>();
        It should_set_exception_message = () => NotRegisteredException.Message.ShouldEqual(String.Format("No Factory registered for type - {0}",typeof (UnknownObject).AssemblyQualifiedName));

        static ObjectFactory factory;
        static Exception NotRegisteredException;
    }

    public class When_creating_an_object_you_specified_in_a_factory_with_no_defaults
    {
        Establish Context = () => factory = new ObjectFactory();
        Because Of = () => myClass = factory.Create<MyObject>();
        It Should_create_object_of_requested_type = () => myClass.ShouldBeOfType<MyObject>();
        It Should_not_set_values_on_object = () => myClass.UnsetValue.ShouldEqual(0);

        static ObjectFactory factory;   
        static MyObject myClass;
    }

    public class When_creating_an_object_you_specified_in_a_factory_with_defaults
    {
        Establish Context = () => factory = new ObjectFactory();
        Because Of = () => defaultValues = factory.Create<DefaultObject>();
        It should_set_Id_to_default = () => defaultValues.Id.ShouldEqual(1);
        It should_set_Name_to_default = () => defaultValues.Name.ShouldEqual("Sarah");

        static ObjectFactory factory;
        static DefaultObject defaultValues;
    }

    public class When_creating_an_object_you_specified_in_a_factory_with_default_and_overrides
    {
        Establish Context = () => factory = new ObjectFactory();
        Because Of = () => defaultValues = factory.Create<DefaultObject>(defaultObject => defaultObject.Name = "Bob");
        It should_set_default_values_on_object = () => defaultValues.Id.ShouldEqual(1);
        It should_set_overides_on_object = () => defaultValues.Name.ShouldEqual("Bob");

        static ObjectFactory factory;
        static DefaultObject defaultValues;
    }

    public class When_creating_an_object_with_an_after_create_action
    {
        Establish Context = () => factory = new ObjectFactory();
        Because Of = () => createdObject = factory.Create<DefaultObject>(q =>
                                                                                     {
                                                                                         q.Number1 = 1;
                                                                                         q.Number2 = 2;
                                                                                     });

        It should_execute_post_create_action = () => createdObject.Total.ShouldEqual(3);

        static ObjectFactory factory;
        static DefaultObject createdObject;
    }

    public class When_creating_a_class_with_an_association
    {
        Establish Context = () => factory = new ObjectFactory();
        Because Of = () => createdOject = factory.Create<DefaultObject>();
        It should_create_association_to_other_factory_object = () => createdOject.Association.ShouldNotBeNull();

        static ObjectFactory factory;
        static DefaultObject createdOject;
    }

}
