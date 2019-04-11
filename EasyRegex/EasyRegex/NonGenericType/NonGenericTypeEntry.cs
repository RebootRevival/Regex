using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyRegex
{
    public static partial class Matches
    {
        public static RegexOutput SelectAll(string dataToParse, Regex expresion)
        {
            NonGenericMatching nonGeneric = new NonGenericMatching();
            return nonGeneric.Start(dataToParse, expresion);
        }
    }
}
