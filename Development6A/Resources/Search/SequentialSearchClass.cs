using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExtensionMethods;

namespace Development6A.Resources
{
    public static class SequentialSearchClass
    {
        /// <summary>
        /// Sequential Search algoritme for an IEnumerable.
        /// Private version for recusion use.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="StringArray"></param>
        /// <param name="Search"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private static int SequentialSearch<T>(this IEnumerable<T> Collection, T Search, int i)
        {
            if (Collection.ElementAt(i).Equals(Search))
            {
                return i;
            }
            if (i.LessThen(Collection.Count() - 1))
            {
                return SequentialSearch(Collection, Search, i + 1);
            }

            return -1;
        }

        /// <summary>
        /// Sequential Search algoritme for an IEnumerable.
        /// Public version for easy to use.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Collection"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        public static int SequentialSearch<T>(this IEnumerable<T> Collection, T Search)
        {
            int i = 0;

            if (Collection.ElementAt(i).Equals(Search))
            {
                return i;
            }
            if (i.LessThen(Collection.Count() - 1))
            {
                return SequentialSearch(Collection, Search, i + 1);
            }

            return -1;
        }
    }
}