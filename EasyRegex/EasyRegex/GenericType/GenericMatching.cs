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
    internal class GenericMatching
    {
        public RegexOutput<T> Start<T>(T classToFill, IEnumerable<string> dataToParse, Regex expressionToUse)
            where T : new()
        {
            return InitializeOutput(classToFill, dataToParse, expressionToUse);
        }

        private RegexOutput<T> InitializeOutput<T>(T classToFill, IEnumerable<string> dataToParse, Regex expressionToUse)
            where T : new()
        {
            var matchData = InitializeRegexOutput.InitializeOutput(classToFill, expressionToUse);
            foreach (var record in dataToParse)
            {
                GetMatchInfo(record, matchData);
            }
            return matchData;
        }

        private void GetMatchInfo<T>(string record, RegexOutput<T> data)
            where T : new()
        {
            var mc = data.Expression.Matches(record);
            SelectMatches.GetMatchValues(mc, data);            
        }        
    }
}
