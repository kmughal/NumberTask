namespace Task.Domain
{
    using System.Numerics;
    using static HelperFunctions;

    public class BigNumberParser : IBigNumberParser
    {
        public dynamic Parse(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                ThrowNullArugmentException(string.Format(ErrorMessages.EMPTY_VALUE, nameof(number)));
            }

            if (number.Contains("."))
            {
                ThrowDecimalNumberNotAllowedException(string.Format(ErrorMessages.DECIMAL_NOT_ALLOWED, number));
            }

            if (!number.isValidNumber())
            {
                ThrowNotAValidNumberException(ErrorMessages.NOT_VALID_NUMBER);
            }

            var result = new BigInteger();
            if (BigInteger.TryParse(number, out result))
            {
                return result;
            }
            else
            {
                ThrowDecimalNumberNotAllowedException(string.Format(ErrorMessages.PARSE_ERROR, number));
            }
            return null;
        }
    }
}
