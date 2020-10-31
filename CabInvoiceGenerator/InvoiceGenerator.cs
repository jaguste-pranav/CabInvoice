using canInvoiceGenTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        //Variable.
        RideType rideType;
        private RideRepository rideRepository;

        //Constants.
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;

        /// Constrcutor To Create RideRepository instance.
        /// </summary>
        /// <summary>
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                //If Ride type is Premium Then Rates Set For Premium else For Normal.
                if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
            }
        }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public InvoiceGenerator()
        {
        }

        /// <summary>
        /// Function to Calculate Fare.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
                }
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if (time < 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }

        public static double CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            InvoiceGenerator ig = new InvoiceGenerator(RideType.NORMAL);
            foreach (Ride ride in rides)
            {
                totalFare = totalFare + ig.CalculateFare(ride.distance, ride.time);
            }
            return totalFare;
        }
    }
}