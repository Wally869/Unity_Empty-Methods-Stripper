using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NoEmptyMethods
{
    public static class RegExHandler
    {

        public static string MatchAndDelete(string inputString)
        {
            // gonna apply to all empty functions
            //Regex rx = new Regex(@"private void (?<word>\w+)\(\)*\s*\{*\s*\n*\}", RegexOptions.Compiled | RegexOptions.IgnoreCase)
            string outputString = Regex.Replace(inputString, @"private void (?<word>\w+)\(\)*\s*\{*\s*\n*\}", "");
            return Regex.Replace(outputString, @"void (?<word>\w+)\(\)*\s*\{*\s*\n*\}", "");
        }

    }
}
