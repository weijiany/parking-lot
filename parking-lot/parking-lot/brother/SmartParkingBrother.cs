using System.Collections.Generic;
using System.Linq;

namespace parking_lot.brother
{
    public class SmartParkingBrother : AbstractBrother
    {
        public SmartParkingBrother(IList<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public override object Park(Car car)
        {
            var parkingLot = ParkingLots.Where(lot => !lot.IsFull()).OrderByDescending(lot => lot.RemainSpaceCount()).FirstOrDefault();
            if (parkingLot == null)
                throw new NoSpaceException("no space");

            return parkingLot.Park(car);
        }
    }
}