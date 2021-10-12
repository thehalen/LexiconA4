using System;

namespace LexiconA4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    /// <summary>
    /// Because we don't want any string.WS or NULL values in our Garden of Eden
    /// </summary>
    public class ArgumentIsNullOrWhiteSpaceException : Exception
    {
        public ArgumentIsNullOrWhiteSpaceException()
        {
        }

        public ArgumentIsNullOrWhiteSpaceException(string message)
            : base(message)
        {
        }

        public ArgumentIsNullOrWhiteSpaceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
