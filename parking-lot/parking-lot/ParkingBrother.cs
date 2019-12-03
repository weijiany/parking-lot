using System;
using System.Collections.Generic;
using System.Linq;

namespace parking_lot
{
    public class ParkingBrother
    {
        private readonly List<ParkingLot> _parkingLots;

        public ParkingBrother(List<ParkingLot> lots)
        {
            _parkingLots = lots;
        }

        public List<ParkingLot> GetLots()
        {
            return _parkingLots;
        }

        public Car Pick(object ticket)
        {
            if (!_parkingLots.Any()) throw new Exception("No available parking lots.");

            var parkingLot = _parkingLots.FirstOrDefault(l => l.TicketIsValid(ticket));
            if (parkingLot == null)
                throw new InvalidTicketException("invalid ticket");

            return parkingLot.Pick(ticket);
        }

        public object Park(Car car)
        {
            if (!_parkingLots.Any()) throw new Exception("No available parking lots.");

            var notFullLot = _parkingLots.FirstOrDefault(l => !l.IsFull());
            if (notFullLot == null)
                throw new NoSpaceException("no space");

            return notFullLot.Park(car);
        }
    }
}