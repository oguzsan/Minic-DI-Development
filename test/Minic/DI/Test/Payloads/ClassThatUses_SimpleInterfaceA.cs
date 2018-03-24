using System;

namespace Minic.DI.Test.Payloads
{
    class ClassThatUses_SimpleInterfaceA
    {
        [Inject]
        public SimpleInterfaceA value;

        public ClassThatUses_SimpleInterfaceA(){value = null;}
    }
}
