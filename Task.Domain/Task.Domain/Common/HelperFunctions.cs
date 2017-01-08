namespace Task.Domain
{
    using System;

    public static class HelperFunctions
    {
        public static PathNotFoundException ThrowFileNotFoundException(string message)
        {
            throw new PathNotFoundException(message);
        }

        public static ArgumentNullException ThrowNullArugmentException(string message)
        {
            throw new ArgumentNullException(message);
        }

        public static DecimalNumberNotAllowedException ThrowDecimalNumberNotAllowedException(string message)
        {
            throw new DecimalNumberNotAllowedException(message);
        }

        public static ParseException ThrowNumberParseException(String message)
        {
            throw new ParseException(message);
        }

        public static InvalidNumberException ThrowNotAValidNumberException(string message)
        {
            throw new InvalidNumberException(message);
        }

        public static bool isValidNumber(this string value) => System.Text.RegularExpressions.Regex.IsMatch(value, "^[0-9]+$");
    }
}
