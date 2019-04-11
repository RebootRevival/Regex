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
        public static RegexOutput<T> SelectAll<T>(T classToFill, IEnumerable<string> dataToParse, Regex expresion) where T : IEasyRegex, new()
        {
            GenericMatching generic = new GenericMatching();
            return generic.Start(classToFill, dataToParse, expresion);            
        }
    }
}
