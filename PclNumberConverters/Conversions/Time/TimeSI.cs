using PclNumberConverters.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PclNumberConverters.Conversions.Time
{
    public enum SiTime
    {
        PlanckTime = -44,
        Yoctosecond = -24,
        Zeptosecond = -21,
        Attosecond = -18,
        Femtosecond = -15,
        Picosecond = -12,
        Nanosecond = -9,
        Microsecond = -6,
        Millisecond = -3,
        Second = 1,
        Kilosecond = 3,
        Megasecond = 6,
        Gigasecond = 9,
        Terasecond = 12,
        Petasecond = 15,
        Exasecond = 18,
        Zettasecond = 21,
        Yottasecond = 24
    }

    public static class TimeSI
    {
        public static Dictionary<SiTime, string> Postfixes = new Dictionary<SiTime, string>()
        {
            { SiTime.PlanckTime, "tp" },
            { SiTime.Yoctosecond, "ys" },
            { SiTime.Zeptosecond, "zs" },
            { SiTime.Attosecond, "as" },
            { SiTime.Femtosecond, "fs" },
            { SiTime.Picosecond, "ps" },
            { SiTime.Nanosecond, "ns" },
            { SiTime.Microsecond, "us" },
            { SiTime.Millisecond, "ms" },
            { SiTime.Second, "s" },
            { SiTime.Kilosecond, "ks" },
            { SiTime.Megasecond, "Ms" },
            { SiTime.Gigasecond, "Gs" },
            { SiTime.Terasecond, "Ts" },
            { SiTime.Petasecond, "Ps" },
            { SiTime.Exasecond, "Es" },
            { SiTime.Zettasecond, "Zs" },
            { SiTime.Yottasecond, "Ys" },
        };

        public static Dictionary<SiTime, int> UnitConversions = new Dictionary<SiTime, int>()
        {
            { SiTime.PlanckTime, -44 },
            { SiTime.Yoctosecond, -24 },
            { SiTime.Zeptosecond, -21 },
            { SiTime.Attosecond, -18 },
            { SiTime.Femtosecond, -15 },
            { SiTime.Picosecond, -12 },
            { SiTime.Nanosecond, -9 },
            { SiTime.Microsecond, -6 },
            { SiTime.Millisecond, -3 },
            { SiTime.Second, 1 },
            { SiTime.Kilosecond, 3 },
            { SiTime.Megasecond, 6 },
            { SiTime.Gigasecond, 9 },
            { SiTime.Terasecond, 12 },
            { SiTime.Petasecond, 15 },
            { SiTime.Exasecond, 18 },
            { SiTime.Zettasecond, 21 },
            { SiTime.Yottasecond, 24 },
        };

        public static string GetUnitShortPostfix(SiTime timeUnit)
        {
            var units = Postfixes;

            string output;
            if (units.TryGetValue(timeUnit, out output))
                return output;
            return string.Empty;
        }

        public static string ConvertToStringShortPostfix(decimal value, SiTime timeUnit)
        {
            var units = Postfixes;

            string output;
            if (units.TryGetValue(timeUnit, out output))
                return $"{value}{output}";
            return string.Empty;
        }

        public static string ConvertToStringFullPostfix(decimal value, SiTime timeUnit)
        {
            return $"{value} {timeUnit.ToString().Replace($"{typeof(SiTime).ToString()}.", "")}";
        }

        public static SiTime? GetTimeDefinitionFromUnitName(string unit, bool ignoreCapitalization = false)
        {
            var siTimeStr = $"{typeof(SiTime).ToString()}.";
            Dictionary<string, SiTime> units = new Dictionary<string, SiTime>();
            foreach (var tUnit in Postfixes)
                units.Add(tUnit.Key.ToString().Replace(siTimeStr, ""), tUnit.Key);

            if (!units.ContainsKey(unit)) return null;

            var comp = ignoreCapitalization
                            ? StringComparison.OrdinalIgnoreCase
                            : StringComparison.Ordinal;
            foreach (var tUnit in units)
                if (string.Equals(tUnit.Key, unit, comp)) return tUnit.Value;

            return null;
        }

        public static SiTime? GetTimeDefinitionFromUnitPostfix(string unit, bool ignoreCapitalization = false)
        {
            if (!Postfixes.ContainsValue(unit)) return null;

            var comp = ignoreCapitalization
                            ? StringComparison.OrdinalIgnoreCase
                            : StringComparison.Ordinal;
            foreach (var tUnit in Postfixes)
                if (string.Equals(tUnit.Value, unit, comp)) return tUnit.Key;

            return null;
        }

        public static decimal Convert(decimal value, SiTime fromUnit, SiTime toUnit)
        {
            var fromExp = UnitConversions[fromUnit];
            var toExp = UnitConversions[toUnit];

            // convert to the base unit...
            if (fromExp > 0)
                value = PclMath.Power(value, 1m / fromExp);
            else
                value = PclMath.Power(value, 1m / (1m / fromExp));

            // convert to the final unit and return
            value = PclMath.Power(value, toExp);

            return value;
        }
    }
}
