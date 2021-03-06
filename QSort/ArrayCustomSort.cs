﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingArrays
{   /// <summary>
    /// ArrayCustomSort class for sorting array at quick sorting algorithm.
    /// </summary>
    public static class ArrayCustomSort
    {
        private static int[] _incommArr;
        private static Random rnd;
        /// <summary>
        /// "QuickSort" for sorting array use mergesorting algorithm
        /// take incomming array. Transfer control to the
        /// recursive private method "DivArr for" sorting.
        /// </summary>
        /// <param name="incomm"> Is incomming array should be contains integer elements.
        /// It shouldn't have empty(null reference) array </param>
        /// <excception cref="ArgumentNullException">Thrown if incomming array is null</excception>
        public static void QuickSort(int[] incomm)
        {            
            if (incomm == null) throw new ArgumentNullException("Array is empty");
            
            _incommArr = incomm;
            int firstPtr = 0;
            int lastPtr = _incommArr.Length - 1;
            rnd = new Random();
            DivArr(firstPtr, lastPtr);
        }

        /// <summary>
        /// MergeSort method for sorting array use mergesorting algorithm
        /// take incomming array. Transfer control to the
        /// recursive private method RecursiveCall for sorting.
        /// </summary>
        /// <param name="incomming">incomming array should be contains integer elements.
        /// It shouldn't have empty(null reference) array </param>
        /// <excception cref="ArgumentNullException">Thrown if incomming array is null</excception>
        public static void MergeSort(int[] incomming)
        {
            if (incomming == null)
            {
                throw new ArgumentNullException("Array is empty");
            }
            int firstPtr = 0;
            int lastPtr = incomming.Length - 1;
            RecursiveCall(incomming, firstPtr, lastPtr);
        }

        private static void DivArr(int firstPtr, int lastPtr)
        {
            var f = firstPtr;
            var l = lastPtr;
            int temp;            
            int _support = _incommArr[rnd.Next(f, l)];
            do
            {
                while (_incommArr[f] < _support)
                    f++;
                while (_incommArr[l] >_support)
                    l--;
                if (f <= l)
                {
                    temp = _incommArr[f];
                    _incommArr[f] = _incommArr[l];
                    _incommArr[l] = temp;
                    f++;
                    l--;
                }
            } while (f < l);
            if (firstPtr < l)
                DivArr(firstPtr, l);
            if (f < lastPtr)
                DivArr(f, lastPtr);

        }
        
        

        private static void RecursiveCall(int[] incomming, int firstPtr, int lastPtr)
        {
            if (firstPtr < lastPtr)//if number of first element less than last element
            {
                RecursiveCall(incomming, firstPtr, (firstPtr + lastPtr) / 2);//sorting left side
                RecursiveCall(incomming, (firstPtr + lastPtr) / 2 + 1, lastPtr);//sorting right side
                Merge(incomming, firstPtr, lastPtr);//Merge
            }
        }

        private static void Merge(int[] incomming, int firstPtr, int lastPtr)
        {
            //start, final – numbers first variables left and right sides
            //intermed – массив, middle - numbler of middle elements
            int middle = (firstPtr + lastPtr) / 2;//calculate middle element
            int start = firstPtr;//Start position left side
            int final = middle + 1;//Start position right side
            int[] intermed = new int[incomming.Length];
            for (int i = firstPtr; i <= lastPtr; i++)
            {
                if ((start <= middle) && ((final > lastPtr) || (incomming[start] < incomming[final])))
                {
                    intermed[i] = incomming[start];
                    start++;
                }
                else
                {
                    intermed[i] = incomming[final];
                    final++;
                }
            }
            for (int i = firstPtr; i <= lastPtr; i++)//return result to list
            {
                incomming[i] = intermed[i];
            }
        }
    }
}
