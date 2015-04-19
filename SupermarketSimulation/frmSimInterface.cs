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

namespace SupermarketSimulation
{
    /// <summary>
    /// Gui for the SuperMarket Simulation
    /// </summary>
    public partial class frmSimInterface : Form
    {
        /// <summary>
        /// Default constructor for the form
        /// </summary>
        public frmSimInterface()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            int NumCustomers = int.Parse(txtCustomers.Text);
            int HoursOfOperation = int.Parse(txtHours.Text);
            int NumRegisters = int.Parse(txtRegisters.Text);
        }

        private double ExponentialNum(int UniformRand, int RateParameter)
        {
            return Math.Log(1 - UniformRand) / (-RateParameter);
        }

        private int PoissonNum(int lambda, Random R)
        {
            double L = Math.Exp(-lambda);
            int k = 0;
            double p = 1;
            do
            {
                k = k + 1;
                double u = R.Next();
                p = p * u;
            } while (p > L);
            return k - 1;
        }
    
    
    }

}
