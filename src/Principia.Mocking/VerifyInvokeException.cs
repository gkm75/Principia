using System;

namespace Principia.Mocking
{
    public class VerifyInvokeException : Exception
    {
        public VerifyInvokeException(string message) 
            : base(message)
        {}
    }
}
