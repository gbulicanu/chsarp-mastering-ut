using Moq;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class BookingHelper_OverlappingBookingsExistTests
    {
        private Mock<IBookingRepository> bookingRepository;

        [SetUp]
        public void SetUp()
        {
            this.bookingRepository = new Mock<IBookingRepository>();
        }

        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            this.bookingRepository.Setup(x => x.GetActiveBookings(1)).Returns(
                new List<Booking>
                {
                    new Booking
                    {
                        Id = 2,
                        ArrivalDate = new DateTime(2020, 10, 15, 14, 0, 0),
                        DepartureDate = new DateTime(2020, 10, 20, 10, 0, 0),
                        Reference = "a"
                    }
                }.AsQueryable()
                );

            var result = BookingHelper.OverlappingBookingsExist(
                new Booking
                {
                    Id = 1,
                    ArrivalDate = new DateTime(2020, 10, 10, 14, 0, 0),
                    DepartureDate = new DateTime(2020, 10, 14, 10, 0, 0),
                    Reference = "a"
                },
                this.bookingRepository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void CancelledBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new Booking
                {
                    Id = 1,
                    ArrivalDate = new DateTime(2020, 10, 10, 14, 0, 0),
                    DepartureDate = new DateTime(2020, 10, 14, 10, 0, 0),
                    Reference = "a",
                    Status = "Cancelled"
                },
                this.bookingRepository.Object);

            Assert.That(result, Is.Empty);
        }
    }
}
