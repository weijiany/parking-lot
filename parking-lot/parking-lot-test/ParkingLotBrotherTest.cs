using System.Collections.Generic;
using parking_lot;
using Xunit;

namespace parking_lot_test
{
    public class ParkingLotBrotherTest
    {
        private const int parkingCount = 20;

        [Fact]
        public void should_keep_order_when_assign_parking_lot_to_a_parking_brother()
        {
            var lots = new List<ParkingLot>
            {
                new ParkingLot(parkingCount), new ParkingLot(parkingCount)
            };
            var brother = new ParkingBrother(lots);
            var brotherLots = brother.GetLots();

            Assert.Equal(lots, brotherLots);
        }

        [Fact]
        public void should_return_ticket_when_make_park_brother_park_a_car_given_parking_lot_has_only_one_space()
        {
            var parkingLot = new ParkingLot(1);
            var brother = new ParkingBrother(new List<ParkingLot> {parkingLot});
            var ticket = brother.Park(new Car());

            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_throw_NoSpaceException_when_make_park_brother_park_a_car_given_parking_lot_no_space()
        {
            var parkingLot = new ParkingLot(0);
            var brother = new ParkingBrother(new List<ParkingLot> {parkingLot});
            var exception = Assert.Throws<NoSpaceException>(() => brother.Park(new Car()));

            Assert.Equal("no space", exception.Message);
        }

        [Fact]
        public void should_keep_order_when_make_park_brother_park_a_car_given_brother_own_two_parking_lot_first_parking_lot_has_two_spaces()
        {
            var firsLot = new ParkingLot(2);
            var secondLot = new ParkingLot(0);
            var lots = new List<ParkingLot>
            {
                firsLot, secondLot
            };
            var brother = new ParkingBrother(lots);
            brother.Park(new Car());
            brother.Park(new Car());

            Assert.Equal(2, firsLot.CurrentCount());
            Assert.Equal(0, secondLot.CurrentCount());
        }

        [Fact]
        public void should_return_car_when_make_park_brother_pick_a_car_given_a_correct_ticket()
        {
            var parkingLot = new ParkingLot(1);
            var brother = new ParkingBrother(new List<ParkingLot> {parkingLot});
            var car = new Car();
            var ticket = brother.Park(car);
            Assert.Equal(car, brother.Pick(ticket));
        }

        [Fact]
        public void should_throw_InvalidTicketException_when_make_park_brother_pick_a_car_given_a_invalid_ticket()
        {
            var parkingLot = new ParkingLot(1);
            var brother = new ParkingBrother(new List<ParkingLot> {parkingLot});
            var car = new Car();
            var ticket = brother.Park(car);

            var exception = Assert.Throws<InvalidTicketException>(() => brother.Pick(new object()));
            Assert.Equal("invalid ticket", exception.Message);
        }

        [Fact]
        public void should_return_when_user_pick_a_car_given_the_ticket_is_created_by_brother()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var car = new Car();
            var brother = new ParkingBrother(new List<ParkingLot> {parkingLot1, parkingLot2});
            var ticket = brother.Park(car);

            Assert.Equal(car, parkingLot1.Pick(ticket));
            var exception = Assert.Throws<InvalidTicketException>(() => parkingLot2.Pick(ticket));
            Assert.Equal("invalid ticket", exception.Message);
        }

        [Fact]
        public void should_return_when_make_park_brother_pick_a_car_given_the_ticket_is_created_by_mine()
        {
            var parkingLot = new ParkingLot(1);
            var car = new Car();
            var ticket = parkingLot.Park(car);
            var brother = new ParkingBrother(new List<ParkingLot> {parkingLot});

            Assert.Equal(car, brother.Pick(ticket));
        }

        [Fact]
        public void should_throw_NotFoundException_when_make_park_brother_pick_a_car_given_the_car_not_in_parking_lots_of_managed_by_brother()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var brother = new ParkingBrother(new List<ParkingLot> {parkingLot1});
            var car = new Car();
            var ticket = parkingLot2.Park(car);

            var exception = Assert.Throws<InvalidTicketException>(() => brother.Pick(ticket));
            Assert.Equal("invalid ticket", exception.Message);
        }
    }
}