using EasyRegex.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace EasyRegex
{
    internal class NonGenericMatching
    {
        public RegexOutput Start(string dataToParse, Regex expressionToUse)
        {
            return InitializeOutput(dataToParse, expressionToUse);
        }

        private RegexOutput InitializeOutput(string dataToParse, Regex expressionToUse)
        {
            var matchData = InitializeRegexOutput.InitializeOutput(expressionToUse);
            GetMatchInfo(dataToParse, matchData);
            return matchData;
        }
        
        private void GetMatchInfo(string record, RegexOutput data)
        {
            var mc = data.Expression.Matches(record);
            SelectMatches.GetMatchValues(mc, data);
        }        
    }
}
