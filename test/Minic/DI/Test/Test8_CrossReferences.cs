using System;
using Xunit;
using Minic.DI;
using Minic.DI.Test.Payloads;


namespace Minic.DI.Test
{
    public class Test8_CrossReferences
    {
        [Fact]
        public void Test_SettingValueProvider()
        {
            Injector injector = new Injector();

            //  Add bindings
            injector.AddBinding<CrossReferenceClassA>().ToType<CrossReferenceClassA>();
            injector.AddBinding<CrossReferenceClassB>().ToType<CrossReferenceClassB>();

            //  Create injection targets
            CrossReferenceContainer target = new CrossReferenceContainer();
            
            //  Check before injection
            Assert.Null(target.valueA);
            Assert.Null(target.valueB);
            
            //  Inject
            injector.InjectInto(target);

            //  Check after injection
            Assert.NotNull(target.valueA);
            Assert.NotNull(target.valueB);
            Assert.NotNull(target.valueA.value);
            Assert.NotNull(target.valueB.value);
            Assert.Equal(target.valueA.value,target.valueB);
            Assert.Equal(target.valueB.value,target.valueA);

            //  Check error
            Assert.Equal(0, injector.ErrorCount);
        }
    }
}
