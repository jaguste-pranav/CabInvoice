using NUnit.Framework;
using CabInvoiceGenerator;

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
    }
}