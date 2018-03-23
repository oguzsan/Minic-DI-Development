using System;
using Xunit;
using Minic.DI;
using Minic.DI.Test.Payloads;


namespace Minic.DI.Test
{
    public class ValueProviderTests
    {
        [Fact]
        public void Test_SettingValueProvider()
        {
            IInjectorTester injector = new Injector();

            //  Add first binding and set value provider
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
        public void Test_SettingValueProviderToWrongType()
        {
            IInjectorTester injector = new Injector();

            //  Add first binding and set value provider
            injector.AddBinding<SimpleClassA>().ToValue(new SimpleClassB());

            //  Validate binding
            Assert.Equal(1,injector.BindingCount);
            Assert.Equal(0,injector.ProviderCount);

            //  Check error
            Assert.Equal(1,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.ValueNotAssignableToTarget, injector.GetError(0).Error);
            
            //  Add second binding and set value provider
            injector.AddBinding<SimpleClassB>().ToValue(new SimpleClassA());

            //  Validate binding
            Assert.Equal(2,injector.BindingCount);
            Assert.Equal(0,injector.ProviderCount);

            //  Check error
            Assert.Equal(2,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.ValueNotAssignableToTarget, injector.GetError(1).Error);
        }
    }
}
