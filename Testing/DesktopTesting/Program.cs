using PclNumberConverters.Conversions.Temperature;
using PclNumberConverters.Conversions.Time;
using PclNumberConverters.NumeralTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var result1 = Roman.IntFromRomanNumerals("DCXXI");

            var result10 = Time.ConvertTime(100, SiTime.Second, SiTime.Terasecond);
            var result11 = Time.ConvertTime(100, SiTime.Second, UtcTime.Year);
            var result12 = Time.ConvertTime(100, UtcTime.Year, SiTime.Second);

            var result20 = Temperature.Convert(100, TemperatureScale.Celsius, TemperatureScale.Fahrenheit);
            var result21 = Temperature.Convert(100, TemperatureScale.Fahrenheit, TemperatureScale.Celsius);

            if (true) ;
        }
    }
}
