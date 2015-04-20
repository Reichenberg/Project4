﻿//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 4
//	File Name:		frmSimInterface.cs
//	Description:    Gui for the supermarket simulation
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Chance Reichenberg, reichenberg@etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Friday, April 10, 2015
//	Copyright:		Chance Reichenberg, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriorityQueueUtility;

namespace SupermarketSimulation
{
    /// <summary>
    /// Gui for the SuperMarket Simulation
    /// </summary>
    public partial class frmSimInterface : Form
    {

        Random rand = new Random();
        PriorityQueue<Event> PQ = new PriorityQueue<Event>();
        List<Queue<Customer>> registers;
        int maximumLineLength = 0;
        int numCustomers = 0;
        int hoursOfOperation = 0;
        int numRegisters = 0;
        double expectedCheckoutDuration = 6.25;
        double[] WaitingTime; 

        /// <summary>
        /// Default constructor for the form
        /// </summary>
        public frmSimInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button click event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
             numCustomers = PoissonNum(Double.Parse(txtCustomers.Text));
             hoursOfOperation = int.Parse(txtHours.Text);
             numRegisters = int.Parse(txtRegisters.Text);
             WaitingTime = new double[numRegisters];
             expectedCheckoutDuration = Double.Parse(txtCheckoutDuration.Text);

             registers = new List<Queue<Customer>>();
             for (int count = 0; count < numRegisters; count++ )
             {
                 registers.Add(new Queue<Customer>());
             }
                 GenerateCustomerArrivals();
             RunSimulation();
        }

        /// <summary>
        /// Negative exponential distribution generator method
        /// </summary>
        /// <param name="expectedValue">Value used to generate Negative exponential value</param>
        /// <returns>Negative exponential number</returns>
        private double NegExponentialNum(double expectedValue)
        {
            return -expectedValue * Math.Log(rand.NextDouble());
        }

        /// <summary>
        /// Poisson distribution number generator method
        /// </summary>
        /// <param name="expectedValue">value used to generate the numbers around</param>
        /// <returns>poisson distribution value</returns>
        private int PoissonNum(double expectedValue)
        {
            double dLimit = -expectedValue;
            double dSum = Math.Log(rand.NextDouble());

            int count;
            for(count = 0; dSum > dLimit; count++)
            {
                dSum += Math.Log(rand.NextDouble());
            }
            return count;
        }

        /// <summary>
        /// Method to generate customer events
        /// </summary>
        private void GenerateCustomerArrivals()
        {
            for(int i = 0; i < numCustomers; i++)
            {
                Customer tempCust = new Customer(i + 1, new TimeSpan(0, rand.Next(hoursOfOperation * 60), 0), new TimeSpan(0, (int)(2 + NegExponentialNum(expectedCheckoutDuration)), 0));
                PQ.Enqueue(new Event(EVENTTYPE.ENTER, tempCust, tempCust.ArrivalTime));
            }
        }

        /// <summary>
        /// Method that runs the Supermarket Simulation
        /// </summary>
        private void RunSimulation()
        {
            while(PQ.Count != 0)
            {
                int shortestLineIndex = 0;
                int lineLength = registers[0].Count;
                Event tempEvent = PQ.Peek();

                //Handles the enter event  by adding the person to the shortest line 
                //and creating an exit event based on the time they have to wait to exit
                if(tempEvent.Type == EVENTTYPE.ENTER)
                {
                    //Gets the index of the shortest line to be checked out
                    for(int i = 0; i < registers.Count; i++)
                    {
                        shortestLineIndex = (registers[i].Count < lineLength) ? i : shortestLineIndex;

                    }

                    //Sets the current waiting time to the total amoumt of time for
                    //each person to make it through the line
                    WaitingTime[shortestLineIndex] += tempEvent.Customer.TimeToServe.TotalMinutes;
                    tempEvent.Customer.TimeWaiting = WaitingTime[shortestLineIndex];        //Sets the customer's time needed to wait to that total waiting time
                    registers[shortestLineIndex].Enqueue(tempEvent.Customer);               //Add the customer to the shortest line

                    TimeSpan custExitTime = new TimeSpan(0, (int)(tempEvent.Customer.ArrivalTime.TotalMinutes + tempEvent.Customer.TimeWaiting), 0);

                    PQ.Enqueue(new Event(EVENTTYPE.LEAVE, tempEvent.Customer, custExitTime));
                    PQ.Dequeue();       //Then remove that customer's arrival from the priority Queue
                }

                //Handles the exit event by finding where the person is and removing them from their line
                if(tempEvent.Type == EVENTTYPE.LEAVE)
                {
                    for(int count = 0; count < registers.Count; count++)
                        if (registers[count].Count > 0)
                        {
                            if (registers[count].Peek().CustomerID == tempEvent.Customer.CustomerID)
                            {
                                //Subtract the customer to be dequeued's TimeToServe from the Waiting time for that line
                                WaitingTime[count] -= registers[count].Peek().TimeToServe.TotalMinutes;
                                registers[count].Dequeue();     //Remove the customer from that line
                            }
                        }
                    PQ.Dequeue();       //Then remove that customer's Exit from the priority Queue
                }

                //int leaveIndex = 0;
                //double shortestTime = registers[0].Peek().ArrivalTime.TotalMinutes + registers[0].Peek().TimeToServe.TotalMinutes;

                //for(int i = 0; i < registers.Count - 1; i++)
                //{
                //    if (registers[i].Count > 0)
                //    leaveIndex = (registers[i].Peek().ArrivalTime.TotalMinutes + (WaitingTime[i] - registers[i].Peek().TimeWaiting) < shortestTime) ? i : leaveIndex;
                    
                //}
                // TimeSpan exitTime = new TimeSpan(0,(int)(registers[leaveIndex].Peek().ArrivalTime.TotalMinutes + (WaitingTime[leaveIndex] - registers[leaveIndex].Peek().TimeWaiting)), 0);

                //PQ.Enqueue(new Event(EVENTTYPE.LEAVE, registers[leaveIndex].Peek(),exitTime));
                //registers[leaveIndex].Dequeue();



            }
        }

        /// <summary>
        /// Validates data entered into text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyValidation_KeyPress(object sender, KeyPressEventArgs e)
        {
            //If the base is less than 10 only allow characters that are less than the base to be entered. If the base is 10 or greater allow 0-9 to be entered
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the close button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    
    
    }

}
