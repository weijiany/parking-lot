using System;

namespace parking_lot.exception
{
    public class NoSpaceException : Exception
    {
        public NoSpaceException(string message) : base(message)
        {
            
        }
    }
}