using System;

namespace Minic.DI.Test.Payloads
{
    public class CrossReferenceClassB
    {
        [Inject]
        public CrossReferenceClassA value;
    }
}
