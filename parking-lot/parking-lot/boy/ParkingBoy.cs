using System.Collections.Generic;
using System.Linq;
using parking_lot.exception;

namespace parking_lot.boy
{
    public class ParkingBoy : AbstractBoy
    {
        public ParkingBoy(IList<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public override object Park(Car car)
        {
            var notFullLot = ParkingLots.FirstOrDefault(l => !l.IsFull());
            if (notFullLot == null)
                throw new NoSpaceException("no space");

            return notFullLot.Park(car);
        }
    }
}