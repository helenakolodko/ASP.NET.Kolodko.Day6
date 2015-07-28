using System;
using System.Collections.Generic;

namespace Task1.Library
{
    public static class IntMatrixSorter_Interfaces
    {
        public static void SortRows(int[][] array, Comparison<int[]> comparison)
        {
            SortRows(array, new DelegateAdapter(comparison));
        }
        public static void SortRows(int[][] array, IComparer<int[]> comparer)
        {
            int i = 1;
            bool found = true;

            while (i < array.Length && found)
            {
                found = false;
                for (int j = array.Length - 1; j >= i; j--)
                {
                    if (comparer.Compare(array[j - 1], array[j]) > 0)
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

        private class DelegateAdapter : IComparer<int[]>
        {
            private Comparison<int[]> comparison;
            public DelegateAdapter(Comparison<int[]> comparison)
            {
                if (ReferenceEquals(comparison, null))
                    throw new ArgumentNullException();
                this.comparison = comparison;
            }
            public int Compare(int[] x, int[] y)
            {
                return comparison(x, y);
            }
        }
    }
}
