//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 4
//	File Name:		Event.cs
//	Description:    Event class used to manage certain events in simulation
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Chance Reichenberg, reichenberg@etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Friday, April 10, 2015
//	Copyright:		Chance Reichenberg, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketSimulation
{
    /// <summary>
    /// Enum to represent event types
    /// </summary>
    enum EVENTTYPE { ENTER, LEAVE};

    /// <summary>
    /// Class used to handle events that happen to patrons
    /// </summary>
    class Event : IComparable
    {
        public EVENTTYPE Type { get; set; }
        public DateTime Time { get; set; }
        public int Patron { get; set; }

        /// <summary>
        /// Defuault constructor for Event class
        /// </summary>
        public Event()
        {
            Type = EVENTTYPE.ENTER;
            Time = DateTime.Now;
            Patron = -1;
        }

        /// <summary>
        /// Parameterized constructor for Event
        /// </summary>
        /// <param name="type">type of the event</param>
        /// <param name="time">Time of the event</param>
        /// <param name="patron">Who the event happened to</param>
        public Event(EVENTTYPE type, DateTime time, int patron)
        {
            Type = type;
            Time = time;
            Patron = patron;
        }

        /// <summary>
        /// Implementation of CompareTo Method to compare the time of the events
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>Comparison value</returns>
        public int CompareTo(Object obj)
        {
            if(!(obj is Event))
            {
                throw new ArgumentException("The argument is not an Event object.");
            }
            Event e = (Event)obj;
            return (e.Time.CompareTo(Time));
        }
    }
}
