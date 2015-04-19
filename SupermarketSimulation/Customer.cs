using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketSimulation
{
    /// <summary>
    /// Class for customer interaction with registers in a supermarket
    /// </summary>
    class Customer
    {
        /// <summary>
        /// Unique ID for customer
        /// </summary>
        public int CustomerID { get; private set; }

        /// <summary>
        /// Time of Arrival of customer
        /// </summary>
        public double ArrivalTime { get; private set; }

        /// <summary>
        /// Time required to serve customer 
        /// </summary>
        public double TimeToServe { get; private set; }

        /// <summary>
        /// default constructor for Customer class
        /// </summary>
        public Customer()
        {
            CustomerID = 0;
            ArrivalTime = 0;
            TimeToServe = 0;
        }

        /// <summary>
        /// parameterized constructor for Customer class
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <param name="ArrivalTime"></param>
        /// <param name="TimeToServe"></param>
        public Customer(int CustomerID, double ArrivalTime, double TimeToServe)
        {
            this.CustomerID = CustomerID;
            this.ArrivalTime = ArrivalTime;
            this.TimeToServe = TimeToServe;
        }


    }
}
