//-----------------------------------------------------------------------
// <copyright file="CreatingTypes.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace CreatingTypes
{
    using System;

    /// <summary>
    /// The Class that holds realizations of given Tasks from EPAM
    /// Theme: Creating Types
    /// </summary>
    public static class CreatingTypes
    {
        /// <summary>
        /// Get root of Natural number 'degree' from a Real number 'number' with given 'precision' by using Newton's method
        /// </summary>
        /// <param name="a">Real number</param>
        /// <param name="n">Natural number</param>
        /// <param name="precision">Needed precision. Must be less than 1</param>
        /// <exception cref="ArgumentException">Value does not fall within the expected range.</exception>
        /// <returns>Root of number with given precision</returns>
        public static double FindNthRoot(double a, int n, double precision)
        {
            if (n < 2 || (n % 2 == 0 && a < 0) || Math.Abs(precision) >= 1)
            {
                throw new ArgumentException();
            }

            double tempN = n;
            double x0 = a / tempN;
            double x1 = (1 / tempN) * ((tempN - 1) * x0 + (a / Math.Pow(x0, n - 1)));

            while (Math.Abs(x0 - x1) >= precision * 0.1)
            {
                x0 = x1;
                x1 = (1 / tempN) * ((tempN - 1) * x0 + (a / Math.Pow(x0, n - 1)));
            }

            int digitsAfterComma = 0;
            string[] splitDigits = precision.ToString().Split('.', ',');
            if (splitDigits.Length == 2)
            {
                digitsAfterComma = splitDigits[1].Length;
            }
            else
            {
                while (precision < 1)
                {
                    digitsAfterComma++;
                    precision *= 10;
                }
            }

            double result = Math.Round(x1, digitsAfterComma);
            return result;
        }

        // Bubble Sort methods

        /// <summary>
        /// Bubbly sorts given 2D array by the Sum of the elements of lines of matrix
        /// </summary>
        /// <inheritdoc cref="BubbleSort(int[,], Func{int, int}, bool)"/>
        public static void BubbleSortBySum(int[,] array, bool increasing = true)
        {
            int func(int value) 
            {
                int sum = 0;
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    sum += array[value, i];
                }

                return sum;
            }

            BubbleSort(array, func, increasing);
        }

        /// <summary>
        /// Bubbly sorts given 2D array by the Minimum of the elements of lines of matrix
        /// </summary>
        /// <inheritdoc cref="BubbleSort(int[,], Func{int, int}, bool)"/>
        public static void BubbleSortByMin(int[,] array, bool increasing = true)
        {
            int func(int value) 
            {
                int min = array[0, 0];
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    if (array[value, i] < min)
                    {
                        min = array[value, i];
                    }
                }

                return min;
            }

            BubbleSort(array, func, increasing);
        }

        /// <summary>
        /// Bubbly sorts given 2D array by the Maximum of the elements of lines of matrix
        /// </summary>
        /// <inheritdoc cref="BubbleSort(int[,], Func{int, int}, bool)"/>
        public static void BubbleSortByMax(int[,] array, bool increasing = true)
        {
            int func(int value) 
            {
                int max = array[0, 0];
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    if (array[value, i] > max)
                    {
                        max = array[value, i];
                    }
                }

                return max;
            }

            BubbleSort(array, func, increasing);
        }

        /// <summary>
        /// Default Bubble sorter
        /// Sorts array with the given method
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="result">Gets the values to the comparisons</param>
        /// <param name="increasing">Should program sort by increasing? Default = true</param>
        private static void BubbleSort(int[,] array, Func<int, int> result, bool increasing)
        {
            Func<int, int, bool> increaser;
            if (increasing)
            {
                increaser = (int f, int s) => { return f < s; };
            }
            else
            {
                increaser = (int f, int s) => { return f > s; };
            }

            for (int i = 1; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(0) - 1; k++)
                {
                    int sum1 = result(k);
                    int sum2 = result(k + 1);
                    if (increaser(sum1, sum2))
                    {
                        SwapArrays(array, k, k + 1);
                    }
                }
            }

            void SwapArrays(int[,] array, int first, int second)
            {
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    int temp = array[second, i];
                    array[second, i] = array[first, i];
                    array[first, i] = temp;
                }
            }
        }
    }
}
