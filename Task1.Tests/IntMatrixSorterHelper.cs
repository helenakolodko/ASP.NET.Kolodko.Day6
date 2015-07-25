using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    public static class IntMatrixSorterHelper
    {
        public static int CompareByMagnitudeAscending(int[] a, int[] b)
        {
            int firstMax = GetMaxMagnitude(a);
            int secondMax = GetMaxMagnitude(b);
            return firstMax.CompareTo(secondMax);
        }

        public static int CompareByMagnitudeDescending(int[] a, int[] b)
        {
            int firstMax = GetMaxMagnitude(a);
            int secondMax = GetMaxMagnitude(b);
            return secondMax.CompareTo(firstMax);
        }

        public static int CompareBySumAscending(int[] a, int[] b)
        {
            int firstSum = GetSumOfElements(a);
            int secondSum = GetSumOfElements(b);
            return firstSum.CompareTo(secondSum);
        }

        public static int CompareBySumDescending(int[] a, int[] b)
        {
            int firstSum = GetSumOfElements(a);
            int secondSum = GetSumOfElements(b);
            return secondSum.CompareTo(firstSum);
        }

        public static int CompareByLengthAscending(int[] a, int[] b)
        {
            int firstLength = a == null ? 0 : a.Length;
            int secondLength = b == null ? 0 : b.Length;
            return firstLength.CompareTo(secondLength);
        }

        public static int CompareByLengthDescending(int[] a, int[] b)
        {
            int firstLength = a == null ? 0 : a.Length;
            int secondLength = b == null ? 0 : b.Length;
            return secondLength.CompareTo(firstLength);
        }

        private static int GetSumOfElements(int[] array)
        {
            int sum = 0;
            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }
            }
            return sum;
        }

        private static int GetMaxMagnitude(int[] array)
        {
            int max = 0;
            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (Math.Abs(array[i]) > max)
                    {
                        max = Math.Abs(array[i]);
                    }
                }
            }
            return max;
        }
    }
}
