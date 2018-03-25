// Copyright (c) 2018 Oğuz Sandıkçı
// This code is licensed under MIT license (see LICENSE.txt for details)

using System;

namespace Minic.DI.Test.Payloads
{
    public class CrossReferenceContainer
    {
        [Inject]
        public CrossReferenceClassA valueA;
        [Inject]
        public CrossReferenceClassB valueB;
    }
}
