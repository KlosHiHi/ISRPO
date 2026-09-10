using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork6
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException() { }

        public NegativeNumberException(string message) : base(message) { }
    }
}
