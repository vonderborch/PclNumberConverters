using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PclNumberConverters.Math
{
    internal static class PclMath
    {
        internal static decimal Power(decimal baseNumber, decimal exponent)
        {
            if (exponent == 0) return 1;
            var isNegative = exponent < 0;
            exponent = isNegative ? -exponent : exponent;
            var sum = baseNumber;
            for (var i = 1; i < exponent; i++)
                sum *= baseNumber;

            return isNegative ? 1m / sum : sum;
        }
    }
}
