using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TasksLibrary
{
    public delegate int AlgorithmMethod(int[] array);

    public abstract class GreatestCommonDivisor
    {
        /// <summary>
        /// Finds the gcd of two or more numbers and measures the search time.
        /// </summary>
        /// <param name="method">Find gcd algorithm.</param>
        /// <param name="workTimeMilliseconds">Spended time.</param>
        /// <param name="num1">First integer.</param>
        /// <param name="num2">Second integer.</param>
        /// <param name="numbers">Additional integers.</param>
        /// <returns></returns>
        protected static int GetGCD(AlgorithmMethod method, out double workTimeMilliseconds, int num1, int num2, params int[] numbers)
        {
            var totalNumbers = new int[2 + numbers.Length];
            totalNumbers[0] = num1;
            totalNumbers[1] = num2;

            for (int i = 0; i < numbers.Length; i++)
                totalNumbers[2 + i] = numbers[i];

            totalNumbers = RemoveZeros(totalNumbers);

            var watcher = new Stopwatch();
            var gcd = 0;

            watcher.Start();

            if (totalNumbers.Length == 0)
                gcd = 0;
            else
                gcd = Math.Abs(method(totalNumbers));

            watcher.Stop();
            workTimeMilliseconds = watcher.ElapsedMilliseconds;

            return gcd;
        }

        protected static int[] RemoveZeros(int[] arr) => arr.Where(x => x != 0).ToArray();

        protected static void Divide(ref int num1, ref int num2)
        {
            var t = num2;
            num2 = num1 % num2;
            num1 = t;
        }
    }

    public class EuclidGreatestCommonDivisor : GreatestCommonDivisor
    {
        public static int GetGCD(out double workTimeMilliseconds, int num1, int num2, params int[] numbers)
        {
            workTimeMilliseconds = 0;
            return GetGCD(FindGCDByEuclid, out workTimeMilliseconds, num1, num2, numbers);
        }

        /// <summary>
        /// Method which find greatest common divisor of two or more integers with Euclid algorithm.
        /// </summary>
        /// <param name="numbers">Input integers.</param>
        /// <returns>Greatest common divisor.</returns>
        private static int FindGCDByEuclid(int[] numbers)
        {
            if (numbers.Length == 1)
                return numbers[0];

            for (int i = 0; ; i = (++i) % (numbers.Length - 1))
            {
                Divide(ref numbers[i], ref numbers[i + 1]);
                if (numbers[i] == 0 || numbers[i + 1] == 0)
                    break;
            }

            numbers = RemoveZeros(numbers);

            return FindGCDByEuclid(numbers);
        }
    }

    public class StainGreatestCommonDivisor : GreatestCommonDivisor
    {
        public static int GetGCD(out double workTimeMilliseconds, int num1, int num2, params int[] numbers)
        {
            workTimeMilliseconds = 0;
            return GetGCD(CallGCD, out workTimeMilliseconds, num1, num2, numbers);
        }

        /// <summary>
        /// Pairwise causes a search for gcd.
        /// </summary>
        /// <param name="numbers">Integers.</param>
        /// <returns>greatest common divisor</returns>
        public static int CallGCD(params int[] numbers)
        {
            var stack = new Stack<long>(numbers.Select(x => (long)x));

            while (stack.Count() > 1)
            {
                var gcd2 = FindGCDByStain(Math.Abs(stack.Pop()), Math.Abs(stack.Pop()));
                stack.Push(gcd2);
            }

            return (int)stack.Pop();
        }

        /// <summary>
        /// Method which find greatest common divisor of two integers with Stain algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>Greatest common divisor.</returns>
        public static long FindGCDByStain(long a, long b)
        {
            if (a == b)
                return a;
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                    return FindGCDByStain(a >> 1, b);
                else
                    return FindGCDByStain(a >> 1, b >> 1) << 1;
            }
            if ((~b & 1) != 0)
                return FindGCDByStain(a, b >> 1);
            if (a > b)
                return FindGCDByStain((a - b) >> 1, b);
            return FindGCDByStain((b - a) >> 1, a);
        }
    }
}
