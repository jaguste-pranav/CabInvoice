using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        // Variables.
        private int numberOfRides;
        private double totalFare;
        private double averageFare;

        /// <summary>
        /// Parameter Constructor For Setting Data.
        /// </summary>
        /// <param name="numberOfRides"></param>
        /// <param name="totalFare"></param>
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            //Setting Data.
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }
    }
}
