using Moq;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;

using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class BookingHelper_OverlappingBookingsExistTests
    {
        private Mock<IBookingRepository> bookingRepository;
        private Booking existingBooking;

        [SetUp]
        public void SetUp()
        {
            this.bookingRepository = new Mock<IBookingRepository>();
            this.existingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2020, 10, 15),
                DepartureDate = DepartOn(2020, 10, 20),
                Reference = "a"
            };
            this.bookingRepository.Setup(x => x.GetActiveBookings(1)).Returns(
                new List<Booking>
                {
                    this.existingBooking
                }.AsQueryable()
                );
        }

        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new Booking
                {
                    Id = 1,
                    ArrivalDate = Before(this.existingBooking.ArrivalDate, days: 2),
                    DepartureDate = Before(this.existingBooking.ArrivalDate),
                    Reference = "a"
                },
                this.bookingRepository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingStartsBeforeAndFinishesInAMidelOfExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new Booking
                {
                    Id = 1,
                    ArrivalDate = Before(this.existingBooking.ArrivalDate),
                    DepartureDate = After(this.existingBooking.ArrivalDate),
                    Reference = "a"
                },
                this.bookingRepository.Object);

            Assert.That(result, Is.EqualTo(this.existingBooking.Reference));
        }

        [Test]
        public void BookingStartsBeforeAndFinishesAfterExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new Booking
                {
                    Id = 1,
                    ArrivalDate = Before(this.existingBooking.ArrivalDate),
                    DepartureDate = After(this.existingBooking.DepartureDate),
                    Reference = "a"
                },
                this.bookingRepository.Object);

            Assert.That(result, Is.EqualTo(this.existingBooking.Reference));
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

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }

        private DateTime Before(DateTime date, int days = 1) 
        {
            return date.AddDays(-days);
        }

        private DateTime After(DateTime date, int days = 1)
        {
            return date.AddDays(days);
        }
    }
}
