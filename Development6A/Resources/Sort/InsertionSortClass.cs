using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExtensionMethods;

namespace Development6A.Resources
{
    public static class InsertionSortClass
    {
        /// <summary>
        /// Insertionsort algoritme for an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="intArray"></param>
        /// <returns>T[]</returns>
        public static T[] InsertionSort<T>(this T[] Collection) where T : IComparable
        {

            for (int j = 1; j < Collection.Length; j++)
            {
                T key = Collection[j];
                int i = j - 1;
                while (i >= 0 && Collection[i].GreaterThen(key))
                {
                    Collection[i + 1] = Collection[i];
                    i = i - 1;
                }

                Collection[i + 1] = key;
            }

            return Collection;
        }

        /// <summary>
        /// Insertionsort algoritme for an list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="intArray"></param>
        /// <returns>List<T></T></returns>
        public static List<T> InsertionSort<T>(this List<T> Collection) where T : IComparable
        {

            for (int j = 1; j < Collection.Count; j++)
            {
                T key = Collection[j];
                int i = j - 1;
                while (i >= 0 && Collection[i].GreaterThen(key))
                {
                    Collection[i + 1] = Collection[i];
                    i = i - 1;
                }

                Collection[i + 1] = key;
            }

            return Collection;
        }

        /// <summary>
        /// Insertionsort algoritme for an IEnumberable it is slower then for an array or an list.
        /// It wil always return an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="intArray"></param>
        /// <returns>T[]</returns>
        public static T[] InsertionSort<T>(this IEnumerable<T> Collection) where T : IComparable
        {
            T[] TempArray = new T[Collection.Count()];
            for (int j = 1; j < TempArray.Length; j++)
            {
                T key = TempArray[j];
                int i = j - 1;
                while (i >= 0 && TempArray[i].GreaterThen(key))
                {
                    TempArray[i + 1] = TempArray[i];
                    i = i - 1;
                }

                TempArray[i + 1] = key;
            }

            return TempArray;
        }
    }
}