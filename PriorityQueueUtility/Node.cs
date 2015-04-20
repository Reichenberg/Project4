//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 4
//	File Name:		Node.cs
//	Description:    Node to represent item held in Priority Queue
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
    /// Node class for the nodes in the priority queue
    /// </summary>
    /// <typeparam name="T">Item type to be held in the node</typeparam>
     class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }

        /// <summary>
        /// Constructor for Node class
        /// </summary>
        /// <param name="value">Value to be held in Node class</param>
        /// <param name="link">Link to the next node</param>
        public Node(T value, Node<T> link)
        {
            Item = value;
            Next = link;
        }
    }
}
