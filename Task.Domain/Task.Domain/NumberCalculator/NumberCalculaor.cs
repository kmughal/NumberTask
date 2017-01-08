namespace Task.Domain
{
    public class NumberCalculaor : INumberCalculator
    {
        readonly IBigNumberParser numberParser;
        public NumberCalculaor(IBigNumberParser parser)
        {
            numberParser = parser;
        }

        public string AddBigNumbers(string number1, string number2) => (numberParser.Parse(number1) + numberParser.Parse(number2)).ToString();

    }
}