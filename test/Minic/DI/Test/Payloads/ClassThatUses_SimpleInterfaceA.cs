using System;

namespace Minic.DI.Test.Payloads
{
    class ClassThatUses_SimpleInterfaceA
    {
        [Inject]
        public ISimpleInterfaceA value;

        public ClassThatUses_SimpleInterfaceA(){value = null;}
    }
}
