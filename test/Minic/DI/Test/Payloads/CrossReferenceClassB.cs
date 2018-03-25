// Copyright (c) 2018 Oğuz Sandıkçı
// This code is licensed under MIT license (see LICENSE.txt for details)

using System;

namespace Minic.DI.Test.Payloads
{
    public class CrossReferenceClassB
    {
        [Inject]
        public CrossReferenceClassA value;
    }
}
