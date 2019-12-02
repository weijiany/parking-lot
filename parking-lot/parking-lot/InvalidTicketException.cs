using System;

namespace parking_lot
{
    public class InvalidTicketException : Exception
    {
        public InvalidTicketException(string message) : base(message)
        {
            
        }
    }
}