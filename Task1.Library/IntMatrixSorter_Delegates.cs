using System;
using System.Collections.Generic;

namespace Task1.Library
{
    public static class IntMatrixSorter_Delegates
    {
        public static void SortRows(int[][] array, IComparer<int[]> comparer)
        {
            SortRows(array, (a, b) => comparer.Compare(a, b));
        }


        public static void SortRows(int[][] array, Comparison<int[]> comparison)
        {
            int i = 1;
            bool found = true;

            while (i < array.Length && found)
            {
                found = false;
                for (int j = array.Length - 1; j >= i; j--)
                {
                    if (comparison(array[j - 1], array[j]) > 0)
                    {
                        SwapElements(array, j, j - 1);
                    }
                    found = true;
                }
                i++;
            }
        }

        private static void SwapElements(int[][] array, int i, int j)
        {
            int[] temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}
