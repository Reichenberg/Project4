//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 4
//	File Name:		IPriorityQueue.cs
//	Description:    IPriority Queue Interface for Priority Queue
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
    /// IPriority Queue Interface for Priority Queue
    /// </summary>
    public interface IPriorityQueue<T> : IContainer<T> 
        where T : IComparable<T>
    {
        /// <summary>
        /// Inserts Item based on its priority
        /// </summary>
        /// <param name="item">Item to be inserted</param>
        void Enqueue(T item);
        /// <summary>
        /// Removes first item in the queue
        /// </summary>
        void Dequeue();
        /// <summary>
        /// Gets item in front of the queue
        /// </summary>
        /// <returns>item in the front of the queue</returns>
        T Peek();
    }
}
