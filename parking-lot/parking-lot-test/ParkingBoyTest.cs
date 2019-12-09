using System.Collections.Generic;
using parking_lot;
using parking_lot.boy;
using parking_lot.exception;
using Xunit;

namespace parking_lot_test
{
    public class ParkingLotBoyTest
    {
        private const int ParkingCount = 20;

        [Fact]
        public void should_keep_order_when_assign_parking_lot_to_a_parking_boy()
        {
            var lots = new List<ParkingLot>
            {
                new ParkingLot(ParkingCount), new ParkingLot(ParkingCount)
            };
            var boy = new ParkingBoy(lots);

            Assert.Equal(lots, boy.ParkingLots);
        }

        [Fact]
        public void should_return_ticket_when_make_park_boy_park_a_car_given_parking_lot_has_only_one_space()
        {
            var parkingLot = new ParkingLot(1);
            var boy = new ParkingBoy(new List<ParkingLot> {parkingLot});
            var ticket = boy.Park(new Car());

            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_throw_NoSpaceException_when_make_park_boy_park_a_car_given_parking_lot_no_space()
        {
            var parkingLot = new ParkingLot(0);
            var boy = new ParkingBoy(new List<ParkingLot> {parkingLot});
            var exception = Assert.Throws<NoSpaceException>(() => boy.Park(new Car()));

            Assert.Equal("no space", exception.Message);
        }

        [Fact]
        public void should_keep_order_when_make_park_boy_park_a_car_given_boy_own_two_parking_lot_first_parking_lot_has_two_spaces()
        {
            var firsLot = new ParkingLot(2);
            var secondLot = new ParkingLot(0);
            var lots = new List<ParkingLot>
            {
                firsLot, secondLot
            };
            var boy = new ParkingBoy(lots);
            boy.Park(new Car());
            boy.Park(new Car());

            Assert.Equal(2, firsLot.CurrentCount());
            Assert.Equal(0, secondLot.CurrentCount());
        }

        [Fact]
        public void should_return_car_when_make_park_boy_pick_a_car_given_a_correct_ticket()
        {
            var parkingLot = new ParkingLot(1);
            var boy = new ParkingBoy(new List<ParkingLot> {parkingLot});
            var car = new Car();
            var ticket = boy.Park(car);
            Assert.Equal(car, boy.Pick(ticket));
        }

        [Fact]
        public void should_throw_InvalidTicketException_when_make_park_boy_pick_a_car_given_a_invalid_ticket()
        {
            var parkingLot = new ParkingLot(1);
            var boy = new ParkingBoy(new List<ParkingLot> {parkingLot});
            var car = new Car();
            var ticket = boy.Park(car);

            var exception = Assert.Throws<InvalidTicketException>(() => boy.Pick(new object()));
            Assert.Equal("invalid ticket", exception.Message);
        }

        [Fact]
        public void should_return_when_user_pick_a_car_given_the_ticket_is_created_by_boy()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var car = new Car();
            var boy = new ParkingBoy(new List<ParkingLot> {parkingLot1, parkingLot2});
            var ticket = boy.Park(car);

            Assert.Equal(car, parkingLot1.Pick(ticket));
            var exception = Assert.Throws<InvalidTicketException>(() => parkingLot2.Pick(ticket));
            Assert.Equal("invalid ticket", exception.Message);
        }

        [Fact]
        public void should_return_when_make_park_boy_pick_a_car_given_the_ticket_is_created_by_mine()
        {
            var parkingLot = new ParkingLot(1);
            var car = new Car();
            var ticket = parkingLot.Park(car);
            var boy = new ParkingBoy(new List<ParkingLot> {parkingLot});

            Assert.Equal(car, boy.Pick(ticket));
        }

        [Fact]
        public void should_throw_NotFoundException_when_make_park_boy_pick_a_car_given_the_car_not_in_parking_lots_of_managed_by_boy()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var boy = new ParkingBoy(new List<ParkingLot> {parkingLot1});
            var car = new Car();
            var ticket = parkingLot2.Park(car);

            var exception = Assert.Throws<InvalidTicketException>(() => boy.Pick(ticket));
            Assert.Equal("invalid ticket", exception.Message);
        }
    }
}