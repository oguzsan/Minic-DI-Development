using System;

namespace Minic.DI.Test.Payloads
{
    public class CrossReferenceClassA
    {
        [Inject]
        public CrossReferenceClassB value;
    }
}
