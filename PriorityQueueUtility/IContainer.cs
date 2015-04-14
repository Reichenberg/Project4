//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 4
//	File Name:		IContainer.cs
//	Description:    IContainer Interface for Priority Queue
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

namespace PriorityQueueUtility
{
    /// <summary>
    /// IContainer Interface for Priority Queue
    /// </summary>
    public interface IContainer <T>
    {
        /// <summary>
        /// Removes all objects in the container
        /// </summary>
        void Clear();
        /// <summary>
        /// Checks to see if container is empty
        /// </summary>
        /// <returns>true is empty, false if not</returns>
        bool IsEmpty();
        /// <summary>
        /// Returns the Count of the Container
        /// </summary>
        int Count{get; set;}
    }
}
