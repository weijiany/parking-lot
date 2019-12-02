using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingLot
    {
        private readonly Dictionary<object, Car> ticketToCars;
        private readonly int _count;

        public ParkingLot(int count)
        {
            ticketToCars = new Dictionary<object, Car>();
            _count = count;
        }

        public object Park(Car car)
        {
            var ticket = new object();
            var count = ticketToCars.Count;
            if (count >= _count) throw new NoSpaceException("ParkingLot is full");

            ticketToCars.Add(ticket, car);
            return ticket;
        }

        public Car Pick(object ticket)
        {
            if (!ticketToCars.ContainsKey(ticket)) throw new InvalidTicketException("invalid ticket");

            var car = ticketToCars[ticket];
            ticketToCars.Remove(ticket);
            return car;
        }

        public int CurrentCount()
        {
            return ticketToCars.Count;
        }
    }
}