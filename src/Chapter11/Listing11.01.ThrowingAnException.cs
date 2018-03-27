﻿namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter10.Listing10_01
{
    using System;

    public sealed class TextNumberParser
    {
        public static int Parse(string textDigit)
        {
            string[] digitTexts = 
                { "zero", "one", "two", "three", "four", 
                  "five", "six", "seven", "eight", "nine" };

#if !PRECSHARP7
            int result = Array.IndexOf(
                digitTexts,
                // Leveraging C# 2.0’s null coelesce operator
                (textDigit ??
                  // Leveraging C# 7.0’s throw expression
                  throw new ArgumentNullException(nameof(textDigit))
                ).ToLower());

#else
            if(textDigit == null) throw new ArgumentNullException(nameof(textDigit))
            int result = Array.IndexOf(
                digitTexts, textDigit?.ToLower());
#endif

            if (result < 0)
            {
#if !PRECSHARP6
                throw new ArgumentException(
                    "The argument did not represent a digit", nameof(textDigit));
#else
                throw new ArgumentException(
                    "The argument did not represent a digit",
                    "textDigit");
#endif
            }

            return result;
        }
    }
}