// Copyright (c) 2018 Oğuz Sandıkçı
// This code is licensed under MIT license (see LICENSE.txt for details)

using System;
using Xunit;
using Minic.DI;
using Minic.DI.Error;
using Minic.DI.Test.Payloads;


namespace Minic.DI.Test
{
    public class Test9_NoBindingAfterInjection
    {
        [Fact]
        public void Test_Error_BindingAfterGetInstance()
        {
            Injector injector = new Injector();

            //  Add a bindings
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>();

            //  Validate bindings
            Assert.Equal(1,injector.BindingCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);

            //  Get instance
            injector.GetInstance<SimpleClassA>();

            //  Try adding a new binding
            injector.AddBinding<SimpleClassB>();

            //  Check error
            Assert.Equal(1,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.BindingAfterInjection, injector.GetError(0).Error);
        }
        
        [Fact]
        public void Test_Error_BindingAfterInjectInto()
        {
            Injector injector = new Injector();

            //  Add a bindings
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>();

            //  Validate bindings
            Assert.Equal(1,injector.BindingCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);

            //  Get instance
            ClassThatUses_SimpleClassA value = new ClassThatUses_SimpleClassA();
            injector.InjectInto(value);

            //  Try adding a new binding
            injector.AddBinding<SimpleClassB>();

            //  Check error
            Assert.Equal(1,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.BindingAfterInjection, injector.GetError(0).Error);
        }
    }
}
