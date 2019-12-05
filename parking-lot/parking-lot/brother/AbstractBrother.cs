using System;
using System.Collections.Generic;
using System.Linq;

namespace parking_lot.brother
{
    public abstract class AbstractBrother
    {
        public IList<ParkingLot> ParkingLots { get; }

        protected AbstractBrother(IList<ParkingLot> parkingLots)
        {
            ParkingLots = parkingLots;
        }

        public Car Pick(object ticket)
        {
            if (!ParkingLots.Any()) throw new Exception("No available parking lots.");

            var parkingLot = ParkingLots.FirstOrDefault(l => l.TicketIsValid(ticket));
            if (parkingLot == null)
                throw new InvalidTicketException("invalid ticket");

            return parkingLot.Pick(ticket);
        }

        public abstract object Park(Car car);
    }
}