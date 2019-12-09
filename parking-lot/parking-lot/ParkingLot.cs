using System.Collections.Generic;
using parking_lot.exception;

namespace parking_lot
{
    public class ParkingLot
    {
        private readonly Dictionary<object, Car> _ticketToCars = new Dictionary<object, Car>();
        private int _remainCount;

        public ParkingLot(int remainCount)
        {
            _remainCount = remainCount;
        }

        public object Park(Car car)
        {
            if (IsFull())
                throw new NoSpaceException("ParkingLot is full");

            var ticket = new object();
            _ticketToCars.Add(ticket, car);
            _remainCount --;
            return ticket;
        }

        public Car Pick(object ticket)
        {
            if (!TicketIsValid(ticket))
                throw new InvalidTicketException("invalid ticket");

            var car = _ticketToCars[ticket];
            _ticketToCars.Remove(ticket);
            _remainCount ++;
            return car;
        }

        public int CurrentCount()
        {
            return _ticketToCars.Count;
        }

        public bool IsFull()
        {
            return _remainCount == 0;
        }

        public bool TicketIsValid(object ticket)
        {
            return _ticketToCars.ContainsKey(ticket);
        }

        public int RemainSpaceCount()
        {
            return _remainCount;
        }
    }
}