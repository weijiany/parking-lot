using System.Collections.Generic;
using parking_lot;
using parking_lot.boy;
using Xunit;

namespace parking_lot_test
{
    public class SmartParkingLotBoyTest
    {
        [Fact]
        public void should_park_car_to_the_plot_with_the_maximum_number_of_empty_slots_when_given_a_car_and_multiple_available_parking_lots()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(3);
            var parkingLot3 = new ParkingLot(2);

            var bro = new SmartParkingBoy(new List<ParkingLot>
            {
                parkingLot1,
                parkingLot2,
                parkingLot3,
            });

            bro.Park(new Car());

            Assert.Equal(0, parkingLot1.CurrentCount());
            Assert.Equal(1, parkingLot2.CurrentCount());
            Assert.Equal(0, parkingLot3.CurrentCount());
        }

        [Fact]
        public void should_park_car_to_the_first_plot_when_more_than_two_plots_have_same_number_of_empty_slots_as_maximum()
        {
            var parkingLot1 = new ParkingLot(2);
            var parkingLot2 = new ParkingLot(3);
            var parkingLot3 = new ParkingLot(3);

            var bro = new SmartParkingBoy(new List<ParkingLot>
            {
                parkingLot1,
                parkingLot2,
                parkingLot3,
            });

            bro.Park(new Car());

            Assert.Equal(0, parkingLot1.CurrentCount());
            Assert.Equal(1, parkingLot2.CurrentCount());
            Assert.Equal(0, parkingLot3.CurrentCount());
        }
    }
}