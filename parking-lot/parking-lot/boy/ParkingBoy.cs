using System;
using System.Collections.Generic;
using System.Linq;

namespace parking_lot.boy
{
    public class ParkingBoy : AbstractBoy
    {
        public ParkingBoy(IList<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public override object Park(Car car)
        {
            if (!ParkingLots.Any()) throw new Exception("No available parking lots.");

            var notFullLot = ParkingLots.FirstOrDefault(l => !l.IsFull());
            if (notFullLot == null)
                throw new NoSpaceException("no space");

            return notFullLot.Park(car);
        }
    }
}