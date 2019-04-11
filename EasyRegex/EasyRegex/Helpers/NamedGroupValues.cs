using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyRegex
{
    internal static class NamedGroupValues
    {
        public static void Add(Dictionary<string, List<string>> namedGroupValues, List<string> groupNames, IEnumerable<Group> matches)
        {
            foreach (var key in groupNames)
            {
                var matchVal = matches.Where(x => x.Name.Equals(key)).Select(x => x.Value);
                if (matchVal.Count() > 0)
                {
                    if (namedGroupValues.ContainsKey(key))
                    {
                        namedGroupValues[key].AddRange(matchVal);
                        continue;
                    }
                    namedGroupValues.Add(key, new List<string>());
                    namedGroupValues[key].AddRange(matchVal);
                }                
            }
        }

        public static void Add(Dictionary<string, List<NamedMatchGroupValues>> namedGroupValues, int id, List<string> groupNames, IEnumerable<Group> matches)
        {
            

            foreach (var key in groupNames)
            {
                var namedMatch = new NamedMatchGroupValues
                {
                    Id = id,
                    MatchValues = new List<string>()
                };
                var matchVal = matches.Where(x => x.Name.Equals(key)).Select(x => x.Value);
                if (matchVal.Count() > 0)
                {
                    if (namedGroupValues.ContainsKey(key))
                    {
                        namedMatch.MatchValues.AddRange(matchVal);
                        namedGroupValues[key].Add(namedMatch);
                        continue;
                    }
                    namedGroupValues.Add(key, new List<NamedMatchGroupValues>());
                    namedMatch.MatchValues.AddRange(matchVal);
                    namedGroupValues[key].Add(namedMatch);
                }
            }
        }
    }
}
