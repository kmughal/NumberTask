namespace Task.Domain
{
    using System;
    public class DecimalNumberNotAllowedException : Exception
    {
        public DecimalNumberNotAllowedException(string message) : base(message)
        {

        }
    }

    public class InvalidNumberException : Exception
    {
        public InvalidNumberException(string message) : base(message) { }
    }
}