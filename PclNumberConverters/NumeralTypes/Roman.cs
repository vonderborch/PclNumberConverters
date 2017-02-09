// ***********************************************************************
// Assembly         : PclNumberConverters
// Component        : Roman.cs
// Author           : vonderborch
// Created          : 02-08-2017
// 
// Version          : 1.0.0
// Last Modified By : vonderborch
// Last Modified On : 02-08-2017
// ***********************************************************************
// <copyright file="Roman.cs">
//		Copyright ©  2017
// </copyright>
// <summary>
//      Converts Arabic numbers to Roman numbers.
// </summary>
//
// Changelog: 
//            - 1.0.0 (02-08-2017) - Initial version created.
// ***********************************************************************
using System.Collections.Generic;
using System.Text;

namespace PclNumberConverters.NumeralTypes
{
    public static class Roman
    {
        #region Public Methods

        /// <summary>
        /// Doubles from roman numerals.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.Double.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        public static double DoubleFromRomanNumerals(string number)
        {
            double result = 0;

            var numerals = GetRomanNumeralSymbolsAndValues();

            foreach (var set in numerals)
            {
                var output = InternalDoubleConvertFrom(ref number, set.Key, set.Value);
                do
                {
                    result += output;
                    if (string.IsNullOrEmpty(number)) break;
                    output = InternalDoubleConvertFrom(ref number, set.Key, set.Value);
                } while (output != 0);
            }

            return result;
        }

        /// <summary>
        /// Floats from roman numerals.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.Single.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        public static float FloatFromRomanNumerals(string number)
        {
            float result = 0;

            var numerals = GetRomanNumeralSymbolsAndValues();

            foreach (var set in numerals)
            {
                var output = InternalFloatConvertFrom(ref number, set.Key, set.Value);
                do
                {
                    result += output;
                    if (string.IsNullOrEmpty(number)) break;
                    output = InternalFloatConvertFrom(ref number, set.Key, set.Value);
                } while (output != 0);
            }

            return result;
        }

        /// <summary>
        /// Gets the roman numeral symbols and values.
        /// </summary>
        /// <returns>List&lt;KeyValuePair&lt;System.String, System.Int32&gt;&gt;.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        public static List<KeyValuePair<string, int>> GetRomanNumeralSymbolsAndValues()
        {
            return new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("M", 1000),
                new KeyValuePair<string, int>("CM", 900),
                new KeyValuePair<string, int>("D", 500),
                new KeyValuePair<string, int>("CD", 400),
                new KeyValuePair<string, int>("C", 100),
                new KeyValuePair<string, int>("XC", 90),
                new KeyValuePair<string, int>("L", 50),
                new KeyValuePair<string, int>("XL", 40),
                new KeyValuePair<string, int>("X", 10),
                new KeyValuePair<string, int>("IX", 9),
                new KeyValuePair<string, int>("V", 5),
                new KeyValuePair<string, int>("IV", 4),
                new KeyValuePair<string, int>("I", 1),
            };
        }

        /// <summary>
        /// Ints from roman numerals.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.Int32.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        public static int IntFromRomanNumerals(string number)
        {
            var result = 0;

            var numerals = GetRomanNumeralSymbolsAndValues();

            foreach (var set in numerals)
            {
                var output = InternalIntConvertFrom(ref number, set.Key, set.Value);
                do
                {
                    result += output;
                    if (string.IsNullOrEmpty(number)) break;
                    output = InternalIntConvertFrom(ref number, set.Key, set.Value);
                } while (output != 0);
            }

            return result;
        }

        /// <summary>
        /// Longs from roman numerals.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.Int64.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        public static long LongFromRomanNumerals(string number)
        {
            long result = 0;

            var numerals = GetRomanNumeralSymbolsAndValues();

            foreach (var set in numerals)
            {
                var output = InternalLongConvertFrom(ref number, set.Key, set.Value);
                do
                {
                    result += output;
                    if (string.IsNullOrEmpty(number)) break;
                    output = InternalLongConvertFrom(ref number, set.Key, set.Value);
                } while (output != 0);
            }

            return result;
        }

        /// <summary>
        /// To the roman numerals.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        public static string ToRomanNumerals(int number)
        {
            if (number < 1) return string.Empty;

            var result = new StringBuilder();

            var numerals = GetRomanNumeralSymbolsAndValues();
            foreach (var set in numerals)
                result.Append(InternalConvertTo(ref number, set.Key, set.Value));

            return result.ToString();
        }

        /// <summary>
        /// To the roman numerals.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        public static string ToRomanNumerals(long number)
        {
            if (number < 1) return string.Empty;

            var result = new StringBuilder();

            var numerals = GetRomanNumeralSymbolsAndValues();
            foreach (var set in numerals)
                result.Append(InternalConvertTo(ref number, set.Key, set.Value));

            return result.ToString();
        }

        /// <summary>
        /// To the roman numerals.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        public static string ToRomanNumerals(float number)
        {
            if (number < 1) return string.Empty;

            var result = new StringBuilder();

            var numerals = GetRomanNumeralSymbolsAndValues();
            foreach (var set in numerals)
                result.Append(InternalConvertTo(ref number, set.Key, set.Value));

            return result.ToString();
        }

        /// <summary>
        /// To the roman numerals.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        public static string ToRomanNumerals(double number)
        {
            if (number < 1) return string.Empty;

            var result = new StringBuilder();

            var numerals = GetRomanNumeralSymbolsAndValues();
            foreach (var set in numerals)
                result.Append(InternalConvertTo(ref number, set.Key, set.Value));

            return result.ToString();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Internals the convert to.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <param name="symbol">The symbol.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        private static string InternalConvertTo(ref int num, string symbol, int value)
        {
            StringBuilder str = new StringBuilder();
            while (num >= value)
            {
                num -= value;
                str.Append(symbol);
            }

            return str.ToString();
        }

        /// <summary>
        /// Internals the convert to.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <param name="symbol">The symbol.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        private static string InternalConvertTo(ref long num, string symbol, long value)
        {
            StringBuilder str = new StringBuilder();
            while (num >= value)
            {
                num -= value;
                str.Append(symbol);
            }

            return str.ToString();
        }

        /// <summary>
        /// Internals the convert to.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <param name="symbol">The symbol.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        private static string InternalConvertTo(ref float num, string symbol, float value)
        {
            StringBuilder str = new StringBuilder();
            while (num >= value)
            {
                num -= value;
                str.Append(symbol);
            }

            return str.ToString();
        }

        /// <summary>
        /// Internals the convert to.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <param name="symbol">The symbol.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        private static string InternalConvertTo(ref double num, string symbol, double value)
        {
            StringBuilder str = new StringBuilder();
            while (num >= value)
            {
                num -= value;
                str.Append(symbol);
            }

            return str.ToString();
        }

        /// <summary>
        /// Internals the double convert from.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <param name="symbol">The symbol.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Double.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        private static double InternalDoubleConvertFrom(ref string num, string symbol, int value)
        {
            if (num.Length < symbol.Length) return 0;

            if (num.Substring(0, symbol.Length) == symbol)
            {
                num = num.Substring(symbol.Length);
                return value;
            }

            return 0;
        }

        /// <summary>
        /// Internals the float convert from.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <param name="symbol">The symbol.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Single.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        private static float InternalFloatConvertFrom(ref string num, string symbol, int value)
        {
            if (num.Length < symbol.Length) return 0;

            if (num.Substring(0, symbol.Length) == symbol)
            {
                num = num.Substring(symbol.Length);
                return value;
            }

            return 0;
        }

        /// <summary>
        /// Internals the int convert from.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <param name="symbol">The symbol.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        private static int InternalIntConvertFrom(ref string num, string symbol, int value)
        {
            if (num.Length < symbol.Length) return 0;

            if (num.Substring(0, symbol.Length) == symbol)
            {
                num = num.Substring(symbol.Length);
                return value;
            }

            return 0;
        }

        /// <summary>
        /// Internals the long convert from.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <param name="symbol">The symbol.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Int64.</returns>
        ///  Changelog:
        ///             - 1.0.0 (02-08-2017) - Initial version.
        private static long InternalLongConvertFrom(ref string num, string symbol, int value)
        {
            if (num.Length < symbol.Length) return 0;

            if (num.Substring(0, symbol.Length) == symbol)
            {
                num = num.Substring(symbol.Length);
                return value;
            }

            return 0;
        }

        #endregion Private Methods
    }
}
