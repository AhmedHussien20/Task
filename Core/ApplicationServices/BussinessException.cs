using System;

namespace ApplicationServices
{

    public class BussinessException : Exception
    {
        public BussinessException() { }
        public BussinessException(string message) : base(message) { }
        public BussinessException(string message, Exception inner) : base(message, inner) { }
        protected BussinessException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

