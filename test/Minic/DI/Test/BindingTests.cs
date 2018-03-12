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

            //  Validate binding
            Assert.Equal(1,injector.BindingCount);
            Assert.True(injector.HasBindingForType(typeof(SimpleClassA)));

            //  Check error
            Assert.Equal(0,injector.ErrorCount);

            //  Add second binding
            injector.AddBinding<SimpleClassB>();

            //  Validate binding
            Assert.Equal(2,injector.BindingCount);
            Assert.True(injector.HasBindingForType(typeof(SimpleClassA)));
            Assert.True(injector.HasBindingForType(typeof(SimpleClassB)));
            
            //  Check error
            Assert.Equal(0,injector.ErrorCount);
        }

        [Fact]
        public void Test_ReAddingExistingBindings()
        {
            IInjector injector = new Injector();

            //  Add two bindings
            injector.AddBinding<SimpleClassA>();
            injector.AddBinding<SimpleClassB>();

            //  Check error
            Assert.Equal(0,injector.ErrorCount);

            //  Try re-adding first binding
            injector.AddBinding<SimpleClassA>();

            //  Check error
            Assert.Equal(1,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.AlreadyAddedBindingForType, injector.GetError(0).Error);

            //  Try re-adding second binding
            injector.AddBinding<SimpleClassA>();

            //  Check error
            Assert.Equal(2,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.AlreadyAddedBindingForType, injector.GetError(1).Error);
        }
    }
}
