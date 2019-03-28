using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExtensionMethods;

namespace Development6A.Resources
{
    public static class MergeSortClass
    {
        /// <summary>
        /// Merge and sort everything that has been spereted with mergesort.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="middle"></param>
        /// <param name="right"></param>
        public static T[] Merge<T>(IEnumerable<T> Collection, int left, int middle, int right) where T : IComparable
        {
            // Bereken de linker en rechter length.
            int LeftLength = middle - left + 1;
            int RightLength = right - middle;
            T[] array = new T[Collection.Count()];

            // Make the left and right array.
            var LeftArray = new T[LeftLength];
            var RightArray = new T[RightLength];

            // Fill the left array from the array.
            for (int i = 0; i < LeftLength; i++)
            {
                LeftArray[i] = Collection.ElementAt(left + i);
            }

            // Fill the right array from the array.
            for (int j = 0; j < RightLength; j++)
            {
                RightArray[j] = Collection.ElementAt(middle + j + 1);
            }

            // Set initial place where we should start from the left and right array.
            int PointinLeftArray = 0;
            int PointinRightArray = 0;

            // Set initial place in result array.
            int PointinResultArray = left;

            // Order all the items in the array
            while (PointinLeftArray < LeftLength && PointinRightArray < RightLength)
            {
                // Als leftArray in kleiner of gelijk aan rightarray dan wordt leftarray an de array toegevoegd.
                // Anders wordt dit gedaan door de Righitarrray.
                if (LeftArray[PointinLeftArray].LessThenOREqual(RightArray[PointinRightArray]))
                {
                    array[PointinResultArray] = LeftArray[PointinLeftArray];
                    PointinLeftArray++;
                    PointinResultArray++;
                }
                else
                {
                    array[PointinResultArray] = RightArray[PointinRightArray];
                    PointinRightArray++;
                    PointinResultArray++;
                }
            }

            // If Left array stil contains some items then empty it and add the results in the array.
            while (PointinLeftArray < LeftLength)
            {
                array[PointinResultArray] = LeftArray[PointinLeftArray];
                PointinLeftArray++;
                PointinResultArray++;
            }

            // If the right array still has some value then empty it and add the results in the array.
            while (PointinRightArray < RightLength)
            {
                array[PointinResultArray] = RightArray[PointinRightArray];
                PointinRightArray++;
                PointinResultArray++;
            }

            // Return the array.
            return array;
        }

        // Print an Array.
        public static void printArray<T>(IEnumerable<T> array)
        {
            for (int i = 0; i < array.Count(); i++)
            {
                Console.WriteLine("{0} = {1} ", i, array.ElementAt(i));
            }
        }

        /// <summary>
        /// Split the array in smaller sizes.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static IEnumerable<T> MergeSort<T>(IEnumerable<T> array, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                array = Merge<T>(array, left, middle, right);

            }

            return array;
        }
        // MERGE SORT FOR INTEGERS
        public static void Merge(int[] array, int left, int middle, int right)
        {

            int LeftLength = middle - left + 1;
            int RightLength = right - middle;

            var LeftArray = new int[LeftLength + 1];
            var RightArray = new int[RightLength + 1];

            for (int i = 0; i < LeftLength; i++)
            {
                LeftArray[i] = array[left + i];
            }

            for (int j = 0; j < RightLength; j++)
            {
                RightArray[j] = array[middle + j + 1];
            }

            LeftArray[LeftLength] = Int32.MaxValue;
            RightArray[RightLength] = Int32.MaxValue;

            int i2 = 0;
            int j2 = 0;

            for (int k = left; k <= right; k++)
            {
                if (LeftArray[i2] <= RightArray[j2])
                {
                    array[k] = LeftArray[i2];
                    i2++;
                }
                else
                {
                    array[k] = RightArray[j2];
                    j2++;
                }
            }

        }
    }
}