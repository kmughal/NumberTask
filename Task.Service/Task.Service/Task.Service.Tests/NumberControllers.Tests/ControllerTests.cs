namespace Task.Service.Tests.NumberControllers.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Controllers;
    using System.Web.Http.Results;
    using Moq;
    using Domain;
    using System.Collections.Generic;

    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        [TestCategory("OverAll Application Test")]
        public void AddNumbersShouldAddNumbersAndLogInformation()
        {
            // arrange
            string number1 = "5", number2 = "6";                
            string sum = (int.Parse(number1) + int.Parse(number2)).ToString();
            string logMessage = $"Timestamp= {DateTime.Now.ToString()},number1={number1} , number2={number2} , result={sum}";

            var mock_Logger =new Mock<ILogService>();
            mock_Logger.Setup(it => it.Log(It.IsAny<string>())).Verifiable();
            mock_Logger.Setup(it => it.GetAllLogs()).Returns(() => new[] { logMessage });

            var mock_NumberCalculator = new Mock<INumberCalculator>();
            mock_NumberCalculator.Setup(it => it.AddBigNumbers(number1, number2)).Returns(() => sum );

            var controller = new NumbersController(mock_Logger.Object, mock_NumberCalculator.Object);

            // act
            var result = (controller.Add(number1, number2) as OkNegotiatedContentResult<string>);
            var logResult = (controller.GetAllLogs() as OkNegotiatedContentResult<IList<string>>);

            // assert
            Assert.AreEqual(result.Content, sum);
            Assert.AreEqual(logResult.Content.Count, 1);
            Assert.AreEqual(logResult.Content[0], logMessage);
        }
    }
}
