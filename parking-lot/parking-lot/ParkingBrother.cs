using System;
using System.Collections.Generic;
using System.Linq;

namespace parking_lot
{
    public class ParkingBrother
    {
        private readonly List<ParkingLot> parkingLots;

        public ParkingBrother(List<ParkingLot> lots)
        {
            parkingLots = lots;
        }

        public List<ParkingLot> GetLots()
        {
            return parkingLots;
        }

        public Car Pick(object ticket)
        {
            if (!parkingLots.Any()) throw new Exception("No available parking lots.");

            foreach (var lot in parkingLots)
            {
                try
                {
                    return lot.Pick(ticket);
                }
                catch (InvalidTicketException ite)
                {
                    if (lot == parkingLots.Last())
                    {
                        throw new InvalidTicketException("invalid ticket");
                    }
                }
            }

            return null;
        }

        public object Park(Car car)
        {
            if (!parkingLots.Any()) throw new Exception("No available parking lots.");

            foreach (var lot in parkingLots)
            {
                try
                {
                    return lot.Park(car);
                }
                catch (NoSpaceException nse)
                {
                    if (lot == parkingLots.Last())
                    {
                        throw new NoSpaceException("no space");
                    }
                }
            }

            return null;
        }
    }
}