using System;
using System.Collections.Generic;

/*
    Script: PriorityQueue
    Author: Thanh Hon
    Version: 1.0
    Description: Custom Queue data structure with added functionality for sorting elements
    Usage: Its usage is the same as the standard queue and can be used for other purposes
*/
namespace Luminous.Core.Memory
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        // internal array for the implementation of the priority queue structure
        private List<T> internalList = new List<T>();

        // add an item to the queue
        public void Enqueue(T item)
        {
            internalList.Add(item);
            CalculateUp();
        }

        // return the current item in the list, and then remove it from the queue
        public T Dequeue()
        {
            T item = internalList[0];
            MoveLastItemToTop();
            CalculateDown();

            return item;
        }

        // take a look at the value of current node, without performing any sorting operations
        public T Peek()
        {
            T item = internalList[0];

            return item;
        }


        // get the number of elements in the list
        public int Count
        {
            get { return internalList.Count; }
        }

        // move the smallest value in the structure to the top
        private void CalculateUp()
        {
            int childIndex = internalList.Count - 1;

            while ( childIndex > 0 )
            {
                int parentIndex = (childIndex - 1) / 2;

                if (internalList[childIndex].CompareTo(internalList[parentIndex]) >= 0)
                    break;

                Swap(childIndex, parentIndex);
                childIndex = parentIndex;
            }
        }

        // move the largest value in the structure down
        private void CalculateDown()
        {
            int lastIndex = internalList.Count - 1;
            int parentIndex = 0;

            while (true)
            {
                int firstChildIndex = parentIndex * 2 + 1;

                if (firstChildIndex > lastIndex)
                    break;

                int secondChildIndex = firstChildIndex + 1;
                
                if (secondChildIndex <= lastIndex && 
                    internalList[secondChildIndex].CompareTo(internalList[firstChildIndex]) < 0)
                {
                    firstChildIndex = secondChildIndex;
                }

                if (internalList[parentIndex].CompareTo(internalList[firstChildIndex]) < 0)
                    break;

                Swap(parentIndex, firstChildIndex);
                parentIndex = firstChildIndex;
            }
        }

        // move the last element of the array to the top
        private void MoveLastItemToTop()
        {
            int lastIndex = internalList.Count - 1;

            internalList[0] = internalList[lastIndex];
            internalList.RemoveAt(lastIndex);
        }

        // swap two nodes with each other
        private void Swap(int NodeA, int NodeB)
        {
            T tmpNode = internalList[NodeA];
            internalList[NodeA] = internalList[NodeB];
            internalList[NodeB] = tmpNode;
        }
    }
}