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
            var result1 = PclNumberConverters.NumeralTypes.Roman.IntFromRomanNumerals("DCXXI");

            var result2 = PclNumberConverters.Units.Time.SITime.Convert(100, PclNumberConverters.Units.Time.SITimeDefinition.Second, PclNumberConverters.Units.Time.SITimeDefinition.Terasecond);

            if (true) ;
        }
    }
}
