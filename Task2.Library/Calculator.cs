using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Library
{
    public static class Calculator
    {
        /// <summary>
        /// Calculates a nth root of a number
        /// </summary>
        /// <param name="x">Radicand</param>
        /// <param name="degree">Degree of the root</param>
        /// <param name="precision">Precision of the result</param>
        /// <returns>Root of the given degree</returns>
        /// <exception cref="ArgumentException">Thrown when <see cref="degree"/> is non-positive number, or <see cref="x"/> is negative and <see cref="degree"/> is an even number.</exception>
        public static double NewtonRoot(double x, int degree, double precision)
        {
            if (degree <= 0)
            {
                throw new ArgumentException("Can't calculate root of non-positive degree.", "degree");
            }
            if (x < 0 && degree % 2 == 0)
            {
                throw new ArgumentException("Can't calculate an even degree root of a negative number.", "degree");
            }
            precision = Math.Abs(precision);
            double delta, result = 1;
            do
            {
                delta = (1d / degree) * (x / Math.Pow(result, degree - 1) - result);
                result += delta;
            }
            while (Math.Abs(delta) > precision);
            return result;
        }

        /// <summary>
        /// Calculates Greatest Common Devisor of numbers using Euclidian Algorithm.
        /// </summary>
        /// <param name="timeTaken">Stores time taken by calculation.</param>
        /// <param name="numbers">Natural numbers.</param>
        /// <returns>Greatest Common Devisor of <see cref="numbers"/>.</returns>
        public static int EuclideanGCD(out long timeTaken, params int[] numbers)
        {
            return TimedEvaluation(out timeTaken, () => EuclideanGCD(numbers));
        }

        /// <summary>
        /// Calculates Greatest Common Devisor of numbers using Euclidian Algorithm.
        /// </summary>
        /// <param name="numbers">Natural numbers.</param>
        /// <returns>Greatest Common Devisor of <see cref="numbers"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when less than two <see cref="numbers"/> provided.</exception>
        public static int EuclideanGCD(params int[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("Can't calculate GCD of less than two numbers.");
            }
            return ChainedEvaluation(numbers, EuclideanGCD);
        }

        public static int EuclideanGCD(out long timeTaken, int a, int b, int c)
        {
            return TimedEvaluation(out timeTaken, () => EuclideanGCD(a, b, c));
        }

        public static int EuclideanGCD(int a, int b, int c)
        {
            return EuclideanGCD(EuclideanGCD(a, b), c);
        }

        public static int EuclideanGCD(out long timeTaken, int a, int b)
        {
            return TimedEvaluation(out timeTaken, () => EuclideanGCD(a, b));
        }

        public static int EuclideanGCD(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                throw new ArgumentException("Can't calculate GCD of negative numbers.");
            }
            while (b > 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Calculates Greatest Common Devisor of numbers using Binary GCD Algorithm.
        /// </summary>
        /// <param name="timeTaken">Stores time taken by calculation.</param>
        /// <param name="numbers">Natural numbers.</param>
        /// <returns>Greatest Common Devisor of <see cref="numbers"/>.</returns>
        public static int BinaryGCD(out long timeTaken, params int[] numbers)
        {
            return TimedEvaluation(out timeTaken, () => BinaryGCD(numbers));
        }

        /// <summary>
        /// Calculates Greatest Common Devisor of numbers using Binary GCD Algorithm.
        /// </summary>
        /// <param name="numbers">Natural numbers.</param>
        /// <returns>Greatest Common Devisor of <see cref="numbers"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when less than two <see cref="numbers"/> provided.</exception>
        public static int BinaryGCD(params int[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("Can't calculate GCD of less than two numbers.");
            }
            return ChainedEvaluation(numbers, EuclideanGCD);
        }

        public static int BinaryGCD(out long timeTaken, int a, int b, int c)
        {
            return TimedEvaluation(out timeTaken, () => BinaryGCD(a, b, c));
        }

        public static int BinaryGCD(int a, int b, int c)
        {
            return BinaryGCD(BinaryGCD(a, b), c);
        }

        public static int BinaryGCD(out long timeTaken, int a, int b)
        {
            return TimedEvaluation(out timeTaken, () => BinaryGCD(a, b));
        }

        public static int BinaryGCD(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                throw new ArgumentException("Can't calculate GCD of negative numbers.");
            }

            int shift;
            if (a == 0) return b;
            if (b == 0) return a;

            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
                a >>= 1;

            do
            {
                while ((b & 1) == 0)
                    b >>= 1;
                if (a > b)
                {
                    int t = b; b = a; a = t;
                }
                b = b - a;
            } while (b != 0);

            return a << shift;
        }

        private static int TimedEvaluation(out long timeTaken, Func<int> method)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int result = method();
            timeTaken = stopwatch.ElapsedTicks;
            return result;
        }

        private static int ChainedEvaluation(int[] numbers, Func<int, int, int> method)
        {
            int result = method(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                result = method(result, numbers[i]);
            }
            return result;
        }
    }
}
