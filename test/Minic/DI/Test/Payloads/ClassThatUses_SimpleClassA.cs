using System;

namespace Minic.DI.Test.Payloads
{
    class ClassThatUses_SimpleClassA
    {
        [Inject]
        public SimpleClassA value;
    }
}
