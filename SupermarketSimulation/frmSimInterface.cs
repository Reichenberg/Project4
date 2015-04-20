//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
        int maximumLineLength = 0;
        int numCustomers = 0;
        int hoursOfOperation = 0;
        int numRegisters = 0;

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
             numCustomers = int.Parse(txtCustomers.Text);
             hoursOfOperation = int.Parse(txtHours.Text);
             numRegisters = int.Parse(txtRegisters.Text);
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
        private void GenerateCustomers()
        {

        }
    
    
    }

}
