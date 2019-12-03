using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingLot
    {
        private readonly Dictionary<object, Car> _ticketToCars = new Dictionary<object, Car>();
        private readonly int _totalCount;

        public ParkingLot(int totalCount)
        {
            _totalCount = totalCount;
        }

        public object Park(Car car)
        {
            var existCount = _ticketToCars.Count;
            if (existCount >= _totalCount)
                throw new NoSpaceException("ParkingLot is full");

            var ticket = new object();
            _ticketToCars.Add(ticket, car);
            return ticket;
        }

        public Car Pick(object ticket)
        {
            if (!TicketIsValid(ticket))
                throw new InvalidTicketException("invalid ticket");

            var car = _ticketToCars[ticket];
            _ticketToCars.Remove(ticket);
            return car;
        }

        public int CurrentCount()
        {
            return _ticketToCars.Count;
        }

        public bool IsFull()
        {
            return _ticketToCars.Count == _totalCount;
        }

        public bool TicketIsValid(object ticket)
        {
            return _ticketToCars.ContainsKey(ticket);
        }
    }
}