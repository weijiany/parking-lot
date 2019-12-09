using System.Collections.Generic;
using parking_lot;
using parking_lot.boy;
using parking_lot.exception;
using Xunit;

namespace parking_lot_test
{
    public class ParkingBotTest
    {
        [Fact]
        public void should_return_ticket_when_make_park_bot_park_a_car_given_parking_lot_has_only_one_space()
        {
            var parkingLot = new ParkingLot(1);
            var bot = new ParkingBot(new List<ParkingLot> {parkingLot});
            var ticket = bot.Park(new Car());

            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_throw_NoSpaceException_when_make_park_bot_park_a_car_given_parking_lot_no_space()
        {
            var parkingLot = new ParkingLot(0);
            var bot = new ParkingBot(new List<ParkingLot> {parkingLot});
            var exception = Assert.Throws<NoSpaceException>(() => bot.Park(new Car()));

            Assert.Equal("no space", exception.Message);
        }

        [Fact]
        public void should_keep_order_when_make_park_bot_park_a_car_given_bot_own_two_parking_lot_first_parking_lot_has_two_spaces()
        {
            var firsLot = new ParkingLot(2);
            var secondLot = new ParkingLot(0);
            var lots = new List<ParkingLot>
            {
                firsLot, secondLot
            };
            var bot = new ParkingBot(lots);
            bot.Park(new Car());
            bot.Park(new Car());

            Assert.Equal(2, firsLot.CurrentCount());
            Assert.Equal(0, secondLot.CurrentCount());
        }

        [Fact]
        public void should_return_when_user_pick_a_car_given_the_ticket_is_created_by_bot()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var car = new Car();
            var bot = new ParkingBot(new List<ParkingLot> {parkingLot1, parkingLot2});
            var ticket = bot.Park(car);

            Assert.Equal(car, parkingLot1.Pick(ticket));
            var exception = Assert.Throws<InvalidTicketException>(() => parkingLot2.Pick(ticket));
            Assert.Equal("invalid ticket", exception.Message);
        }
    }
}