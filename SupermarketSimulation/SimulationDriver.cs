//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 4
//	File Name:		SimulationDriver.cs
//	Description:    Driver for the Supermarket Simulation program
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Chance Reichenberg, reichenberg@etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Friday, April 10, 2015
//	Copyright:		Chance Reichenberg, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketSimulation
{
    /// <summary>
    /// Driver for the Supermarket Simulation program
    /// </summary>
    static class SimulationDriver
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSimInterface());
        }
    }
}
