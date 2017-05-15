using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PclNumberConverters.Conversions.Temperature
{
    public enum TemperatureScale
    {
        Kelvin,
        Celsius,
        Fahrenheit,
        Rankine,
        Roemer,
        Newton,
        Delisle,
        Reaumur,
    }

    public static class Temperature
    {
        public static Dictionary<TemperatureScale, string> Postfixes = new Dictionary<TemperatureScale, string>()
        {
            { TemperatureScale.Celsius, (char)248 + "C" },
            { TemperatureScale.Delisle, (char)248 + "De" },
            { TemperatureScale.Fahrenheit, (char)248 + "F" },
            { TemperatureScale.Kelvin, "K" },
            { TemperatureScale.Newton, (char)248 + "N" },
            { TemperatureScale.Rankine, (char)248 + "R" },
            { TemperatureScale.Reaumur, (char)248 + "Re" },
            { TemperatureScale.Roemer, (char)248 + "Roe" },
        };

        public static decimal Convert(decimal value, TemperatureScale fromScale, TemperatureScale toScale)
        {
            return ConvertFromCelsius(ConvertToCelsius(value, fromScale), toScale);
        }

        internal static decimal ConvertToCelsius(decimal value, TemperatureScale fromScale)
        {
            switch (fromScale)
            {
                case TemperatureScale.Celsius:
                    return value;
                case TemperatureScale.Delisle:
                    return 100 - value * (2 / 3m);
                case TemperatureScale.Fahrenheit:
                    return (value - 32) * (5 / 9m);
                case TemperatureScale.Kelvin:
                    return value - 273.15m;
                case TemperatureScale.Newton:
                    return value * (100 / 33m);
                case TemperatureScale.Rankine:
                    return (value - 491.67m) * (5 / 9m);
                case TemperatureScale.Reaumur:
                    return value * (5 / 4m);
                case TemperatureScale.Roemer:
                    return (value - 7.5m) * (40 / 21m);
            }

            return 0;
        }

        internal static decimal ConvertFromCelsius(decimal value, TemperatureScale toScale)
        {
            switch (toScale)
            {
                case TemperatureScale.Celsius:
                    return value;
                case TemperatureScale.Delisle:
                    return (100 - value) * (3/2m);
                case TemperatureScale.Fahrenheit:
                    return value * (9 / 5m) + 32;
                case TemperatureScale.Kelvin:
                    return value + 273.15m;
                case TemperatureScale.Newton:
                    return value * (33 / 100m);
                case TemperatureScale.Rankine:
                    return (value + 273.15m) * (9.5m);
                case TemperatureScale.Reaumur:
                    return value * (4 / 5m);
                case TemperatureScale.Roemer:
                    return value * (21 / 40m) + 7.5m;
            }

            return 0;
        }



        public static string GetUnitShortPostfix(TemperatureScale scale)
        {
            var units = Postfixes;

            string output;
            if (units.TryGetValue(scale, out output))
                return output;
            return string.Empty;
        }

        public static string ConvertToStringShortPostfix(decimal value, TemperatureScale scale)
        {
            var units = Postfixes;

            string output;
            if (units.TryGetValue(scale, out output))
                return $"{value}{output}";
            return string.Empty;
        }

        public static string ConvertToStringFullPostfix(decimal value, TemperatureScale scale)
        {
            return $"{value} {scale.ToString().Replace($"{typeof(TemperatureScale).ToString()}.", "")}";
        }

        public static TemperatureScale? GetTimeDefinitionFromUnitName(string unit, bool ignoreCapitalization = false)
        {
            var siTimeStr = $"{typeof(TemperatureScale).ToString()}.";
            Dictionary<string, TemperatureScale> units = new Dictionary<string, TemperatureScale>();
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

        public static TemperatureScale? GetTimeDefinitionFromUnitPostfix(string unit, bool ignoreCapitalization = false)
        {
            if (!Postfixes.ContainsValue(unit)) return null;

            var comp = ignoreCapitalization
                            ? StringComparison.OrdinalIgnoreCase
                            : StringComparison.Ordinal;
            foreach (var tUnit in Postfixes)
                if (string.Equals(tUnit.Value, unit, comp)) return tUnit.Key;

            return null;
        }
    }
}
