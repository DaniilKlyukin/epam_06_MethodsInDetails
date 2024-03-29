﻿using TasksLibrary;
using NUnit.Framework;
using MSUnitTest = Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsInDetailsTests
{
    [TestFixture]
    [MSUnitTest.TestClass]
    public class DoubleExtensionsTests
    {
        [TestCase(263.3, ExpectedResult = "0100000001110000011101001100110011001100110011001100110011001101")]
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(1, ExpectedResult = "0011111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(185.4375, ExpectedResult = "0100000001100111001011100000000000000000000000000000000000000000")]
        [TestCase(0.125, ExpectedResult = "0011111111000000000000000000000000000000000000000000000000000000")]
        public string CheckToIEEE754(double number)
        {
            return number.ToIEEE754();
        }

        [Test, TestCaseSource("ToIEEE754")]
        public void CheckToIEEE754Boundary(double number, string expected)
        {
            var actual = number.ToIEEE754();
            MSUnitTest.Assert.AreEqual(expected, actual);
        }

        static object[] ToIEEE754 =
        {
            new object[] { double.MinValue,"1111111111101111111111111111111111111111111111111111111111111111" },
            new object[] { double.MaxValue, "0111111111101111111111111111111111111111111111111111111111111111"},
            new object[] { 4294967295.0, "0100000111101111111111111111111111111111111000000000000000000000" }
        };
    }
}
