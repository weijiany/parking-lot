using System;

namespace parking_lot
{
    public class NoSpaceException : Exception
    {
        public NoSpaceException(string message) : base(message)
        {
            
        }
    }
}