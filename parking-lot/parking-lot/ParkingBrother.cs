using System;
using System.Collections.Generic;
using System.Linq;

namespace parking_lot
{
    public class ParkingBrother
    {
        private readonly List<ParkingLot> parkingLots;
        private readonly List<ParkingLot> externalLots;

        private bool canBeFoundInExternalLots(object ticket)
        {
            foreach (var lot in externalLots)
            {
                try
                {
                    lot.Pick(ticket);
                    return true;
                }
                catch (InvalidTicketException ite)
                {
                    if (lot == externalLots.Last())
                    {
                        return false;
                    }
                }
            }

            return false;
        }
        
        public ParkingBrother(List<ParkingLot> lots)
        {
            parkingLots = lots;
            externalLots = new List<ParkingLot>();
        }

        public ParkingBrother(List<ParkingLot> lots, List<ParkingLot> externalLots)
        {
            parkingLots = lots;
            this.externalLots = externalLots;
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
                        if (canBeFoundInExternalLots(ticket))
                        {
                            throw new NotFoundException("not found");
                        }
                        else
                        {
                            throw new InvalidTicketException("invalid ticket");
                        }
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