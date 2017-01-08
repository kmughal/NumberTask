namespace Task.Domain
{
    using System;
    public class PathNotFoundException : Exception
    {
        public PathNotFoundException(string message) : base(message)
        {

        }
    }
}
