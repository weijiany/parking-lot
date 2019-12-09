using System;
using parking_lot;
using parking_lot.exception;
using Xunit;

namespace parking_lot_test
{
    public class ParkingLotTest
    {
        private readonly Car _car;
        private readonly ParkingLot _parkingLot;
        private const int ParkingLotSize = 20;

        public ParkingLotTest()
        {
            _car = new Car();
            _parkingLot = new ParkingLot(ParkingLotSize);
        }

        [Fact]
        public void should_park_a_car_into_a_parking_lot_which_has_space_and_get_a_ticket()
        {
            var ticket = _parkingLot.Park(_car);

            Assert.NotNull(ticket);
        }

//        given 一个停车场和一个有效小票 when 我去停车场取车 then 我可以取到我停的那辆车
        [Fact]
        public void should_get_the_car_given_valid_ticket_to_take_the_car()
        {
            var ticket = _parkingLot.Park(_car);

            var myCar = _parkingLot.Pick(ticket);

            Assert.Equal(_car, myCar);
        }

        [Fact]
        public void should_not_take_the_car_when_given_a_invalid_ticket()
        {
            var ticketInvalid = new object();

            Assert.Throws<InvalidTicketException>(() => _parkingLot.Pick(ticketInvalid));
        }

        [Fact]
        public void should_not_get_the_car_when_given_a_ticket_has_used()
        {
            var ticketUseWithSecond = _parkingLot.Park(_car);

            var car = _parkingLot.Pick(ticketUseWithSecond);

            Assert.Equal(_car, car);

            Assert.Throws<InvalidTicketException>(() => _parkingLot.Pick(ticketUseWithSecond));
        }

        [Fact]
        public void should_not_park_car_when_parkinglot_is_full()
        {
            for (var i = 0; i < ParkingLotSize; i++)
            {
                _parkingLot.Park(new Car());
            }

            Assert.Throws<NoSpaceException>(() => _parkingLot.Park(new Car()));
        }

        [Fact]
        void should_return_true_when_lot_not_full()
        {
            Assert.False(_parkingLot.IsFull());
        }

        [Fact]
        void should_return_true_when_check_a_car_in_parking_lot_given_the_car_in_parking_lot_()
        {
            var car = new Car();
            var ticket = _parkingLot.Park(car);

            Assert.True(_parkingLot.TicketIsValid(ticket));
        }

        [Fact]
        void should_return_remain_space_count()
        {
            _parkingLot.Park(_car);

            Assert.Equal(ParkingLotSize - 1, _parkingLot.RemainSpaceCount());
        }
    }
}