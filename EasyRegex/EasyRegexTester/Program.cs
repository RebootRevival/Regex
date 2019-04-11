using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyRegexTester
{
    public class Program
    {
        static void Main(string[] args)
        {
            var testRegex = new Regex(@"(?<name>.*?)[\r\n]Stats\:.(?<stats>.*?)\.([\r\n]Elem.+\:(?<ElemStats>.*)|)[\r\n]Fact.+\:.(?<Factor>.*).[\r\n]Obt.*\:.(?<obtain>.*).[\r\n]Synt.+\:.(?<SynthLimit>.*)\.", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            var testClass = new TestClass();

            //var dataListToParse = new List < string >();

            var dataStringToParse = @"tri-Emblum
Stats: ATK +2, INT +2, DEF +1, HIT +1, GRD +1.
Elemental Stats: none.
Factors (1): HIT +2.
Obtain: Anthropology Drop of Thieving Scumbag (Roak - Tatroi Area); also common drop of Black Eagle Ranger (Cave of the Seven Stars boss).
Synthesis Limit: 8.";

            var results1 = EasyRegex.Matches.SelectAll(dataStringToParse, testRegex);
            //var results2 = EasyRegex.Matches.SelectAll(testClass, dataListToParse, testRegex);

            var number = results1.Groups.Where(x => x.Name == "Number").Select(x => x.Value);
            var testing = number;

        }
    }
}
