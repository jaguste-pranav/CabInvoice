using NUnit.Framework;
using CabInvoiceGenerator;
using System.Linq;

namespace canInvoiceGenTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void GivenRide_ShouldReturn()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }

        [Test]
        public void GivenMultipleRides_ShouldReturnTotalFare()
        {
            Ride[] rides =
            {
                new Ride(2.0, 2),
                new Ride(5.0, 5),
                new Ride(3.0, 3),
                new Ride(8.0, 8)
            };
            double expected = 198;
            double actualFare = InvoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(expected, actualFare);
        }

        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            Ride[] rides =
            {
                new Ride(2.0, 2),
                new Ride(5.0, 5),
                new Ride(3.0, 3),
                new Ride(8.0, 8)
            };
            
            InvoiceSummary expected = new InvoiceSummary(4, 198);
            InvoiceSummary summary = new InvoiceSummary(rides.Length, InvoiceGenerator.CalculateFare(rides));
            Assert.AreEqual(expected.totalFare, summary.totalFare);
            Assert.AreEqual(expected.averageFare, summary.averageFare);
            Assert.AreEqual(expected.numberOfRides, summary.numberOfRides);
        }

        [Test]
        public void GivenUserId_ShouldReturnListOfRides()
        {
            Ride[] rides =
            {
                new Ride(2.0, 2),
                new Ride(5.0, 5),
                new Ride(3.0, 3),
                new Ride(8.0, 8)
            };

            string userId = "1";
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            invoiceGenerator.AddRides(userId, rides);
            Ride[] output = invoiceGenerator.rideRepository.GetRides(userId);
            Assert.AreEqual(rides, output);
        }

        [Test]
        public void GivenMultipleRidesOfPremium_ShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 10.0;
            int time = 6;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 162;
            Assert.AreEqual(expected, fare);
        }
    }
}