using PclNumberConverters.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PclNumberConverters.Conversions.Time
{
    public enum UtcTime
    {
        Nanosecond,
        Microsecond,
        Millisecond,
        Jiffy,
        Second,
        Minute,
        Hour,
        Day,
        Week,
        Fortnight,
        MonthCommon,
        MonthExtended,
        MonthFebruary,
        MonthFebruaryLeapYear,
        Quarter,
        Season,
        Year,
        YearCommon,
        YearLeap,
        Biennium,
        Triennium,
        Olympiad,
        Lustrum,
        Decade,
        Jubilee,
        Century,
        Millennium
    }

    public static class TimeUtc
    {
        public static Dictionary<UtcTime, string> Postfixes = new Dictionary<UtcTime, string>()
        {
            { UtcTime.Nanosecond, "ns" },
            { UtcTime.Microsecond, "ys" },
            { UtcTime.Millisecond, "ms" },
            { UtcTime.Jiffy, "j" },
            { UtcTime.Second, "s" },
            { UtcTime.Minute, "m" },
            { UtcTime.Hour, "H" },
            { UtcTime.Day, "D" },
            { UtcTime.Week, "W" },
            { UtcTime.Fortnight, "Fn" },
            { UtcTime.MonthCommon, "M" },
            { UtcTime.MonthExtended, "M" },
            { UtcTime.MonthFebruary, "M" },
            { UtcTime.MonthFebruaryLeapYear, "M" },
            { UtcTime.Quarter, "Q" },
            { UtcTime.Season, "S" },
            { UtcTime.Year, "Y" },
            { UtcTime.YearCommon, "Y" },
            { UtcTime.YearLeap, "Y" },
            { UtcTime.Biennium, "B" },
            { UtcTime.Triennium, "T" },
            { UtcTime.Olympiad, "O" },
            { UtcTime.Lustrum, "L" },
            { UtcTime.Decade, "De" },
            { UtcTime.Jubilee, "J" },
            { UtcTime.Century, "C" },
            { UtcTime.Millennium, "Mi" },
        };

        public static Dictionary<UtcTime, decimal> UnitConversions = new Dictionary<UtcTime, decimal>()
        {
            { UtcTime.Nanosecond, 1 / (decimal)1000000000 },
            { UtcTime.Microsecond, 1 / (decimal)1000000 },
            { UtcTime.Millisecond, 1 / (decimal)1000 },
            { UtcTime.Jiffy, 1 / (decimal)100 },
            { UtcTime.Second, 1 },
            { UtcTime.Minute, 60 },
            { UtcTime.Hour, 3600 },
            { UtcTime.Day, 86400 },
            { UtcTime.Week, 604800 },
            { UtcTime.Fortnight, 1209600 },
            { UtcTime.MonthCommon, 2592000 },
            { UtcTime.MonthExtended, 2678400 },
            { UtcTime.MonthFebruary, 2419200 },
            { UtcTime.MonthFebruaryLeapYear, 2505600 },
            { UtcTime.Quarter, 7776000 },
            { UtcTime.Season, 7862400 },
            { UtcTime.Year, 31104000 },
            { UtcTime.YearCommon, 31557600 },
            { UtcTime.YearLeap, 31644000 },
            { UtcTime.Biennium, 63115200 },
            { UtcTime.Triennium, 94672800 },
            { UtcTime.Olympiad, 126316800 },
            { UtcTime.Lustrum, 157788000 },
            { UtcTime.Decade, 315576000 },
            { UtcTime.Jubilee, 1577880000 },
            { UtcTime.Century, 3155760000 },
            { UtcTime.Millennium, 31557600000 },
        };

        public static string GetUnitShortPostfix(UtcTime timeUnit)
        {
            var units = Postfixes;

            string output;
            if (units.TryGetValue(timeUnit, out output))
                return output;
            return string.Empty;
        }

        public static string ConvertToStringShortPostfix(decimal value, UtcTime timeUnit)
        {
            var units = Postfixes;

            string output;
            if (units.TryGetValue(timeUnit, out output))
                return $"{value}{output}";
            return string.Empty;
        }

        public static string ConvertToStringFullPostfix(decimal value, UtcTime timeUnit)
        {
            return $"{value} {timeUnit.ToString().Replace($"{typeof(UtcTime).ToString()}.", "")}";
        }

        public static UtcTime? GetTimeDefinitionFromUnitName(string unit, bool ignoreCapitalization = false)
        {
            var UtcTimeStr = $"{typeof(UtcTime).ToString()}.";
            Dictionary<string, UtcTime> units = new Dictionary<string, UtcTime>();
            foreach (var tUnit in Postfixes)
                units.Add(tUnit.Key.ToString().Replace(UtcTimeStr, ""), tUnit.Key);

            if (!units.ContainsKey(unit)) return null;

            var comp = ignoreCapitalization
                            ? StringComparison.OrdinalIgnoreCase
                            : StringComparison.Ordinal;
            foreach (var tUnit in units)
                if (string.Equals(tUnit.Key, unit, comp)) return tUnit.Value;

            return null;
        }

        public static UtcTime? GetTimeDefinitionFromUnitPostfix(string unit, bool ignoreCapitalization = false)
        {
            if (!Postfixes.ContainsValue(unit)) return null;

            var comp = ignoreCapitalization
                            ? StringComparison.OrdinalIgnoreCase
                            : StringComparison.Ordinal;
            foreach (var tUnit in Postfixes)
                if (string.Equals(tUnit.Value, unit, comp)) return tUnit.Key;

            return null;
        }

        public static decimal Convert(decimal value, UtcTime fromUnit, UtcTime toUnit)
        {
            var from = UnitConversions[fromUnit];
            var to = UnitConversions[toUnit];

            // convert the from unit to the base unit...
            if (from > 1)
                value /= from;
            else
                value *= from;

            // convert to the final unit and return
            if (to > 1)
                value /= to;
            else
                value *= to;

            return value;
        }
    }
}
