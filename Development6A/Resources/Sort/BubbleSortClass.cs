using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExtensionMethods;

namespace Development6A.Resources
{
    public static class BubbleSortClass
    {
        /// <summary>
        /// Bubble sort for an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Collection"></param>
        /// <returns></returns>
        public static T[] BubbleSort<T>(this T[] Collection) where T : IComparable
        {
            T temp;

            for (int i = 0; i < Collection.Length; i++)
            {
                for (int j = 0; j < Collection.Length - 1; j++)
                {
                    if (Collection[j].LessThen(Collection[j + 1]))
                    {
                        temp = Collection[j + 1];
                        Collection[j + 1] = Collection[j];
                        Collection[j] = temp;
                    }
                }
            }

            return Collection;
        }

        /// <summary>
        /// Bubble sort for list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Collection"></param>
        /// <returns></returns>
        public static List<T> BubbleSort<T>(this List<T> Collection) where T : IComparable
        {
            T temp;

            for (int i = 0; i < Collection.Count; i++)
            {
                for (int j = 0; j < Collection.Count - 1; j++)
                {
                    if (Collection[j].LessThen(Collection[j + 1]))
                    {
                        temp = Collection[j + 1];
                        Collection[j + 1] = Collection[j];
                        Collection[j] = temp;
                    }
                }
            }

            return Collection;
        }

        /// <summary>
        /// Bubble sort for IEnumberable
        /// It is slower then then the on for an array or list.
        /// It wil always return an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Collection"></param>
        /// <returns>T[]</returns>
        public static T[] BubbleSort<T>(this IEnumerable<T> Collection) where T : IComparable
        {
            T temp;
            T[] tempArray = new T[Collection.Count()];

            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = Collection.ElementAt(i);
            }

            for (int i = 0; i < tempArray.Length; i++)
            {
                for (int j = 0; j < tempArray.Length - 1; j++)
                {
                    if (tempArray[j].LessThen(tempArray[j + 1]))
                    {
                        temp = tempArray[j + 1];
                        tempArray[j + 1] = tempArray[j];
                        tempArray[j] = temp;
                    }
                }
            }

            return tempArray;
        }
    }
}