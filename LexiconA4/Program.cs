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
