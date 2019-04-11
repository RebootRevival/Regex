using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyRegex
{
    internal interface IRegexOutput
    {
        List<MatchCollection> MatchCollection { get; set; }
        List<Group> Groups { get; set; }
        Regex Expression { get; set; }
        List<string> GroupNames { get; set; }
    }
}
