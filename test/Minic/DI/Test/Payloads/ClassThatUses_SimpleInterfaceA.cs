using System;

namespace Minic.DI.Test.Payloads
{
    class ClassThatUses_SimpleInterfaceA
    {
        [Inject]
        public SimpleInterfaceA value;
    }
}
