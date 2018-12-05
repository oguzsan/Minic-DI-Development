// Copyright (c) 2018 Oğuz Sandıkçı
// This code is licensed under MIT license (see LICENSE.txt for details)

using System;
using Xunit;
using Minic.DI;
using Minic.DI.Error;
using Minic.DI.Test.Payloads;


namespace Minic.DI.Test
{
    public class Test7_ValueInjections
    {
        [Fact]
        public void Test_ValueInjection()
        {
            Injector injector = new Injector();

            //  Add first binding
            SimpleClassA value = new SimpleClassA();
            injector.AddBinding<SimpleClassA>().ToValue(value);

            //  Create injection target
            ClassThatUses_SimpleClassA target = new ClassThatUses_SimpleClassA();

            //  Check before injection
            Assert.Null(target.value1);
            Assert.Null(target.value2);
            
            //  Inject
            injector.InjectInto(target);

            //  Check error
            Assert.Equal(0, injector.ErrorCount);

            //  Check after injection
            Assert.NotNull(target.value1);
            Assert.NotNull(target.value2);
            Assert.Same(value,target.value1);
            Assert.Same(value,target.value2);
        }

        [Fact]
        public void Test_ValueInjectionToNestedMembers()
        {
            Injector injector = new Injector();

            //  Add first binding
            SimpleClassA value = new SimpleClassA();
            injector.AddBinding<SimpleClassA>().ToValue(value);

            //  Create injection target
            ExtendedClassThatUses_SimpleClassA target = new ExtendedClassThatUses_SimpleClassA();

            //  Check before injection
            Assert.Null(target.value1);
            Assert.Null(target.value2);
            
            //  Inject
            injector.InjectInto(target);

            //  Check error
            Assert.Equal(0, injector.ErrorCount);

            //  Check after injection
            Assert.NotNull(target.value1);
            Assert.NotNull(target.value2);
            Assert.Same(value,target.value1);
            Assert.Same(value,target.value2);
        }

        [Fact]
        public void Test_ValueInjectionToAssignableType()
        {
            Injector injector = new Injector();

            //  Add first binding
            SimpleClassA value = new SimpleClassA();
            injector.AddBinding<ISimpleInterfaceA>().ToValue(value);

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
        public void Test_Error_ValueInjectionToWrongType()
        {
            Injector injector = new Injector();

            //  Add first binding
            SimpleClassB value = new SimpleClassB();
            injector.AddBinding<SimpleClassB>().ToValue(value);

            //  Create injection target
            ClassThatUses_SimpleClassA target = new ClassThatUses_SimpleClassA();

            //  Check before injection
            Assert.Null(target.value1);
            Assert.Null(target.value2);
            
            //  Inject
            injector.InjectInto(target);

            //  Check error
            Assert.Equal(2, injector.ErrorCount);
            Assert.Equal(InjectionErrorType.CanNotFindBindingForType,injector.GetError(0).Error);
            Assert.Equal(InjectionErrorType.CanNotFindBindingForType,injector.GetError(1).Error);

            //  Check after injection
            Assert.Null(target.value1);
            Assert.Null(target.value2);
        }
    }
}
