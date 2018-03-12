using System;
using Xunit;
using Minic.DI;
using Minic.DI.Test.Payloads;


namespace Minic.DI.Test
{
    public class TypedProviderTests
    {
        [Fact]
        public void Test_SettingTypedProvider()
        {
            IInjector injector = new Injector();

            //  Add first binding and set typed provider
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>();

            //  Validate
            Assert.Equal(1,injector.BindingCount);
            Assert.Equal(1,injector.ProviderCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);
            
            //  Add second binding and set typed provider
            injector.AddBinding<SimpleClassB>().ToType<SimpleClassB>();

            //  Validate
            Assert.Equal(2,injector.BindingCount);
            Assert.Equal(2,injector.ProviderCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);
        }
        
        [Fact]
        public void Test_SettingTypedProviderToWrongType()
        {
            IInjector injector = new Injector();

            //  Add first binding and set typed provider
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassB>();

            //  Validate binding
            Assert.Equal(1,injector.BindingCount);
            Assert.Equal(0,injector.ProviderCount);

            //  Check error
            Assert.Equal(1,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.TypeNotAssignableToTarget, injector.GetError(0).Error);
            
            //  Add second binding and set typed provider
            injector.AddBinding<SimpleClassB>().ToType<SimpleClassA>();

            //  Validate binding
            Assert.Equal(2,injector.BindingCount);
            Assert.Equal(0,injector.ProviderCount);

            //  Check error
            Assert.Equal(2,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.TypeNotAssignableToTarget, injector.GetError(1).Error);
        }
    }
}
