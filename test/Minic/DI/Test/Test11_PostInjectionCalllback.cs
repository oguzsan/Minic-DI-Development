// Copyright (c) 2018 Oğuz Sandıkçı
// This code is licensed under MIT license (see LICENSE.txt for details)

using System;
using Xunit;
using Minic.DI;
using Minic.DI.Error;
using Minic.DI.Test.Payloads;


namespace Minic.DI.Test
{
    public class Test11_PostInjectionCalllback
    {
        private bool _IscallbackCalled;
        private object _CallbackCaller;

        private void Callback(object callbackCaller)
        {
            _IscallbackCalled = true;
            _CallbackCaller = callbackCaller;
        }

        [Fact]
        public void Test_PostCallback()
        {
            Injector injector = new Injector();

            //  Add first binding
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>().SetPostInjectionCallback(Callback);
            injector.AddBinding<SimpleClassB>().ToValue(new SimpleClassB());

            //  Validate binding
            Assert.Equal(2,injector.BindingCount);
            Assert.True(injector.HasBindingForType(typeof(SimpleClassA)));
            Assert.True(injector.HasBindingForType(typeof(SimpleClassB)));

            //  Check error
            Assert.Equal(0,injector.ErrorCount);

            //  Set fields
            _IscallbackCalled = false;
            _CallbackCaller = null;

            //  Get Instance
            SimpleClassA value = injector.GetInstance<SimpleClassA>();
            
            //  Check error
            Assert.Equal(0,injector.ErrorCount);

            //  Validate binding
            Assert.True(_IscallbackCalled);
            Assert.Equal(value, _CallbackCaller);
        }
        
    }
}
