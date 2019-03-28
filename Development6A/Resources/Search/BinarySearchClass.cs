using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExtensionMethods;

namespace Development6A.Resources
{
    public static class BinarySearchClass
    {
        /// <summary>
        /// Binary Search algoritme for an IEnumerable private version for recusion.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="intArray"></param>
        /// <param name="SearchValue"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private static int BinarySearch<T>(this IEnumerable<T> Collection, T SearchValue, int low, int high) where T : IComparable
        {
            int middle = (low + high) / 2;

            if (SearchValue.LessThen(Collection.ElementAt(middle)))
            {
                return BinarySearch(Collection, SearchValue, low, middle - 1);
            }
            if (SearchValue.GreaterThen(Collection.ElementAt(middle)))
            {
                return BinarySearch(Collection, SearchValue, middle + 1, high);
            }

            return middle;
        }

        /// <summary>
        /// BinarySearch public starting version for easy to use.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Collection"></param>
        /// <param name="SearchValue"></param>
        /// <returns></returns>
        public static int BinarySearch<T>(this IEnumerable<T> Collection, T SearchValue) where T : IComparable
        {
            int low = 0;
            int high = Collection.Count();
            int middle = (low + high) / 2;

            if (SearchValue.LessThen(Collection.ElementAt(middle)))
            {
                return BinarySearch(Collection, SearchValue, low, middle - 1);
            }
            if (SearchValue.GreaterThen(Collection.ElementAt(middle)))
            {
                return BinarySearch(Collection, SearchValue, middle + 1, high);
            }

            return middle;
        }
    }
}