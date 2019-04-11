using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyRegex;

namespace EasyRegexTester
{
    public class TestClass : IEasyRegex
    {
        public int Id { get; set; }
        public string InputRecord { get; set; }

        /* Properties here must be the same names as the Regex Named Groups 
        Example:
            Regex: (?<Name>\w.*?)|(?<Number>\d{3})
        */

        public string ItemName { get; set; }
        public string Stats { get; set; }
        public string ElementalStats { get; set; }
        public string Factors { get; set; }
        public string Obtain { get; set; }
        public string SynthLimit { get; set; }

    }
}
