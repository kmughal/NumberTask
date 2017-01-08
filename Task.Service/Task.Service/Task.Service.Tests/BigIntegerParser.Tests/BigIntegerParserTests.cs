namespace Task.Service.Tests.BigIntegerParserTests
{
    using System;
    using System.Numerics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Domain;

    [TestClass]
    public class BigIntegerParserTests
    {
        [TestMethod]
        [TestCategory("Expected Exceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenNullValueIsParsedThenItShouldNullException()
        {
            var parser = new BigNumberParser();
            parser.Parse(null);
        }

        [TestMethod]
        [TestCategory("Expected Exceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenEmptyValueIsParsedThenItShouldNullException()
        {
            var parser = new BigNumberParser();
            parser.Parse(string.Empty);
        }

        [TestMethod]
        [TestCategory("Expected Exceptions")]
        [ExpectedException(typeof(DecimalNumberNotAllowedException))]
        public void WhenADecimalNumberIsPassedThenDecimalNumberNotAllowedExceptionThrown()
        {
            var parser = new BigNumberParser();
            parser.Parse("5.6666666");
        }

        [TestMethod]
        [TestCategory("Parse Test")]
        public void WhenLargeIntegerIsPassedThenItShouldConvertIntoBigInteger() {
            var parser = new BigNumberParser();
            var actual = parser.Parse("12345678987655554443322234");
            var expected = BigInteger.Parse("12345678987655554443322234");

            Assert.AreEqual(expected, actual);
        }
    }
}
