using System;
using System.Collections.Generic;
using System.Text;
using static LexiconA4.Exceptions;

namespace LexiconA4
{
    public class Tools
    {
        public static string SafeString(string name)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                return name;
            }
            else
            {
                throw new ArgumentIsNullOrWhiteSpaceException(nameof(name));
            }
        }

    }
}
