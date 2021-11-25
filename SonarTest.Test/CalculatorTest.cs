using System;
using Xunit;

namespace SonarTest.Test
{

    public class CalculatorTest
    {
        [Fact]
        public void SubtractTest()
        {
            Calculator mathematics = new Calculator();

            int number1 = 10;
            int number2 = 20;
            int expected = -10;
            int result = mathematics.Subtract(number1, number2);
            Assert.Equal(expected, result);
        }
    }
}
