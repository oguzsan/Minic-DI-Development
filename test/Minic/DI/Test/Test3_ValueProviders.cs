using System;
using Xunit;
using Minic.DI;
using Minic.DI.Error;
using Minic.DI.Test.Payloads;


namespace Minic.DI.Test
{
    public class Test3_ValueProviders
    {
        [Fact]
        public void Test_AddingValueProvider()
        {
            Injector injector = new Injector();

            //  Add first binding and a value provider
            injector.AddBinding<SimpleClassA>().ToValue(new SimpleClassA());

            //  Validate
            Assert.Equal(1,injector.BindingCount);
            Assert.Equal(1,injector.ProviderCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);
            
            //  Add second binding and set typed provider
            injector.AddBinding<SimpleClassB>().ToValue(new SimpleClassB());

            //  Validate
            Assert.Equal(2,injector.BindingCount);
            Assert.Equal(2,injector.ProviderCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);
        }
        
        [Fact]
        public void Test_AddingValueProviderToAssignableType()
        {
            Injector injector = new Injector();

            //  Add first binding and a typed provider
            injector.AddBinding<ISimpleInterfaceA>().ToValue(new SimpleClassA());

            //  Validate
            Assert.Equal(1,injector.BindingCount);
            Assert.Equal(1,injector.ProviderCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);
            
            //  Add second binding and set typed provider
            injector.AddBinding<ISimpleInterfaceB>().ToValue(new SimpleClassB());

            //  Validate
            Assert.Equal(2,injector.BindingCount);
            Assert.Equal(2,injector.ProviderCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);
        }
        
        [Fact]
        public void Test_Error_AddingValueProviderToWrongType()
        {
            Injector injector = new Injector();

            //  Add first binding and set value provider
            injector.AddBinding<SimpleClassA>().ToValue(new SimpleClassB());

            //  Validate binding
            Assert.Equal(1,injector.BindingCount);
            Assert.Equal(0,injector.ProviderCount);

            //  Check error
            Assert.Equal(1,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.ValueNotAssignableToBindingType, injector.GetError(0).Error);
            
            //  Add second binding and set value provider
            injector.AddBinding<SimpleClassB>().ToValue(new SimpleClassA());

            //  Validate binding
            Assert.Equal(2,injector.BindingCount);
            Assert.Equal(0,injector.ProviderCount);

            //  Check error
            Assert.Equal(2,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.ValueNotAssignableToBindingType, injector.GetError(1).Error);
        }
    }
}
