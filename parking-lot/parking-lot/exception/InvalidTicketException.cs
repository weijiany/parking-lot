using System;

namespace parking_lot.exception
{
    public class InvalidTicketException : Exception
    {
        public InvalidTicketException(string message) : base(message)
        {
            
        }
    }
}