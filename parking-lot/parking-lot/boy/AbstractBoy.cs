using System.Collections.Generic;
using System.Linq;
using parking_lot.exception;

namespace parking_lot.boy
{
    public abstract class AbstractBoy
    {
        public IList<ParkingLot> ParkingLots { get; }

        protected AbstractBoy(IList<ParkingLot> parkingLots)
        {
            ParkingLots = parkingLots;
        }

        public abstract object Park(Car car);

        public Car Pick(object ticket)
        {
            var parkingLot = ParkingLots.FirstOrDefault(l => l.TicketIsValid(ticket));
            if (parkingLot == null)
                throw new InvalidTicketException("invalid ticket");

            return parkingLot.Pick(ticket);
        }
    }
}