using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
using System;
using System.Text;

namespace StringCalculatorTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Test_EmptyStringReturnsZero()
        {
            int result = Calculator.Add("");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_OneNumberReturnsSum()
        {
            int result = Calculator.Add("1");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_TwoNumbersReturnSum()
        {
            int result = Calculator.Add("1,2");
            Assert.AreEqual(3, result);
        }
        
        [TestMethod]
        public void Test_UnknownAmountOfNumbersSum()
        {
            Random random = new Random();
            int length = random.Next(1, 10);
            int expectedValue = 0;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int tempNumber = random.Next(0, 100);
                expectedValue += tempNumber;
                stringBuilder.Append($"{tempNumber},");
            }
            int result = Calculator.Add(stringBuilder.ToString().Substring(0, stringBuilder.Length - 1));
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Test_NumbersWithNewLine()
        {
            int result = Calculator.Add("1\n2,3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Test_WithDelimiters()
        {
            int result = Calculator.Add("//;\n1;2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_ExpectingExceptionForNegativeNumbers()
        {
            Calculator.Add("-1,-3,1");
        }

        [TestMethod]
        public void Test_IgnoreNumbersGreaterThanAThousand()
        {
            int result = Calculator.Add("2,1000,3,2000");
            Assert.AreEqual(1005, result);
        }

        [TestMethod]
        public void Test_FirstMultiDelimiterTest()
        {
            int result = Calculator.Add("//[***]\n1***2***3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Test_SecondMultiDelimiterTest()
        {
            int result = Calculator.Add("//[*][%]\n1*2%3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Test_DelimitersWithMoreThanOneCharacter()
        {
            int result = Calculator.Add("//[***][%]\n1***2%3");
            Assert.AreEqual(6, result);
        }
    }
}
