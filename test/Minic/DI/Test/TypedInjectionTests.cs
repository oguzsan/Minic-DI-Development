using System;
using Xunit;
using Minic.DI;
using Minic.DI.Test.Payloads;


namespace Minic.DI.Test
{
    public class TypedInjectionTests
    {
        [Fact]
        public void Test_TypedInjection()
        {
            IInjectorTester injector = new Injector();

            //  Add first binding
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>();

            //  Create injection target
            ClassThatUses_SimpleClassA target = new ClassThatUses_SimpleClassA();

            //  Check before injection
            Assert.Null(target.value);
            
            //  Inject
            injector.InjectInto(target);

            //  Check error
            Assert.Equal(0, injector.ErrorCount);

            //  Check after injection
            Assert.NotNull(target.value);
        }

        [Fact]
        public void Test_TypedInjectionAssignableType()
        {
            IInjectorTester injector = new Injector();

            //  Add first binding
            injector.AddBinding<SimpleInterfaceA>().ToType<SimpleClassA>();

            //  Create injection target
            ClassThatUses_SimpleInterfaceA target = new ClassThatUses_SimpleInterfaceA();

            //  Check before injection
            Assert.Null(target.value);
            
            //  Inject
            injector.InjectInto(target);

            //  Check error
            Assert.Equal(0, injector.ErrorCount);

            //  Check after injection
            Assert.NotNull(target.value);
        }

        [Fact]
        public void Test_TypedInjectionToWrongType()
        {
            IInjectorTester injector = new Injector();

            //  Add first binding
            injector.AddBinding<SimpleClassB>().ToType<SimpleClassB>();

            //  Create injection target
            ClassThatUses_SimpleClassA target = new ClassThatUses_SimpleClassA();

            //  Check before injection
            Assert.Null(target.value);
            
            //  Inject
            injector.InjectInto(target);

            //  Check error
            Assert.Equal(1, injector.ErrorCount);
            Assert.Equal(InjectionErrorType.CanNotFindBindingForType,injector.GetError(0).Error);

            //  Check after injection
            Assert.Null(target.value);
        }
    }
}
