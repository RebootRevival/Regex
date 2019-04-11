using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyRegex
{
    public class RegexOutput : IRegexOutput
    { 
        public List<MatchCollection> MatchCollection { get; set; }
        public List<Group> Groups { get; set; }
        public Regex Expression { get; set; }
        public List<string> GroupNames { get; set; }
        public Dictionary<string, List<string>> AllMatchedNamedGroupValues{ get; set; }       
    }
}
