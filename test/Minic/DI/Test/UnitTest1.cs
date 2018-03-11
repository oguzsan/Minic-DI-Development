using System;
using Xunit;
using Minic.DI;
using Minic.DI.Test.Payloads;


namespace Minic.DI.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_AddingBindings()
        {
            IInjector injector = new Injector();

            //  Add first binding
            injector.AddBinding<SimpleClassA>();

            //  Validate
            Assert.Equal(1,injector.BindingCount);
            Assert.True(injector.HasBindingForType(typeof(SimpleClassA)));

            //  Add second binding
            injector.AddBinding<SimpleClassB>();

            //  Validate
            Assert.Equal(2,injector.BindingCount);
            Assert.True(injector.HasBindingForType(typeof(SimpleClassA)));
            Assert.True(injector.HasBindingForType(typeof(SimpleClassB)));
        }

        [Fact]
        public void Test_AddingExistingBindings()
        {
            IInjector injector = new Injector();

            //  Add two bindings
            injector.AddBinding<SimpleClassA>();
            injector.AddBinding<SimpleClassB>();

            //  No errors
            Assert.Equal(0,injector.ErrorCount);

            //  Try re-adding first binding
            injector.AddBinding<SimpleClassA>();
            Assert.Equal(1,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.AlreadyAddedBindingForType, injector.GetError(0).Error);

            //  Try re-adding second binding
            injector.AddBinding<SimpleClassA>();
            Assert.Equal(2,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.AlreadyAddedBindingForType, injector.GetError(1).Error);
        }

        
        [Fact]
        public void Test_AddingTypedProvider()
        {
            IInjector injector = new Injector();

            //  Add first binding
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>();

            //  Validate
            Assert.Equal(1,injector.BindingCount);
            Assert.Equal(1,injector.ProviderCount);
            
            //  Add second binding
            injector.AddBinding<SimpleClassB>().ToType<SimpleClassB>();

            //  Validate
            Assert.Equal(2,injector.BindingCount);
            Assert.Equal(2,injector.ProviderCount);
        }
    }
}
