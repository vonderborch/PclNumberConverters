using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PclNumberConverters.Conversions.Time
{
    public static class Time
    {
        public static decimal ConvertTime(decimal value, SiTime fromUnit, SiTime toUnit)
        {
            return TimeSI.Convert(value, fromUnit, toUnit);
        }
        public static decimal ConvertTime(decimal value, UtcTime fromUnit, UtcTime toUnit)
        {
            return TimeUtc.Convert(value, fromUnit, toUnit);
        }

        public static decimal ConvertTime(decimal value, SiTime fromUnit, UtcTime toUnit)
        {
            value = CommonSi(value, fromUnit);
            return TimeUtc.Convert(value, CommonUtcUnit, toUnit);
        }

        public static decimal ConvertTime(decimal value, UtcTime fromUnit, SiTime toUnit)
        {
            value = CommonUtc(value, fromUnit);
            return TimeSI.Convert(value, CommonSiUnit, toUnit);
        }

        internal static decimal CommonSi(decimal number, SiTime unit)
        {
            return TimeSI.Convert(number, unit, SiTime.Second);
        }

        internal static SiTime CommonSiUnit
        {
            get { return SiTime.Second; }
        }

        internal static decimal CommonUtc(decimal number, UtcTime unit)
        {
            return TimeUtc.Convert(number, unit, UtcTime.Second);
        }

        internal static UtcTime CommonUtcUnit
        {
            get { return UtcTime.Second; }
        }
    }
}
