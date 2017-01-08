namespace Task.Service.Controllers
{
    using System;
    using System.Web.Http;
    using Domain;

    public class NumbersController : ApiController
    {
        readonly ILogService logService;
        readonly INumberCalculator numberCalculator;

        public NumbersController(ILogService logService, INumberCalculator numberCalculator)
        {
            this.logService = logService;
            this.numberCalculator = numberCalculator;
        }

        [HttpGet]
        [Route("AddNumbers/{number1}/{number2}")]
        public IHttpActionResult Add(string number1, string number2)
        {
            var result = numberCalculator.AddBigNumbers(number1, number2);
            logService.Log($"Timestamp= {DateTime.Now.ToString()},number1={number1} , number2={number2} , result={result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllLogs")]
        public IHttpActionResult GetAllLogs() => Ok(this.logService.GetAllLogs());

    }
}