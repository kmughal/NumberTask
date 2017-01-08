namespace Task.Service.Tests.NumberCalculatorTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Domain;
    using System.Numerics;

    [TestClass]
    public class NumberCalculatorTests
    {
        [TestMethod]
        public void WhenTwoLargeNumbersArePassedThenNumbersMustBeAdded()
        {
            // arrange
            var parser = new BigNumberParser();            
            var calculator = new NumberCalculaor(parser);
            
            // act
            var expected = BigInteger.Parse("222222222222222222");
            var actual = calculator.AddBigNumbers("111111111111111111", "111111111111111111");

            // assert
            Assert.AreEqual(expected.ToString().Equals(actual), true);

        }
    }
}
