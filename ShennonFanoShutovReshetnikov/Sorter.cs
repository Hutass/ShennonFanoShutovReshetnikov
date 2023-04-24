using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShennonFanoShutovReshetnikov.Decoder;
using static ShennonFanoShutovReshetnikov.Coder;

namespace ShennonFanoShutovReshetnikov
{
    #region Sorter
    internal class Sorter
    {
        public void QuickSort(List<SignSheet> sortedArray)
        {
            int leftBorder = 0;
            int rightBorder = sortedArray.Count - 1;
            QuickSort(sortedArray, leftBorder, rightBorder);
        }

        public void QuickSort(List<SignSheet> sortedArray, int leftBorder, int rightBorder)
        {
            int leftBuffer = leftBorder;
            int rightBuffer = rightBorder;
            var buffer = sortedArray[leftBuffer].count;
            while (leftBuffer <= rightBuffer)
            {
                while (sortedArray[leftBuffer].count > buffer)
                {
                    leftBuffer++;
                }

                while (sortedArray[rightBuffer].count < buffer)
                {
                    rightBuffer--;
                }

                if (leftBuffer <= rightBuffer)
                {
                    var temp = sortedArray[leftBuffer];
                    sortedArray[leftBuffer] = sortedArray[rightBuffer];
                    sortedArray[rightBuffer] = temp;
                    leftBuffer++;
                    rightBuffer--;
                }
            }

            if (leftBorder < rightBuffer)
                QuickSort(sortedArray, leftBorder, rightBuffer);
            if (leftBuffer < rightBorder)
                QuickSort(sortedArray, leftBuffer, rightBorder);
        }
        public void QuickSort(List<tableNote> sortedArray)
        {
            int leftBorder = 0;
            int rightBorder = sortedArray.Count - 1;
            QuickSort(sortedArray, leftBorder, rightBorder);
        }

        public void QuickSort(List<tableNote> sortedArray, int leftBorder, int rightBorder)
        {
            int leftBuffer = leftBorder;
            int rightBuffer = rightBorder;
            var buffer = sortedArray[leftBuffer].count;
            while (leftBuffer <= rightBuffer)
            {
                while (sortedArray[leftBuffer].count > buffer)
                {
                    leftBuffer++;
                }

                while (sortedArray[rightBuffer].count < buffer)
                {
                    rightBuffer--;
                }

                if (leftBuffer <= rightBuffer)
                {
                    var temp = sortedArray[leftBuffer];
                    sortedArray[leftBuffer] = sortedArray[rightBuffer];
                    sortedArray[rightBuffer] = temp;
                    leftBuffer++;
                    rightBuffer--;
                }
            }

            if (leftBorder < rightBuffer)
                QuickSort(sortedArray, leftBorder, rightBuffer);
            if (leftBuffer < rightBorder)
                QuickSort(sortedArray, leftBuffer, rightBorder);
        }
    }
    #endregion
}
