// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Linq;

namespace TDDKata
{
    internal class StringCalc
    {
        private const int ERROR = -1;
        internal int Sum(string input)
        {
            if (input == null)
                return ERROR;
            if (input.Equals(string.Empty))
                return 0;

            var arguments = SplitString(input);
            foreach (string argument in arguments)
            {
                if (!int.TryParse(argument, out int intArgument) || intArgument < 0)
                    return ERROR;
            }
            var intArguments = arguments.Select(a => int.Parse(a));
            return intArguments.Sum();
        }

        private string[] SplitString(string input)
        {
            string[] delimeters = new string[] { ",", "\n" };
            if (input.StartsWith("//") && input.Contains("\n"))
            {
                int newLineIdx = input.IndexOf("\n");
                string delimeterFormatPart = input.Substring(0, newLineIdx);
                string delimeter = delimeterFormatPart.Substring(2);
                delimeters = new string[] { delimeter };
                input = input.Substring(newLineIdx + 1, input.Length - newLineIdx - 1);
            }

            return input.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}