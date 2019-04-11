using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyRegex.Helpers
{
    internal static class SelectMatches
    {
        public static void GetMatchValues(MatchCollection mc, RegexOutput output)
        {
            output.MatchCollection.Add(mc);
            var matchGroups = SelectMatchGroups(mc, output.GroupNames);
            output.Groups.AddRange(matchGroups);
            NamedGroupValues.Add(output.AllMatchedNamedGroupValues, output.GroupNames, matchGroups);
        }

        public static void GetMatchValues<T>(MatchCollection mc, RegexOutput<T> output) where T : new()
        {
            var newEntry = new T();
            output.MatchCollection.Add(mc);
            int id = output.UserProvidedModel.Count() + 1;
            var input = mc.GetInputValue();
            var matchGroups = SelectMatchGroups(mc, output.GroupNames);
            output.Groups.AddRange(matchGroups);
            NamedGroupValues.Add(output.AllMatchedNamedGroupValues, id, output.GroupNames, matchGroups);
            foreach (Group mg in matchGroups)
            {
                newEntry.GetType().GetProperty(mg.Name)?.SetValue(newEntry, mg.Value);
            }
            newEntry.GetType().GetProperty("Id")?.SetValue(newEntry, id);            
            newEntry.GetType().GetProperty("InputRecord")?.SetValue(newEntry, input);
            output.UserProvidedModel.Add(newEntry);
        }

        private static IEnumerable<Group> SelectMatchGroups(MatchCollection mc, List<string> groupNames)
        {
            return mc.AsEnumerable().SelectMany(m => groupNames,(m, n) => new {m,n}).Where(@t => @t.m.Groups[@t.n].Success).Select(@t => @t.m.Groups[@t.n]);
        }        
        
        private static IEnumerable<Match> AsEnumerable(this MatchCollection mc)
        {
            foreach (Match m in mc)
            {
                yield return m;
            }
        }
         
        private static string GetInputValue(this MatchCollection mc) => mc.GetType().GetField("_input", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(mc).ToString();
    }
}
