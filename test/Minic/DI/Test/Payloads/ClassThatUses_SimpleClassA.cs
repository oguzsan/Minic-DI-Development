// Copyright (c) 2018 Oğuz Sandıkçı
// This code is licensed under MIT license (see LICENSE.txt for details)

using System;

namespace Minic.DI.Test.Payloads
{
    class ClassThatUses_SimpleClassA
    {
        [Inject]
        public SimpleClassA value;

        public ClassThatUses_SimpleClassA(){value = null;}
    }
}
