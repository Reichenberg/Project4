//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Project 4
//	File Name:		PriorityQueue.cs
//	Description:    Pritority Queue class used for handling data
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
    /// Pritority Queue class used for handling data
    /// </summary>
    public class PriorityQueue<T> : IPriorityQueue<T> where T: IComparable
    {
        private Node<T> top;

        public int Count { get; set; }

        /// <summary>
        /// Adds an item to the priority Queue
        /// </summary>
        /// <param name="item">Item to be added to the priority queue</param>
        public void Enqueue(T item)
        {
            if(Count == 0)
            {
                top = new Node<T>(item, null);
            }
            else
            {
                Node<T> current = top;
                Node<T> previous = null;

                while(current != null && current.Item.CompareTo(item) >= 0)
                {
                    previous = current;
                    current = current.Next;
                }

                Node<T> newNode = new Node<T>(item, current);

                if(previous != null)
                {
                    previous.Next = newNode;
                }
                else
                {
                    top = newNode;
                }
            }
            Count++;
        }

        /// <summary>
        /// Removes an item from the queue
        /// </summary>
        public void Dequeue()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException("Cannot remove from empty queue.");
            }
            else
            {
                Node<T> oldNode = top;
                top = top.Next;
                Count--;
                oldNode = null;
            }
        }

        /// <summary>
        /// Clear the Priority Queue
        /// </summary>
        public void Clear()
        {
            top = null;
        }

        /// <summary>
        /// Return the top item of the Priority Queue
        /// </summary>
        /// <returns>Top item of the priority queue</returns>
        public T Peek()
        {
            if(!IsEmpty())
            {
                return top.Item;
            }
            else
            {
                throw new InvalidOperationException("Cannot obtain top of empty priority queue.");
            }
        }

        /// <summary>
        /// Determines if the list is empty or not
        /// </summary>
        /// <returns>true if empty, false if not</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }


}
