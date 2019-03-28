using System;

namespace ExtensionMethods
{
    /// <summary>
    /// Class that handels all the compares.
    /// </summary>
    public static class ComparatorClass
    {

        /// <summary>
        /// <para>This function compare the 2 values and return an integer.</para>
        /// <para>Return 1 if it is equeal</para>
        /// <para>Return 2 if it is greater then</para>
        /// <para>Return 3 if it is less then</para>
        /// <para>Return -1 if it is an error</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="V1"></param>
        /// <param name="V2"></param>
        /// <returns>1 OR 2 OR 3 OR -1</returns>
        public static int Comparator<T>(this T V1, T V2) where T : IComparable
        {
            // Gelijk aan.
            if (V1.CompareTo(V2) == 0)
            {
                return 1;
            }

            // Groter dan.
            if (V1.CompareTo(V2) > 0)
            {
                return 2;
            }

            //Kleiner dan.
            if (V1.CompareTo(V2) < 0)
            {
                return 3;
            }

            // Return fout code.
            return -1;
        }

        /// <summary>
        /// <para>Return True if the 2 values are equals</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="V1"></param>
        /// <param name="V2"></param>
        /// <returns></returns>
        public static bool GelijkAan<T>(this T V1, T V2) where T : IComparable
        {
            return Comparator(V1, V2) == 1;
        }

        /// <summary>
        /// <para>Return True if the 2 values are not equals</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="V1"></param>
        /// <param name="V2"></param>
        /// <returns></returns>
        public static bool NietGelijkAan<T>(this T V1, T V2) where T : IComparable
        {
            return Comparator(V1, V2) != 1;
        }

        /// <summary>
        /// <para>Return True if the first value is greater then the second value</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="V1"></param>
        /// <param name="V2"></param>
        /// <returns>True OR False</returns>
        public static bool GreaterThen<T>(this T V1, T V2) where T : IComparable
        {
            return Comparator(V1, V2) == 2;
        }

        /// <summary>
        /// <para>Return True if the first value is greater then the second value</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="V1"></param>
        /// <param name="V2"></param>
        /// <returns>True OR False</returns>
        public static bool GreaterThenOREqual<T>(this T V1, T V2) where T : IComparable
        {
            int temp = Comparator(V1, V2);
            return temp == 1 || temp == 2;
        }

        /// <summary>
        /// <para>Return True if the first value is less then the second value</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="V1"></param>
        /// <param name="V2"></param>
        /// <returns>True OR False</returns>
        public static bool LessThen<T>(this T V1, T V2) where T : IComparable
        {
            return Comparator(V1, V2) == 3;
        }

        /// <summary>
        /// <para>Return True if the first value is less then the second value or equal as the second value</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="V1"></param>
        /// <param name="V2"></param>
        /// <returns>True OR False</returns>
        public static bool LessThenOREqual<T>(this T V1, T V2) where T : IComparable
        {
            int temp = Comparator(V1, V2);
            return temp == 1 || temp == 3;
        }
    }
}