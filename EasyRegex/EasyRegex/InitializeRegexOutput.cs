using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyRegex
{
    internal static class InitializeRegexOutput
    {
        public static RegexOutput<T> InitializeOutput<T>(T classToFill, Regex expressionToUse)
        {

            RegexOutput<T> output = new RegexOutput<T>
            {
                Expression = expressionToUse,
                MatchCollection = new List<MatchCollection>(),
                Groups = new List<Group>(),
                GroupNames = expressionToUse.GetGroupNamesWithoutZero(),
                AllMatchedNamedGroupValues = new Dictionary<string, List<NamedMatchGroupValues>>(),
                UserProvidedModel = new List<T>()
            };
            return output;
        }

        public static RegexOutput InitializeOutput(Regex expressionToUse)
        {
            RegexOutput output = new RegexOutput
            {
                Expression = expressionToUse,
                MatchCollection = new List<MatchCollection>(),
                Groups = new List<Group>(),
                GroupNames = expressionToUse.GetGroupNamesWithoutZero(),
                AllMatchedNamedGroupValues = new Dictionary<string, List<string>>()                
            };
            return output;
        }

        private static List<string> GetGroupNamesWithoutZero(this Regex regex)
        {
            return regex.GetGroupNames().Where(x => !x.All(char.IsDigit)).ToList();
        }
    }
}
